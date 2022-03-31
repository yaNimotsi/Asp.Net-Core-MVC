using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMicroThreadPool
{
    internal class MyTreadPool
    {
        private int MinItem = 3;

        private ConcurrentQueue<WorkItemThreadPool> _queue = new ConcurrentQueue<WorkItemThreadPool>();
        private List<ItemThreadPool> _taskList = new List<ItemThreadPool>();
        public MyTreadPool()
        {
            Initializer();
        }

        /// <summary>
        /// Первичное создание и настройка пула
        /// </summary>
        private void Initializer()
        {

        }
    }
}
