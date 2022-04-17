using FakeScaner.Models;

namespace FakeScaner;
public interface IDeviceInfo
{
    List<ICpuData> CpuData { get; set; }
    List<IRamData> RamData { get; set; }
}
