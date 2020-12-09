using FluentAssertions;
using NUnit.Framework;

namespace Aaru.Tests.Devices.MultiMediaCard
{
    [TestFixture]
    public class ExtendedCSD
    {
        readonly byte[][] ecsd =
        {
            new byte[]
            {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x09,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
                0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x34, 0x13, 0x00, 0x07, 0x01, 0x01, 0x00, 0x00, 0x00, 0x15, 0x1F, 0x20, 0x00,
                0x00, 0x00, 0x00, 0x11, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x03, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x02, 0x00, 0x57, 0x01, 0x05, 0x0A, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0xC0, 0x33, 0x07, 0x10, 0x16, 0x00, 0x07, 0x07,
                0x08, 0x01, 0x05, 0x01, 0x06, 0x20, 0x00, 0x07, 0x11, 0x1B, 0x55, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3C, 0x0A, 0x00, 0x00, 0x01, 0x00, 0x00, 0x1B,
                0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x20, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x1F, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x03, 0x03, 0x07, 0x05, 0x00, 0x03, 0x01, 0x3F, 0x3F, 0x01, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00
            }
        };

        readonly Decoders.MMC.ExtendedCSD[] decoded =
        {
            new Decoders.MMC.ExtendedCSD
            {
                Reserved0                                 = new byte[15],
                CommandQueueModeEnable                    = 0,
                SecureRemovalType                         = 9,
                ProductStateAwarenessEnablement           = 0,
                MaxPreLoadingDataSize                     = 0,
                FFUStatus                                 = 0,
                Reserved1                                 = 0,
                ModeOperationCodes                        = 0,
                ModeConfig                                = 0,
                BarrierControl                            = 0,
                CacheFlushing                             = 0,
                CacheControl                              = 1,
                PowerOffNotification                      = 1,
                PackedCommandFailureIndex                 = 0,
                PackedCommandStatus                       = 0,
                ContextConfiguration                      = new byte[15],
                ExtendedPartitionsAttribute               = 0,
                ExceptionEventsStatus                     = 0,
                ExceptionEventsControl                    = 0,
                DyncapNeeded                              = 0,
                Class6CommandsControl                     = 0,
                InitializationTimeoutAfterEmulationChange = 0,
                SectorSize                                = 0,
                SectorSizeEmulation                       = 0,
                NativeSectorSize                          = 0,
                VendorSpecific                            = new byte[64],
                Reserved2                                 = 0,
                SupportsProgramCxDInDDR                   = 1,
                PeriodicWakeUp                            = 0,
                PackageCaseTemperatureControl             = 0,
                ProductionStateAwareness                  = 0,
                BadBlockManagementMode                    = 0,
                Reserved3                                 = 0,
                EnhancedUserDataStartAddress              = 0,
                EnhancedUserDataAreaSize                  = new byte[3],
                GeneralPurposePartitionSize               = new byte[12],
                PartitioningSetting                       = 0,
                PartitionsAttribute                       = 0,
                MaxEnhancedAreaSize = new byte[]
                {
                    52, 19, 0
                },
                PartitioningSupport                  = 7,
                HPIManagement                        = 1,
                HWResetFunction                      = 1,
                EnableBackgroundOperationsHandshake  = 0,
                ManuallyStartBackgroundOperations    = 0,
                StartSanitizeOperation               = 0,
                WriteReliabilityParameterRegister    = 21,
                WriteReliabilitySettingRegister      = 31,
                RPMBSize                             = 32,
                FirmwareConfiguration                = 0,
                Reserved4                            = 0,
                UserAreaWriteProtectionRegister      = 0,
                Reserved5                            = 0,
                BootAreaWriteProtectionRegister      = 17,
                BootWriteProtectionStatus            = 5,
                HighCapacityEraseGroupDefinition     = 1,
                Reserved6                            = 0,
                BootBusConditions                    = 0,
                BootConfigProtection                 = 0,
                PartitionConfiguration               = 0,
                Reserved7                            = 0,
                ErasedMemoryContent                  = 0,
                Reserved8                            = 0,
                BusWidth                             = 0,
                StrobeSupport                        = 1,
                HighSpeedInterfaceTiming             = 3,
                Reserved9                            = 0,
                PowerClass                           = 0,
                Reserved10                           = 0,
                CommandSetRevision                   = 0,
                Reserved11                           = 0,
                CommandSet                           = 0,
                Revision                             = 8,
                Reserved12                           = 0,
                Structure                            = 2,
                Reserved13                           = 0,
                DeviceType                           = 87,
                DriverStrength                       = 1,
                OutOfInterruptBusyTiming             = 5,
                PartitionSwitchingTime               = 10,
                PowerClass52_195                     = 0,
                PowerClass26_195                     = 0,
                PowerClass52                         = 0,
                PowerClass26                         = 0,
                Reserved14                           = 0,
                MinimumReadPerformance26_4           = 0,
                MinimumWritePerformance26_4          = 0,
                MinimumReadPerformance26             = 0,
                MinimumWritePerformance26            = 0,
                MinimumReadPerformance52             = 0,
                MinimumWritePerformance52            = 0,
                SecureWriteProtectInformation        = 1,
                SectorCount                          = 120832000,
                SleepNotificationTimeout             = 16,
                SleepAwakeTimeout                    = 22,
                ProductionStateAwarenessTimeout      = 0,
                SleepCurrentVccQ                     = 7,
                SleepCurrentVcc                      = 7,
                HighCapacityWriteProtectGroupSize    = 8,
                ReliableWriteSectorCount             = 1,
                HighCapacityEraseTimeout             = 5,
                HighCapacityEraseUnitSize            = 1,
                AccessSize                           = 6,
                BootPartitionSize                    = 32,
                Reserved15                           = 0,
                BootInformation                      = 7,
                SecureTRIMMultiplier                 = 17,
                SecureEraseMultiplier                = 27,
                SecureFeatureSupport                 = 85,
                TRIMMultiplier                       = 5,
                Reserved16                           = 0,
                MinimumReadPerformanceDDR52          = 0,
                MinimumWritePerformanceDDR52         = 0,
                PowerClassDDR200_130                 = 0,
                PowerClassDDR200_195                 = 0,
                PowerClassDDR52_195                  = 0,
                PowerClassDDR52                      = 0,
                CacheFlushingPolicy                  = 0,
                InitializationTimeAfterPartition     = 30,
                CorrectlyProgrammedSectors           = 0,
                BackgroundOperationsStatus           = 0,
                PowerOffNotificationTimeout          = 60,
                GenericCMD6Timeout                   = 10,
                CacheSize                            = 65536,
                PowerClassDDR200                     = 0,
                FirmwareVersion                      = 283,
                DeviceVersion                        = 0,
                OptimalTrimUnitSize                  = 1,
                OptimalWriteSize                     = 32,
                OptimalReadSize                      = 0,
                PreEOLInformation                    = 1,
                DeviceLifeEstimationTypeA            = 1,
                DeviceLifeEstimationTypeB            = 1,
                VendorHealthReport                   = new byte[32],
                NumberofFWSectorsCorrectlyProgrammed = 0,
                Reserved17                           = 0,
                CMDQueuingDepth                      = 31,
                CMDQueuingSupport                    = 1,
                Reserved18                           = new byte[177],
                BarrierSupport                       = 0,
                FFUArgument                          = 0,
                OperationCodesTimeout                = 0,
                FFUFeatures                          = 0,
                SupportedModes                       = 3,
                ExtendedPartitionsSupport            = 3,
                LargeUnitSize                        = 7,
                ContextManagementCaps                = 5,
                TagResourcesSize                     = 0,
                TagUnitSize                          = 3,
                DataTagSupport                       = 1,
                MaxPackedWriteCommands               = 63,
                MaxPackedReadCommands                = 63,
                BackgroundOperationsSupport          = 1,
                HPIFeatures                          = 1,
                SupportedCommandSets                 = 1,
                ExtendedSecurityCommandsError        = 0,
                Reserved19                           = new byte[6]
            }
        };

        [Test]
        public void Test()
        {
            for(int i = 0; i < ecsd.Length; i++)
            {
                Decoders.MMC.ExtendedCSD csd = Decoders.MMC.Decoders.DecodeExtendedCSD(ecsd[i]);
                Assert.IsNotNull(csd, $"Not decoded - {i}");
                csd.Should().BeEquivalentTo(decoded[i]);
            }
        }
    }
}