namespace FakeScaner.Models;
public class DeviseInfo : IDeviceInfo
{
    public List<ICpuData> CpuData { get; set; }
    public List<IRamData> RamData { get ; set; }
}
