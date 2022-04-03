using System;
using System.Threading;

namespace MyMicroThreadPool
{
    public class TaskItem
    {
        public TaskInfo taskInfo;
        public Thread thread;
        public bool isFree;
        public Exception taskException;
    }
}