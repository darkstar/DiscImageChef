﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : FAT32.cs
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

namespace Aaru.Tests.Filesystems.FAT32
{
    [TestFixture]
    public class MBR : FilesystemTest
    {
        public MBR() : base("FAT32") {}

        public override string      DataFolder => Path.Combine(Consts.TEST_FILES_ROOT, "Filesystems", "FAT32 (MBR)");
        public override IFilesystem Plugin     => new FAT();
        public override bool        Partitions => true;

        public override FileSystemTest[] Tests => new[]
        {
            new FileSystemTest
            {
                TestFile     = "drdos_7.03.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 8388608,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048233,
                ClusterSize  = 4096,
                SystemId     = "DRDOS7.X",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "5955996C"
            },
            new FileSystemTest
            {
                TestFile     = "drdos_8.00.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 8388608,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048233,
                ClusterSize  = 4096,
                SystemId     = "IBM  7.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "1BFB1A43"
            },
            new FileSystemTest
            {
                TestFile     = "msdos_7.10.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 8388608,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048233,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "3B331809"
            },
            new FileSystemTest
            {
                TestFile     = "macosx_10.11.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524287,
                ClusterSize  = 4096,
                SystemId     = "BSD  4.4",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "42D51EF1"
            },
            new FileSystemTest
            {
                TestFile     = "win10.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524016,
                ClusterSize  = 4096,
                SystemId     = "MSDOS5.0",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "48073346"
            },
            new FileSystemTest
            {
                TestFile     = "win2000.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 8388608,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048233,
                ClusterSize  = 4096,
                SystemId     = "MSDOS5.0",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "EC62E6DE"
            },
            new FileSystemTest
            {
                TestFile     = "win95osr2.1.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524152,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "2A310DE4"
            },
            new FileSystemTest
            {
                TestFile     = "win95osr2.5.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524152,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "0C140DFC"
            },
            new FileSystemTest
            {
                TestFile     = "win95osr2.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524152,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "3E310D18"
            },
            new FileSystemTest
            {
                TestFile     = "win98se.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524112,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "0D3D0EED"
            },
            new FileSystemTest
            {
                TestFile     = "win98.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524112,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "0E131162"
            },
            new FileSystemTest
            {
                TestFile     = "winme.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524112,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "3F500F02"
            },
            new FileSystemTest
            {
                TestFile     = "winvista.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 523520,
                ClusterSize  = 4096,
                SystemId     = "MSDOS5.0",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "82EB4C04"
            },
            new FileSystemTest
            {
                TestFile     = "beos_r4.5.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048560,
                ClusterSize  = 2048,
                SystemId     = "BeOS    ",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "00000000"
            },
            new FileSystemTest
            {
                TestFile     = "linux.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 262144,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 260096,
                ClusterSize  = 512,
                SystemId     = "mkfs.fat",
                VolumeName   = "VolumeLabel",
                VolumeSerial = "B488C502"
            },
            new FileSystemTest
            {
                TestFile     = "aros.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Clusters     = 524160,
                ClusterSize  = 4096,
                SystemId     = "MSWIN4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "5CAC9B4E"
            },
            new FileSystemTest
            {
                TestFile     = "freebsd_6.1.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524112,
                ClusterSize  = 4096,
                SystemId     = "BSD  4.4",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "41540E0E"
            },
            new FileSystemTest
            {
                TestFile     = "freebsd_7.0.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 524112,
                ClusterSize  = 4096,
                SystemId     = "BSD  4.4",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "4E600E0F"
            },
            new FileSystemTest
            {
                TestFile     = "freebsd_8.2.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 4194304,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 65514,
                ClusterSize  = 32768,
                SystemId     = "BSD4.4  ",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "26E20E0F"
            },
            new FileSystemTest
            {
                TestFile     = "freedos_1.2.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 8388608,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 1048233,
                ClusterSize  = 4096,
                SystemId     = "FRDOS4.1",
                VolumeName   = "VOLUMELABEL",
                VolumeSerial = "3E0C1BE8"
            },
            new FileSystemTest
            {
                TestFile     = "ecs20_fstester.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1024000,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 127744,
                ClusterSize  = 4096,
                SystemId     = "mkfs.fat",
                VolumeName   = "Volume labe",
                VolumeSerial = "63084BBA"
            },
            new FileSystemTest
            {
                TestFile     = "linux_2.2_umsdos32_flashdrive.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1024000,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 127882,
                ClusterSize  = 4096,
                SystemId     = "mkdosfs",
                VolumeName   = "DICSETTER",
                VolumeSerial = "5CC7908D"
            },
            new FileSystemTest
            {
                TestFile     = "linux_4.19_fat32_msdos_flashdrive.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1024000,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 127744,
                ClusterSize  = 4096,
                SystemId     = "mkfs.fat",
                VolumeName   = "DICSETTER",
                VolumeSerial = "D1290612"
            },
            new FileSystemTest
            {
                TestFile     = "linux_4.19_vfat32_flashdrive.aif",
                MediaType    = MediaType.GENERIC_HDD,
                Sectors      = 1024000,
                SectorSize   = 512,
                Bootable     = true,
                Clusters     = 127744,
                ClusterSize  = 4096,
                SystemId     = "mkfs.fat",
                VolumeName   = "DICSETTER",
                VolumeSerial = "79BCA86E"
            }
        };
    }
}