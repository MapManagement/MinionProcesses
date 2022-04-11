using System.Text;
using MinionProcesses.Components.Enums;

namespace MinionProcesses.QemuCommands.Helpers
{
    public static class CreateProcesses
    {
        public static void CreateImage(StorageFileFormat fileFormat, float size, string name)
        {
            var stringBuilder = new StringBuilder("qemu-img create -f ");
            stringBuilder.Append(fileFormat).Append(" ");
            stringBuilder.Append(name).Append(".").Append(fileFormat).Append(" ");
            stringBuilder.Append(size); //TODO: unit is missing

        }
    }
}