using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMicroThreadPool
{
    public class TaskInfo
    {
        public Guid Id;
        public Delegate LinkToMethod;
    }
}
