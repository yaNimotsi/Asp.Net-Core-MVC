
using ThreadPoolV3;

var customThreadPool = new CustomThreadPool();

var korteg = Enumerable.Range(1, 100).Select(i => $"Task {i++}");

for (int i = 0; i < korteg.Count(); i++)
{
    customThreadPool.QueueUserWorkItem(() =>
    {
        Console.WriteLine(korteg.ElementAt(i));
    });
}

Console.ReadLine();
