using System;
using System.Text;
using MinionProcesses.Components;
using MinionProcesses.Components.Enums;
using MinionProcesses.Components.Interfaces;
using MinionProcesses.Helpers;

namespace MinionProcesses.QemuCommands.Helpers
{
    public static class CreateProcesses
    {
        #region Methods

        #region Public

        public static void CreateImage(StorageFileFormat fileFormat, float size, StorageUnit unit, string name)
        {
            string command = "qemu-img";
            
            var arguments = new StringBuilder("create -f ")
                .Append(fileFormat).Append(" ")
                .Append(name).Append(".").Append(fileFormat).Append(" ")
                .Append(size)
                .ToString();

            var runner = new ProcessRunner(command, arguments);
        }

        public static void CreateGuest(IGuest guest)
        {
            string guestCommandArgs = BuildGuestCommand(guest);

            var runner = new ProcessRunner("qemu-system-x86_64 ", guestCommandArgs);
        }

        

        #endregion

        #region Private

        private static string BuildGuestCommand(IGuest guest)
        {
            string guestName = BuildNameOption(guest.Name);
            string guestMachine = BuildMachineOption(guest.GuestDetails);
            string guestMemory = BuildMemoryOption(guest.Memory);
            string guestCpu = BuildCpuOption(guest.Cpu);
            string guestSmp = BuildSmpOption(guest.Cpu);
            

            string qemuCommand = String.Empty;
            var guestCommand = new StringBuilder(qemuCommand)
                .Append(guestName)
                .Append(guestMachine)
                .Append(guestMemory)
                .Append(guestCpu)
                .Append(guestSmp);

            foreach(var drive in guest.StorageDevices)
            {
                string guestDrive = BuildDriveOption(drive); //TODO: boot order?
                guestCommand.Append(guestDrive);
            }

            foreach(var usbDevice in guest.UsbDevices)
            {
                string guestUsbDevice = BuildUsbDeviceOption(usbDevice);
                guestCommand.Append(guestUsbDevice);
            }

            foreach(var pciDevice in guest.PciDevices)
            {
                string guestPciDevice = BuildPciDeviceOption(pciDevice);
                guestCommand.Append(guestPciDevice);
            }

            return qemuCommand;
        }

        private static string BuildNameOption(string name)
        {
            string nameFlag = "-name ";
            string nameOption = name;

            return new StringBuilder(nameFlag).Append(nameOption).ToString();
        }

        private static string BuildMachineOption(IGuestDetails guestDetails)
        {
            string chipset = guestDetails.Chipset.ToString(); //TODO: convert enum
            string accelerator = guestDetails.Accelerator.ToString(); //TODO: convert enum

            string machineFlag = "-machine ";
            string machineOption = $"{chipset}, accel={accelerator}";

            return new StringBuilder(machineFlag).Append(machineOption).ToString();
        }

        private static string BuildMemoryOption(IMemory memory)
        {
            string startupAllocation = memory.Allocation.ToString();
            string maxAllocation = memory.MaxAllocation.ToString();

            string memoryFlag = "-m ";
            string memoryOption = $"{startupAllocation}M, maxmem={maxAllocation}M";

            return new StringBuilder(memoryFlag).Append(memoryOption).ToString();
        }

        private static string BuildCpuOption(ICpu cpu)
        {
            string configuration = cpu.Configuration.ToString(); //TODO: convert enum

            string cpuFlag = "-cpu ";
            string cpuOption = $"{configuration}, kvm=on"; //TODO: check kvm=on option

            return new StringBuilder(cpuFlag).Append(cpuOption).ToString();
        }

        private static string BuildSmpOption(ICpu cpu)
        {
            string sockets = cpu.Sockets.ToString();
            string cores = cpu.Cores.ToString();
            string threads = cpu.Threads.ToString();

            string smpFlag = "-smp ";
            string smpOption = $"threads={threads}, cores={cores}, sockets={sockets}";

            return new StringBuilder(smpFlag).Append(smpOption).ToString();
        }

        private static string BuildDriveOption(IStorage drive, int? bootindex = null)
        {
            string filePath = drive.Path;
            string busType = drive.BusType.ToString(); //TODO: convert enum
            string mediaType = drive.Type.ToString(); //TODO: convert enum
            bool isReadonly = drive.IsReadonly; //TODO: check readonly option

            string driveFlag = "-drive ";
            string driveOption = $"file={filePath}, if={busType}, media={mediaType}, readonly={isReadonly}";

            StringBuilder newDrive = new StringBuilder(driveFlag).Append(driveOption);

            if(bootindex != null)
            {
                newDrive.Append($", bootindex={bootindex}");
            }

            return newDrive.ToString();
        }

        private static string BuildUsbDeviceOption(IUsbDevice usbDevice)
        {
            string vendorId = usbDevice.VendorId;
            string productId = usbDevice.ProductId;

            string usbFlag = "-device ";
            string usbOption = $"usb-host, vendorid={vendorId}, productid={productId}";

            return new StringBuilder(usbFlag).Append(usbOption).ToString();
        }

        private static string BuildPciDeviceOption(IPciDevice pciDevice)
        {
            return String.Empty;
        }

        #endregion

        #endregion
    }
}