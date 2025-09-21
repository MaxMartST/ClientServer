record class MyThread
{
    public string NameThread { get; init; } = "Print_10";
    public int Start { get; init; } = 1;
    public int End { get; init; } = 10;

    public void Run()
    {
        Thread.CurrentThread.Name = NameThread;

        for (int i = Start; i <= End; i++)
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Thread t0 = new Thread(new MyThread().Run);
        Thread t1 = new Thread(new MyThread { NameThread = "A", Start = 6, End = 12 }.Run);

        t0.Start();
        t1.Start();
    }
}