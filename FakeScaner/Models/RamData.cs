using FakeScaner.Models;

namespace FakeScaner;
internal class RamData : IRamData
{
    public int FreeMem {get; set;}

    public int TotalMem { get; set; }

    public bool Error { get; set; }
}
