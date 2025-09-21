static void PrintA()
{
    for (int i = 1; i <= 100; i++)
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
}
static void PrintB(object? p)
{
    if (p is Thread t)
    {
        while (t.ThreadState == ThreadState.Unstarted) 
            Thread.Yield();

        t.Join();
    }

    for (int i = 1; i <= 100; i++)
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
}

Thread t0 = new Thread(PrintA) { Name = "A" };
Thread t1 = new Thread(PrintB) { Name = "B" };

t1.Start(t0);
Thread.Sleep(1000);
t0.Start();