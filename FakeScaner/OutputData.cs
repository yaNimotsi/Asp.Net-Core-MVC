using FakeSkaner;
using FakeSkaner.Models.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeScaner
{
    public class OutputData : IDataToOutSide
    {
        public byte[] GetDeviceSaveDataState()
        {

            var fakeDevice = new FakeDevice();

            if (!File.Exists(fakeDevice._pathToSave))
            {
                return null;
            }

            try
            {
                return File.ReadAllBytes(fakeDevice._pathToSave);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Прочитать документ не удалось {e.Message}");
                throw;
            }
            
        }
    }
}
