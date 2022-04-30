using System.Text;
using MinionProcesses.Components;
using MinionProcesses.Components.Enums;
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

        #endregion

        #region Private

        private static string BuildMachineOption(GuestDetails guestDetails)
        {
            string chipset = guestDetails.Chipset.ToString(); //TODO: convert enum
            string accelerator = guestDetails.Accelerator.ToString(); //TODO: convert enum

            string machineFlag = "-machine ";
            string machineOption = $"{chipset}, accel={accelerator}";

            return new StringBuilder(machineFlag).Append(machineOption).ToString();
        }

        private static string BuildMemoryOption(Memory memory)
        {
            string startupAllocation = memory.Allocation.ToString();
            string maxAllocation = memory.MaxAllocation.ToString();

            string memoryFlag = "-m ";
            string memoryOption = $"{startupAllocation}M, maxmem={maxAllocation}M";

            return new StringBuilder(memoryFlag).Append(memoryOption).ToString();
        }

        private static void BuildCpuOption()
        {

        }

        private static string BuildSmpOption(Cpu cpu)
        {
            string sockets = cpu.Sockets.ToString();
            string cores = cpu.Cores.ToString();
            string threads = cpu.Threads.ToString();

            string smpFlag = "-smp ";
            string smpOption = $"threads={threads}, cores={cores}, sockets={sockets}";

            return new StringBuilder(smpFlag).Append(smpOption).ToString();
        }

        private static string BuildDriveOption(Storage drive)
        {
            string filePath = drive.Path;
            string busType = drive.BusType.ToString();
            string mediaType = drive.Type.ToString();
            bool isReadonly = drive.IsReadonly; //TODO: check readonly option

            string driveFlag = "-drive ";
            string driveOption = $"file={filePath}, if={busType}, media={mediaType}, readonly={isReadonly}";

            return new StringBuilder(driveFlag).Append(driveOption).ToString();
        }

        private static string BuildUsbDeviceOption(UsbDevice usbDevice)
        {
            string vendorId = usbDevice.VendorId;
            string productId = usbDevice.ProductId;

            string usbFlag = "-device ";
            string usbOption = $"usb-host, vendorid={vendorId}, productid={productId}";

            return new StringBuilder(usbFlag).Append(usbOption).ToString();
        }

        private static void BuildPciDeviceOption()
        {

        }

        private static void BuildBootOption()
        {

        }

        private static void BuildIsoOption()
        {

        }

        #endregion

        #endregion
    }
}