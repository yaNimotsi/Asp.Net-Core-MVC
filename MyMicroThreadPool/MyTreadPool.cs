using System.Collections.Concurrent;

namespace MyMicroThreadPool
{
    internal class MyTreadPool
    {
        private readonly int _minThread = 3;
        private const int CleanUpTimeOut = 50000;

        private ConcurrentQueue<TaskInfo> _taskInQueue;
        private List<TaskItem> _threadPool;
        public MyTreadPool()
        {
            StartInitialize();
        }

        private void StartInitialize()
        {
            _taskInQueue = new ConcurrentQueue<TaskInfo>();
            _threadPool = new List<TaskItem>();

            MinimalInitialize();

            var taskScheduler = new Thread(() =>
            {
                do
                {
                    while (_taskInQueue.Count > 0)
                    {
                        if (_taskInQueue.TryPeek(out var result))
                        {
                            var threadToTask = _threadPool.Where(item => item.taskInfo.Id == result.Id);
                            if (threadToTask.Any())
                            {
                                var currentThread = threadToTask.First();
                                if (currentThread.isFree)
                                {
                                    _taskInQueue.TryDequeue(out var removeTask);
                                }
                            }
                            else
                            {
                                var taskItem = new TaskItem()
                                {
                                    
                                }
                                AddTaskItemToThreadPool(taskItem);
                            }
                        }
                    }

                    Thread.Sleep(CleanUpTimeOut);
                } while (true);
                
            });

            taskScheduler.Priority = ThreadPriority.AboveNormal;
            taskScheduler.Start();
        }

        private void MinimalInitialize()
        {
            for (var i = 0; i < _minThread; i++)
            {
                var taskItem = new TaskItem()
                {
                    thread = new Thread(() => { })
                    {
                        IsBackground = true
                    },
                    taskInfo = new TaskInfo()
                    {
                        Id = Guid.NewGuid()
                    },
                    isFree = true
                };
                
                _threadPool.Add(taskItem);
            }
        }

        public TaskInfo UserTaskToQueue(Delegate task)
        {
            var taskInfo = new TaskInfo()
            {
                Id = Guid.NewGuid(),
                LinkToMethod = task
            };

            _taskInQueue.Enqueue(taskInfo);

            return taskInfo;
        }

        private void AddTaskItemToThreadPool(TaskItem task)
        {
            if (task.taskInfo.LinkToMethod == null) return;

            task.thread = new Thread(() =>
            {
                task.isFree = false;
            })
            {
                IsBackground = true
            };

            task.thread.Start();
            lock (_threadPool)
            {
                _threadPool.Add(task);
            }
        }

        /// <summary>
        /// Перевод флага потока в свободное положение если поток завершил работу
        /// </summary>
        /// <param name="idTaskToCancel"> id задачи для проверки состояния</param>
        private void CancelTask(Guid idTaskToCancel)
        {
            lock (_threadPool)
            {
                var taskItem = _threadPool.FirstOrDefault(task => task.taskInfo.Id == idTaskToCancel);

                if (taskItem == null) return;

                switch (taskItem.thread.ThreadState)
                {
                    case (ThreadState.Running):
                    case (ThreadState.Unstarted):
                    case (ThreadState.WaitSleepJoin):
                    case (ThreadState.Background):
                        taskItem.isFree = false;
                        break;
                    default:
                        taskItem.isFree = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Метод проверяет потоки в коллекции. Если поток завершил работу некорректно или был остановлен, то он удаляется из коллекции.
        /// Так же если кол-во потоков в коллекции меньше минимального значения, то потоки добавляются в коллекцию
        /// </summary>
        private void RemoveSpentThreads()
        {
            lock (_threadPool)
            {
                var activeThread = _threadPool.Where(item => item.thread.IsAlive).ToList();
            
                foreach (var taskItem in activeThread)
                {
                    _threadPool.Remove(taskItem);
                }

                var totalThread = _threadPool.Count;

                if (totalThread > _minThread)
                {
                    var filteredTask = _threadPool.Where(item => item.isFree).ToList();

                    foreach (var taskItem in filteredTask)
                    {
                        taskItem.thread.Priority = ThreadPriority.AboveNormal;
                        _threadPool.Remove(taskItem);
                        
                        totalThread--;

                        if (totalThread == _minThread) break;
                    }
                }

                while (_threadPool.Count < _minThread)
                {
                    var taskItem = new TaskItem()
                    {
                        thread = new Thread(() => { })
                        {
                            IsBackground = true
                        },
                        taskInfo = new TaskInfo()
                        {
                            Id = Guid.NewGuid()
                        },
                        isFree = true
                    };

                    _threadPool.Add(taskItem);
                }
            }
        }
    }
}
