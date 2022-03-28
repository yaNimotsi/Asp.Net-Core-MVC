using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadInWPF
{
    internal class MyListToWorkWithThreads<T>
    {
        private static object lockObject = new object();
        public List<T> DataList = new List<T>();
        
        public void Add(T item)
        {
            lock(lockObject)
            {
                DataList.Add(item);
            }
        }
    }
}
