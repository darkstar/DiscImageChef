﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : DiskDup.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : Aaru unit testing.
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
// Copyright © 2011-2021 Natalia Portillo
// ****************************************************************************/

using System;
using System.IO;
using Aaru.Checksums;
using Aaru.CommonTypes;
using Aaru.DiscImages;
using Aaru.Filters;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Aaru.Tests.Images.ShrinkWrap
{
    [TestFixture]
    public class DiskDup
    {
        readonly string[] _testFiles =
        {
            "CDROM.lz", "DC6_RW_HFS_1440.lz", "DC6_RW_HFS_800.lz", "DC6_RW_HFS_DMF.lz", "DOS1440.image.lz", "DOS720.lz",
            "DOSDMF.lz", "PD1440.lz", "PD800.lz", "PDDMF.lz"
        };

        readonly ulong[] _sectors =
        {
            // CDROM.lz
            91108,

            // DC6_RW_HFS_1440.lz
            2880,

            // DC6_RW_HFS_800.lz
            1600,

            // DC6_RW_HFS_DMF.lz
            3360,

            // DOS1440.image.lz
            2880,

            // DOS720.lz
            1440,

            // DOSDMF.lz
            3360,

            // PD1440.lz
            2880,

            // PD800.lz
            1600,

            // PDDMF.lz
            3360
        };

        readonly uint[] _sectorSize =
        {
            // CDROM.lz
            512,

            // DC6_RW_HFS_1440.lz
            512,

            // DC6_RW_HFS_800.lz
            512,

            // DC6_RW_HFS_DMF.lz
            512,

            // DOS1440.image.lz
            512,

            // DOS720.lz
            512,

            // DOSDMF.lz
            512,

            // PD1440.lz
            512,

            // PD800.lz
            512,

            // PDDMF.lz
            512
        };

        readonly MediaType[] _mediaTypes =
        {
            // CDROM.lz
            MediaType.GENERIC_HDD,

            // DC6_RW_HFS_1440.lz
            MediaType.DOS_35_HD,

            // DC6_RW_HFS_800.lz
            MediaType.AppleSonyDS,

            // DC6_RW_HFS_DMF.lz
            MediaType.DMF,

            // DOS1440.image.lz
            MediaType.DOS_35_HD,

            // DOS720.lz
            MediaType.DOS_35_DS_DD_9,

            // DOSDMF.lz
            MediaType.DMF,

            // PD1440.lz
            MediaType.DOS_35_HD,

            // PD800.lz
            MediaType.AppleSonyDS,

            // PDDMF.lz
            MediaType.DMF
        };

        readonly string[] _md5S =
        {
            // CDROM.lz
            "69e3234920e472b24365060241934ca6",

            // DC6_RW_HFS_1440.lz
            "3160038ca028ccf52ad7863790072145",

            // DC6_RW_HFS_800.lz
            "5e255c4bc0f6a26ecd27845b37e65aaa",

            // DC6_RW_HFS_DMF.lz
            "652dc979c177f2d8e846587158b38478",

            // DOS1440.image.lz
            "ff419213080574056ebd9adf7bab3d32",

            // DOS720.lz
            "c2be571406cf6353269faa59a4a8c0a4",

            // DOSDMF.lz
            "92ea7a359957012a682ba126cfdef0ce",

            // PD1440.lz
            "7975e8cf7579a6848d6fb4e546d1f682",

            // PD800.lz
            "a72da7aedadbe194c22a3d71c62e4766",

            // PDDMF.lz
            "7fbf0251a93cb36d98e68b7d19624de5"
        };

        readonly string _dataFolder =
            Path.Combine(Consts.TEST_FILES_ROOT, "Media image formats", "ShrinkWrap 3", "DiskDup+");

        [Test]
        public void Info()
        {
            Environment.CurrentDirectory = _dataFolder;

            Assert.Multiple(() =>
            {
                for(int i = 0; i < _testFiles.Length; i++)
                {
                    var filter = new LZip();
                    filter.Open(_testFiles[i]);

                    var  image  = new ZZZRawImage();
                    bool opened = image.Open(filter);

                    Assert.AreEqual(true, opened, $"Open: {_testFiles[i]}");

                    if(!opened)
                        continue;

                    using(new AssertionScope())
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.AreEqual(_sectors[i], image.Info.Sectors, $"Sectors: {_testFiles[i]}");
                            Assert.AreEqual(_sectorSize[i], image.Info.SectorSize, $"Sector size: {_testFiles[i]}");
                            Assert.AreEqual(_mediaTypes[i], image.Info.MediaType, $"Media type: {_testFiles[i]}");
                        });
                    }
                }
            });
        }

        // How many sectors to read at once
        const uint _sectorsToRead = 256;

        [Test]
        public void Hashes()
        {
            Environment.CurrentDirectory = _dataFolder;

            Assert.Multiple(() =>
            {
                for(int i = 0; i < _testFiles.Length; i++)
                {
                    var filter = new LZip();
                    filter.Open(_testFiles[i]);

                    var   image       = new ZZZRawImage();
                    bool  opened      = image.Open(filter);
                    ulong doneSectors = 0;

                    Assert.AreEqual(true, opened, $"Open: {_testFiles[i]}");

                    if(!opened)
                        continue;

                    var ctx = new Md5Context();

                    while(doneSectors < image.Info.Sectors)
                    {
                        byte[] sector;

                        if(image.Info.Sectors - doneSectors >= _sectorsToRead)
                        {
                            sector      =  image.ReadSectors(doneSectors, _sectorsToRead);
                            doneSectors += _sectorsToRead;
                        }
                        else
                        {
                            sector      =  image.ReadSectors(doneSectors, (uint)(image.Info.Sectors - doneSectors));
                            doneSectors += image.Info.Sectors - doneSectors;
                        }

                        ctx.Update(sector);
                    }

                    Assert.AreEqual(_md5S[i], ctx.End(), $"Hash: {_testFiles[i]}");
                }
            });
        }
    }
}