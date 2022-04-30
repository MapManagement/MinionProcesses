namespace MinionProcesses.Components.Interfaces
{
    public interface IMemory
    {
        ///<summary>
        /// Startup memory allocation in megabytes
        ///</summary>
        int Allocation { get; set; }

        ///<summary>
        /// Maximum memory allocation in megabytes
        ///</summary>
        int MaxAllocation { get; set; }
    }
}