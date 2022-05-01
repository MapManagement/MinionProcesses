namespace MinionProcesses.Components.Interfaces
{
    public interface IUsbDevice
    {
        string VendorId { get; set; }

        string ProductId { get; set; }

        string? HostBus { get; set; }

        string? HostAddress { get; set; }
    }
}