using FakeScaner;

namespace SkanerToFakeSkaner
{
    internal class GetOutputData
    {
        public byte[] OutputByteArr { get; set; }

        public GetOutputData()
        {
            var outputData = new OutputData();
            OutputByteArr = outputData.GetDeviceSaveDataState();
        }
    }
}
