using System;
using System.Threading;
using SingletonDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(() => TestSingletonPattern("Thread 1"));
        Thread thread2 = new Thread(() => TestSingletonPattern("Thread 2"));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Test tamamlandı.");
    }

    static void TestSingletonPattern(string threadName)
    {
        var testSingleton = TestSingleton.Instance;
        testSingleton.TestSingletonNew(threadName);

        var customerManager = new CustomerManager();
        customerManager.TestSingleton(threadName);
    }
}