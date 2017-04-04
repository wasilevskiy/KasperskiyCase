using System;
using System.Collections.Generic;
using System.Threading;

namespace FirstExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            SafeQueue<int> TestQueue = new SafeQueue<int>();
            Thread PushElement = new Thread(() => PopTest(20,TestQueue));
            Thread PopElement = new Thread(() => PushTest(20,TestQueue));
            PopElement.Start();
            PushElement.Start();
            Console.ReadLine();
        }
        static void PushTest(int n,SafeQueue<int> Queue)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++) 
            {
                Queue.Push(r.Next(1, 100));
            }
        }

        static void PopTest(int n,SafeQueue<int> Queue)
        {
            for (int i = 0; i < n; i++) 
            {
                Queue.Pop();
            }
        }
    }

    class SafeQueue<T>
    {
        private readonly Queue<T> queue;
        private readonly object thisLock;

        public SafeQueue()
        {
            queue = new Queue<T>();
            thisLock = new object();
        }
        public void Push(T element)
        {
            lock (thisLock)
            {
                queue.Enqueue(element);
                Console.WriteLine("push: {0}", element);
                Monitor.Pulse(thisLock);
            }
        }

        public T Pop()
        {
            lock(thisLock)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(thisLock);
                }
                T element = queue.Dequeue();
                Console.WriteLine("Pop:{0}", element);
                return element;
            }
        }
    }
}
