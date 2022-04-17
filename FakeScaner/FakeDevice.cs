using FakeScaner.Models;

using System.Reflection;

namespace FakeScaner;
public class FakeDevice : IScanerData
{
    private List<ICpuData> _cpuDataList;
    private List<IRamData> _rumDataList;

    public List<ICpuData> CpuDaataList => _cpuDataList;
    public List<IRamData> RumDaataList => _rumDataList;

    public IDeviceInfo ScanAndSave()
    {
        CpuScan();
        RamScan();

        var deviceInfo = new DeviseInfo()
        {
            CpuData = CpuDaataList,
            RamData = RumDaataList,
        };

        return deviceInfo;
    }

    private void CpuScan()
    {
        _cpuDataList = new List<ICpuData>();

        var random = new Random();

        for(int i = 0; i < 100; i++)
        {
            _cpuDataList.Add(new CpuData()
            {
                Percent = random.Next(100),
                Threads = random.Next(12),
                Error = random.Next(2) == 1
            }) ;
        }
    }

    private void RamScan()
    {
        _rumDataList = new List<IRamData>();

        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            _rumDataList.Add(new RamData()
            {
                FreeMem = random.Next(32000),
                TotalMem = 32000,
                Error = random.Next(2) == 1
            });
        }
    }
}

