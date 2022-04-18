using System.Collections.Concurrent;

namespace ThreadPoolV3
{
    internal class CustomThreadPool
    {
        private const int MinPoolSize = 3;
        //private const int MaxPoolSize = 5;
        public ConcurrentQueue<UserTask> Queue;
        private List<ItemToThread> ListThreads;

        private Thread schedulerThread;

        private static object listObjectLock = new object();

        public CustomThreadPool()
        {
            Initialize();
        }

        private void Initialize()
        {
            Queue = new ConcurrentQueue<UserTask>();
            ListThreads = new List<ItemToThread>();

            MinInitialize();

            schedulerThread = new Thread(() =>
            {
                do
                {
                    if (Queue.Count > 0)
                    {
                        Queue.TryPeek(out var userTask);
                        var thread = ListThreads.Where(item => item.MyThreadState.Equals(MyThreadState.Notstarted)).FirstOrDefault();
                        if (thread != null)
                        {
                            thread.UserTask = userTask;
                            thread.ThreadInPool.IsBackground = true;
                            thread.ThreadInPool.Start();
                            Queue.TryDequeue(out userTask);
                        }
                    }

                    Thread.Sleep(1000);
                }while(true);
                
            });
            schedulerThread.Start();
            schedulerThread.IsBackground = true;
        }

        private void MinInitialize()
        {
            for (int i = 0; i < MinPoolSize; i++)
            {
                ListThreads.Add(new ItemToThread()
                {
                    ThreadInPool = new Thread(() => { })
                    {
                        IsBackground = true,
                        Name = $"PoolThread {i}"
                    },
                    MyThreadState = MyThreadState.Notstarted,
                    UserTask = new UserTask()
                    {
                        Id = Guid.NewGuid()
                    }
                });
            }
        }

        public void QueueUserWorkItem(Delegate task)
        {
            var userTask = new UserTask()
            {
                Id = Guid.NewGuid(),
                LinkToTask = task
            };
            Queue.Enqueue(userTask);
        }

        private void CancelUserTask(Guid idToCancel)
        {
            lock (listObjectLock)
            {
                var itemFromThreadList = ListThreads.Where(item => item.UserTask.Id == idToCancel).First<ItemToThread>();

                if (itemFromThreadList.MyThreadState == MyThreadState.Aborted) return;

                if(!IsThreadComplatedNormaly(itemFromThreadList))
                {
                    itemFromThreadList.ThreadInPool.Interrupt();
                    itemFromThreadList.ThreadInPool.Priority = ThreadPriority.BelowNormal;
                    itemFromThreadList.ThreadInPool.IsBackground = true;
                }
                else
                {
                    itemFromThreadList.MyThreadState = MyThreadState.Notstarted;
                    itemFromThreadList.UserTask.LinkToTask = null;
                }
            }
        }

        private bool IsThreadComplatedNormaly(ItemToThread itemThread)
        {
            switch (itemThread.ThreadInPool.ThreadState)
            {
                case (ThreadState.Running):
                case (ThreadState.Unstarted):
                case (ThreadState.WaitSleepJoin):
                case (ThreadState.Background):
                    itemThread.MyThreadState = MyThreadState.Processing;
                    return true;
                default:

                    itemThread.MyThreadState = MyThreadState.Aborted;

                    return false;
            }
        }
    }
}