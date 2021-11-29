using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParralelProgrammingExamples
{
    class Program
    {
        static void Main()
        {
            Thread[] th = new Thread[10];
            var dep = new Dep(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(dep.DoSomeTransactions));
                th[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                th[i].Start();
            }
            Console.Read();
        }
    }
    class Dep
    {
        private Object Lock = new Object();
        int sal;
        Random r = new Random();
        public Dep(int initial)
        {
            sal = initial;
        }
        int Withdraw(int amount)
        {

            if (sal < 0)
            {
                throw new Exception("Negative Balance");
            }

            lock (Lock)
            {
                if (sal >= amount)
                {
                    Console.WriteLine("salary before Withdrawal :  " + sal);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    sal = sal - amount;
                    Console.WriteLine("salary after Withdrawal  :  " + sal);
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }
        public void DoSomeTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

}


