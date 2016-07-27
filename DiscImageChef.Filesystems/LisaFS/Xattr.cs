﻿// /***************************************************************************
// The Disc Image Chef
// ----------------------------------------------------------------------------
//
// Filename       : Xattr.cs
// Version        : 1.0
// Author(s)      : Natalia Portillo
//
// Component      : Component
//
// Revision       : $Revision$
// Last change by : $Author$
// Date           : $Date$
//
// --[ Description ] ----------------------------------------------------------
//
// Description
//
// --[ License ] --------------------------------------------------------------
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// ----------------------------------------------------------------------------
// Copyright (C) 2011-2015 Claunia.com
// ****************************************************************************/
// //$Id$
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.CodeDom.Compiler;

namespace DiscImageChef.Filesystems.LisaFS
{
    partial class LisaFS : Filesystem
    {
        public override Errno ListXAttr(string path, ref List<string> xattrs)
        {
            Int16 fileId;
            Errno error = LookupFileId(path, out fileId);
            if(error != Errno.NoError)
                return error;

            return ListXAttr(fileId, ref xattrs);
        }

        public override Errno GetXattr(string path, string xattr, ref byte[] buf)
        {
            Int16 fileId;
            Errno error = LookupFileId(path, out fileId);
            if(error != Errno.NoError)
                return error;

            return GetXattr(fileId, xattr, out buf);
        }

        Errno ListXAttr(Int16 fileId, ref List<string> xattrs)
        {
            xattrs = null;

            if(!mounted)
                return Errno.AccessDenied;

            if(fileId < 4)
            {
                if(!debug || fileId == 0)
                    return Errno.InvalidArgument;

                xattrs = new List<string>();

                if(fileId == FILEID_MDDF)
                {
                    byte[] buf = Encoding.ASCII.GetBytes(mddf.password);
                    if(buf.Length > 0)
                        xattrs.Add("com.apple.lisa.password");
                }
            }
            else
            {

                ExtentFile file;

                Errno error = ReadExtentsFile(fileId, out file);

                if(error != Errno.NoError)
                    return error;

                xattrs = new List<string>();
                if(file.password_valid > 0)
                    xattrs.Add("com.apple.lisa.password");
                xattrs.Add("com.apple.lisa.serial");

                if(!ArrayHelpers.ArrayIsNullOrEmpty(file.LisaInfo))
                    xattrs.Add("com.apple.lisa.label");
            }

            if(debug)
                xattrs.Add("com.apple.lisa.tags");

            xattrs.Sort();

            return Errno.NoError;
        }

        Errno GetXattr(Int16 fileId, string xattr, out byte[] buf)
        {
            return GetXattr(fileId, xattr, out buf, false);
        }

        Errno GetXattr(Int16 fileId, string xattr, out byte[] buf, bool tags)
        {
            buf = null;

            if(!mounted)
                return Errno.AccessDenied;

            if(fileId < 4)
            {
                if(!debug || fileId == 0)
                    return Errno.InvalidArgument;

                if(fileId == FILEID_MDDF)
                {
                    if(xattr == "com.apple.lisa.password")
                    {
                        buf = Encoding.ASCII.GetBytes(mddf.password);
                        return Errno.NoError;
                    }
                }

                if(debug && xattr == "com.apple.lisa.tags")
                    return ReadSystemFile(fileId, out buf, true);

                return Errno.NoSuchExtendedAttribute;
            }

            ExtentFile file;

            Errno error = ReadExtentsFile(fileId, out file);

            if(error != Errno.NoError)
                return error;

            if(xattr == "com.apple.lisa.password" && file.password_valid > 0)
            {
                buf = new byte[8];
                Array.Copy(file.password, 0, buf, 0, 8);
                return Errno.NoError;
            }

            if(xattr == "com.apple.lisa.serial")
            {
                buf = Encoding.ASCII.GetBytes(file.serial.ToString());
                return Errno.NoError;
            }

            if(!ArrayHelpers.ArrayIsNullOrEmpty(file.LisaInfo) && xattr == "com.apple.lisa.label")
            {
                buf = new byte[128];
                Array.Copy(file.LisaInfo, 0, buf, 0, 128);
                return Errno.NoError;
            }

            if(debug && xattr == "com.apple.lisa.tags")
                return ReadFile(fileId, out buf, true);

            return Errno.NoSuchExtendedAttribute;
        }

        Errno DecodeTag(byte[] tag, out Tag decoded)
        {
            decoded = new Tag();

            if(tag.Length == 12)
            {
                decoded.version = BigEndianBitConverter.ToUInt16(tag, 0x00);
                decoded.unknown = BigEndianBitConverter.ToUInt16(tag, 0x02);
                decoded.fileID = BigEndianBitConverter.ToInt16(tag, 0x04);
                decoded.relBlock = BigEndianBitConverter.ToUInt16(tag, 0x06);
                decoded.nextBlock = BigEndianBitConverter.ToUInt16(tag, 0x08);
                decoded.nextBlock &= 0x7FF;
                decoded.prevBlock = BigEndianBitConverter.ToUInt16(tag, 0x0A);
                decoded.prevBlock &= 0x7FF;

                if(decoded.nextBlock == 0x7FF)
                    decoded.isLast = true;
                if(decoded.prevBlock == 0x7FF)
                    decoded.isFirst = true;
            }
            else
            {
                decoded.version = BigEndianBitConverter.ToUInt16(tag, 0x00);
                decoded.unknown = BigEndianBitConverter.ToUInt16(tag, 0x02);
                decoded.fileID = BigEndianBitConverter.ToInt16(tag, 0x04);
                decoded.usedBytes = BigEndianBitConverter.ToUInt16(tag, 0x06);
                decoded.absoluteBlock = BigEndianBitConverter.ToUInt32(tag, 0x07);
                decoded.absoluteBlock &= 0xFFFFFF;
                decoded.checksum = tag[0x0B];
                decoded.relBlock = BigEndianBitConverter.ToUInt16(tag, 0x0C);
                decoded.nextBlock = BigEndianBitConverter.ToUInt32(tag, 0x0D);
                decoded.nextBlock &= 0xFFFFFF;
                decoded.prevBlock = BigEndianBitConverter.ToUInt32(tag, 0x10);
                decoded.prevBlock &= 0xFFFFFF;

                if(decoded.nextBlock == 0xFFFFFF)
                    decoded.isLast = true;
                if(decoded.prevBlock == 0xFFFFFF)
                    decoded.isFirst = true;
            }

            return Errno.NoError;
        }
    }
}

