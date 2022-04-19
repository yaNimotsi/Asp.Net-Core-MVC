namespace SkanerToFakeSkaner.Models.Interface
{
    public interface ICpuData
    {
        int Percent { get; }
        int Threads { get; }
        bool Error { get; }
    }
}


