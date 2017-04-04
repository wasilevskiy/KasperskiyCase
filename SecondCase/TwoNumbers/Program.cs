using System;
using System.Collections;

namespace TwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите искомое число:");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите минимальную границу: ");
            var minValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальную границу:");
            var maxValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество чисел:");
            var Count = int.Parse(Console.ReadLine());
            Hashtable table = new Hashtable();
            //Считаем, что массив не заполнен => заполняем его
            int[] array = InsertArr(minValue, maxValue, Count);

            for (int i = 0;i < array.Length;i++)
            {
                int element = array[i];
                int summ = number - element;
                if (table.ContainsKey(element))
                    Console.WriteLine(element + "," + table[element]);
                else if(!table.ContainsKey(summ))
                    table.Add(summ, element);
            }
            Console.ReadLine();
        }

        public static int[] InsertArr(int minValue,int maxValue, int Count)
        {
            int[] array = new int[Count];
            Random r = new Random();
            for(int i=0;i<array.Length;i++)
            {
                array[i] = r.Next(minValue, maxValue);
            }
            return array;
        }
    }
}
