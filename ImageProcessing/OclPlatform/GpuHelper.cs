using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Ocl;

namespace OclPlatform
{
    public static class GpuHelper
    {
        #region Static Properties
        static public bool HaveOpenCL { get => CvInvoke.HaveOpenCL; }
        static public bool UseOpenCL { get => CvInvoke.UseOpenCL; set => CvInvoke.UseOpenCL = value; }
        static public bool HaveCompatibleHardware { get => CvInvoke.HaveOpenCLCompatibleGpuDevice; }
        #endregion

        /// <summary>
        /// Sets the default device for EmguCV GPU computations
        /// </summary>
        /// <param name="devicePointer">native device pointer</param>
        /// <returns></returns>
        public static bool SetDefaultDevice(string deviceName)
        {
            foreach (var pl in PlatformInformation)
            {
                foreach (var dev in pl.DeviceList)
                {
                    if (deviceName == dev.Name)
                    {
                        Emgu.CV.Ocl.Device.Default.Set(dev.Pointer);
                        return true;
                    }
                }
            }

            return false;
        }

        #region Platform Information
        private static List<UnitsInfo> info = new List<UnitsInfo>();
        public static List<UnitsInfo> PlatformInformation
        {
            get
            {
                if (info.Count < 1)
                    GetPlatformInfo();
                return info;
            }
            private set => info = value;
        }
        #endregion

        #region Private Functions
        private static void GetPlatformInfo()
        {
            info.Clear();
            using (var infos = OclInvoke.GetPlatformsInfo())
            {
                info.Clear();

                for (int i = 0; i < infos.Size; i++)
                    info.Add(new UnitsInfo(infos[i], i));
            }
        }
        #endregion
    }
}
