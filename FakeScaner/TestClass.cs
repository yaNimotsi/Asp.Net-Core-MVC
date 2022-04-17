using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeScaner
{
    public interface IScannerDevice
    {
        Stream Scan();
    }
    public sealed class ScannerContext
    {
        //Интерфейса девайса для сканирования
        private readonly IScannerDevice _device;
        //Интерфейс выполнения сканирования
        private IScanOutputStrategy _currentStrategy;
        public ScannerContext(IScannerDevice device)
        {
            _device = device;
        }

        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
        }
        public void Execute(string outputFileName = "")
        {
            if (_device is null)
            {
                throw new ArgumentNullException("Device can not be null");
            }
            if (_currentStrategy is null)
            {
                throw new ArgumentNullException("Current scan strategy can not be null");
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = Guid.NewGuid().ToString();
            }
            _currentStrategy.ScanAndSave(_device, outputFileName);
        }
    }
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string
        outputFileName);
    }
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string
        outputFileName)
        {
            //do pdf output
        }
    }
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string
        outputFileName)
        {
            //do image outptut
        }
    }
}