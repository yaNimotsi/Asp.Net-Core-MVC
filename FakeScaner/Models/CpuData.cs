using FakeSkaner.Models.Interface;

namespace FakeSkaner.Models
{
    internal class CpuData : ICpuData
    {
        public int Percent { get; set; }

        public int Threads { get; set; }

        public bool Error { get; set; }
    }
}

