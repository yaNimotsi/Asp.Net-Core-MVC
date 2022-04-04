using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolV3
{
    internal class UserTask
    {
        public Guid Id { get; set; }
        public Delegate? LinkToTask { get; set; }
    }
}
