﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : HFSX.cs
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

using System.IO;
using Aaru.CommonTypes;
using Aaru.CommonTypes.Interfaces;
using Aaru.Filesystems;
using NUnit.Framework;

namespace Aaru.Tests.Filesystems.HFSX
{
    [TestFixture]
    public class APM : FilesystemTest
    {
        public APM() : base("HFSX") {}

        public override string DataFolder => Path.Combine(Consts.TEST_FILES_ROOT, "Filesystems", "Apple HFSX (APM)");
        public override IFilesystem Plugin => new AppleHFSPlus();
        public override bool Partitions => true;

        public override FileSystemTest[] Tests => new[]
        {
            new FileSystemTest
            {
                TestFile     = "macosx_10.11.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 819200,
                SectorSize   = 512,
                Clusters     = 102390,
                ClusterSize  = 4096,
                SystemId     = "10.0",
                VolumeSerial = "CC2D56884950D9AE"
            },
            new FileSystemTest
            {
                TestFile     = "macosx_10.11_journal.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1228800,
                SectorSize   = 512,
                Clusters     = 153590,
                ClusterSize  = 4096,
                SystemId     = "HFSJ",
                VolumeSerial = "7AF1175D8EA7A072"
            },
            new FileSystemTest
            {
                TestFile     = "darwin_8.0.1_journal.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1638400,
                SectorSize   = 512,
                Clusters     = 204792,
                ClusterSize  = 4096,
                SystemId     = "10.0",
                VolumeSerial = "BB4ABD7E7E2FF5AF"
            },
            new FileSystemTest
            {
                TestFile     = "darwin_8.0.1.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1433600,
                SectorSize   = 512,
                Clusters     = 179192,
                ClusterSize  = 4096,
                SystemId     = "10.0",
                VolumeSerial = "E2F212D815EF77B5"
            },
            new FileSystemTest
            {
                TestFile     = "macosx_10.4_journal.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Clusters     = 491290,
                ClusterSize  = 4096,
                SystemId     = "HFSJ",
                VolumeSerial = "5A8C646A5D77EB16"
            },
            new FileSystemTest
            {
                TestFile     = "macosx_10.4.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1024000,
                SectorSize   = 512,
                Clusters     = 127770,
                ClusterSize  = 4096,
                SystemId     = "10.0",
                VolumeSerial = "258C51A750F6A485"
            }
        };
    }
}