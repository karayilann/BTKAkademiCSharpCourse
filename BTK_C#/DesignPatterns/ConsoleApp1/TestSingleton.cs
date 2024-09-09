using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class TestSingleton : MySingletonCode<TestSingleton>
    {
        public void Save()
        {
            Console.WriteLine("Saved by MySingleton Script");
        }

        public void TestSingletonNew(string threadName)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{threadName}: CustomerManager Instance HashCode: {this.GetHashCode()}");
            }
        }

    }
}
