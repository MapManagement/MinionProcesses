using MinionProcesses.Components.Interfaces;

namespace MinionProcesses.Components
{
    public class UsbDevice : IUsbDevice
    {
        public UsbDevice(string vendorId, string productId)
        {
            VendorId = vendorId;
            ProductId = productId;
        }

        public string VendorId { get; set; }
        public string ProductId { get; set; }
        public string? HostBus { get; set; }
        public string? HostAddress { get; set; }
    }
}