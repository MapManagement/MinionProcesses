namespace MinionProcesses.Components.Enums
{
    public enum StorageType
    {
        Disk,
        CdRom,
        Floppy,
        LunPassthrough
    }

    public enum StorageBusType
    {
        Sata,
        VirtIo,
        Usb,
        Scsi
    }

    public enum StorageFileFormat
    {
        Raw,
        Qcow,
        Qcow2,
        Qed,
        Luks,
        Vdi,
        Vmdk,
        Vpc,
        Vhdx

    }
}