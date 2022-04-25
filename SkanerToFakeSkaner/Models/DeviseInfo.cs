using SkanerToFakeSkaner.Models.Interface;

namespace SkanerToFakeSkaner.Models
{
    public class DeviseInfo : IDeviceInfo
    {
        public DeviseInfo()
        {
        }

        public List<ICpuData> CpuData { get; set; }
        public List<IRamData> RamData { get; set; }
    }
}

