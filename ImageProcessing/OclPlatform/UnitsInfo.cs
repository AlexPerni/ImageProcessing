using System.Collections.Generic;

namespace OclPlatform
{
    public class UnitsInfo
    {
        public int Index { get; private set; }
        public int DeviceCount { get; private set; }
        public string Name { get; private set; }
        public string Vendor { get; private set; }
        public string OpenCLVersion { get; private set; }
        public List<Device> DeviceList { get; private set; }

        public UnitsInfo(Emgu.CV.Ocl.PlatformInfo info, int index)
        {
            Index = index;
            DeviceCount = info.DeviceNumber;
            Name = info.Name;
            Vendor = info.Vendor;
            OpenCLVersion = info.Version;

            DeviceList = new List<Device>();
            for (int i = 0; i < info.DeviceNumber; i++)
                DeviceList.Add(new Device(info.GetDevice(i), i));
        }
    }
}
