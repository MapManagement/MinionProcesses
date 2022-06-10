using MinionProcesses.Components.Enums;

namespace MinionProcesses.Components.Interfaces
{
    public interface IStorage
    {
        string Path { get; set; }

        StorageType Type { get; set; }

        StorageBusType BusType { get; set; }

        float Size { get; set; }

        bool IsReadonly { get; set; }

        bool IsShareable { get; set; }

        int? BootOrder { get; set; }
    }   
}