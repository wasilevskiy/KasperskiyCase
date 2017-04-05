using System;
using System.Collections;

namespace TwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int minValue = 0;
            int maxValue = 0;
            int Count = 0;
            PairsOfNumbers Pair = new PairsOfNumbers();
            //Считываем данные с клавиатуры
            bool isNormal = Pair.GetInfo(number, minValue, maxValue, Count);
            if (isNormal)
            {
                Hashtable table = new Hashtable();
                //Считаем, что массив не заполнен => заполняем его
                int[] array = Pair.InsertArr(minValue, maxValue, Count);
                Pair.FindPairs(array, table, number);
            }
            Console.ReadLine();
        }
    }
    public class PairsOfNumbers
    {
        public Hashtable FindPairs(int[] array, Hashtable table, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                int summ = number - element;
                if (table.ContainsKey(element))
                    Console.WriteLine("Число: {0} дают в сумме два элемента: {1} и {2}", number, element, table[element]);
                else if (!table.ContainsKey(summ))
                    table.Add(summ, element);
            }
            return table;
        }
        public int[] InsertArr(int minValue, int maxValue, int Count)
        {
            int[] array = new int[Count];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(minValue, maxValue);
            }
            return array;
        }

        public bool GetInfo(int num, int min, int max, int count)
        {
            try
            {
                Console.WriteLine("Введите искомое число:");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите минимальную границу: ");
                min = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите максимальную границу:");
                max = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество чисел:");
                count = int.Parse(Console.ReadLine());
                if (max < min)
                {
                    Console.WriteLine("Ошибка! Максимальное значение не может быть меньше минимального!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при вводе данных: " + ex.ToString());
                return false;
            }
            return true;
        }
    }
}

