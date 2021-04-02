using System;

namespace OclPlatform
{
    public class Device
    {
        public string Name { get; private set; }
        public int DeviceIndex { get; private set; }
        public string OpenClCVersion { get; private set; }
        public string OpenClVersion { get; private set; }
        public int ComputeUnits { get; private set; }
        public int LocalMemorySize { get; private set; }
        public int MaxMemoryAllocSize { get; private set; }
        public bool HostUnifiedMemory { get; private set; }
        public string DriverVersion { get; private set; }
        public string Type { get; private set; }
        public string Vendor { get; private set; }
        public IntPtr Pointer { get; private set; }

        public Device(Emgu.CV.Ocl.Device device, int index)
        {
            Name = device.Name;
            DeviceIndex = index;
            OpenClCVersion = device.OpenCLCVersion;
            OpenClVersion = device.OpenCLVersion;
            ComputeUnits = device.MaxComputeUnits;
            LocalMemorySize = device.LocalMemSize;
            MaxMemoryAllocSize = device.MaxMemAllocSize;
            HostUnifiedMemory = device.HostUnifiedMemory;
            DriverVersion = device.DriverVersion;
            Type = device.Type.ToString();
            Vendor = device.VendorName;
            Pointer = device.NativeDevicePointer;
        }
    }
}
