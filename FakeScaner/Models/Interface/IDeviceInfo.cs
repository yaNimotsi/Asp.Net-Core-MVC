namespace FakeSkaner.Models.Interface
{
    public interface IDeviceInfo
    {
        List<ICpuData> CpuData { get; set; }
        List<IRamData> RamData { get; set; }
    }
}

