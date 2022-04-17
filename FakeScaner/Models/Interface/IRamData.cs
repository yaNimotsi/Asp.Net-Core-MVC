namespace FakeScaner.Models;
public interface IRamData
{
    int FreeMem { get; }
    int TotalMem { get; }
    bool Error { get; }
}
