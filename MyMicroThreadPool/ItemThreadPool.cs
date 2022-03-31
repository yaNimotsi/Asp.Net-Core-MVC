using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMicroThreadPool
{
    internal class ItemThreadPool
    {
        public int id;
        public Thread thread;
        public bool isActive;
    }
}
