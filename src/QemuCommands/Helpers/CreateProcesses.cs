using System.Text;
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

        //TODO: accelerator parameter to enum?
        private static string BuildMachineOption(GuestChipset chipset, string accelerator) 
        {
            string machineFlag = "-machine ";
            string machineOption = $"{chipset.ToString()}, accel={accelerator}";

            return new StringBuilder(machineFlag).Append(machineOption).ToString();
        }

        private static string BuildMemoryOption(float size, StorageUnit unit)
        {
            string memoryFlag = "-m ";
            string memoryOption = $"{size}{unit}";

            return new StringBuilder(memoryFlag).Append(memoryOption).ToString();
        }

        private static void BuildCpuOption()
        {
            
        }

        private static void BuildSmpOption()
        {

        }

        private static void BuildDriveOption()
        {

        }

        private static void BuildUsbDeviceOption()
        {

        }

        private static void BuildPciDeviceOption()
        {

        }

        private static void BuildBootOption()
        {

        }

        #endregion

        #endregion
    }
}