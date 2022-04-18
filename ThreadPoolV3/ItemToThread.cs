namespace ThreadPoolV3
{
    internal class ItemToThread
    {
        public UserTask UserTask { get; set; }
        public Thread ThreadInPool { get; set; }
        public MyThreadState MyThreadState { get; set; }
    }
}
