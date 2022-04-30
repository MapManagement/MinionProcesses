using MinionProcesses.Components.Enums;
using MinionProcesses.Components.Interfaces;

namespace MinionProcesses.Components
{
    public class Storage : IStorage
    {
        public Storage(string path, StorageType type, StorageBusType busType, bool isReadonly, bool isShareable)
        {
            Path = path;
            Type = type;
            BusType = busType;
            IsReadonly = isReadonly;
            IsShareable = isShareable;
        }

        public string Path { get; set; }
        public StorageType Type { get; set; }
        public StorageBusType BusType { get; set; }
        public float Size { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsShareable { get; set; }
    }
}