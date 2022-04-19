using FakeSkaner.Models;

using System.Text.Json;
using FakeSkaner.Models.Interface;

namespace FakeSkaner
{
    internal sealed class FakeDevice
    {
        public readonly string _pathToSave;

        private List<ICpuData> _cpuDataList;
        private List<IRamData> _rumDataList;

        private DeviseInfo _deviseInfo;

        public DeviseInfo DeviseInfo => _deviseInfo;

        //public List<ICpuData> CpuDataList => _deviseInfo.CpuData;
        //public List<IRamData> RumDataList => _deviseInfo.RamData;

        public FakeDevice()
        {
            _pathToSave = string.Concat((Environment.CurrentDirectory), @"\"
                , $"saveData {DateTime.Now:hh-mm}.txt");

            SkanAndSave();
        }

        public IDeviceInfo SkanAndSave()
        {
            CpuScan();
            RamScan();

            _deviseInfo = new DeviseInfo()
            {
                CpuData = _cpuDataList,
                RamData = _rumDataList
            };

            SaveToFile(_deviseInfo);

            return _deviseInfo;
        }

        private void SaveToFile(DeviseInfo deviseInfo)
        {
            var json = JsonSerializer.Serialize(deviseInfo);

            using var sw = new StreamWriter(_pathToSave);

            try
            {
                sw.Write(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Записать данные не удалось {e.Message}");
            }
        }

        private void CpuScan()
        {
            _cpuDataList = new List<ICpuData>();

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                _cpuDataList.Add(new CpuData()
                {
                    Percent = random.Next(100),
                    Threads = random.Next(12),
                    Error = random.Next(2) == 1
                });
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
                    FreeMem = random.Next(32768),
                    TotalMem = 32768,
                    Error = random.Next(2) == 1
                });
            }
        }
    }
}


