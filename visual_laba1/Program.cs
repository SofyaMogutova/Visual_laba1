using System;

namespace laba1_visual
{
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int[] order = new int[n]; //кассы
            int sum = 0, max = 0; //общее время прохождения/максимальное значение времени покупателей
            for (int i = 0; i < n; i++)
            {
                order[i] = customers[i];
            } //"подведение" первых покупателей к кассам
            int tmp = n;
            while (tmp < customers.Length)
            {
                int min = order[0];
                for (int i = 0; i < n; i++)
                {
                    if (order[i] < min)
                    {
                        min = order[i];
                    }
                }//ищем человека с самым минимальным временем

                sum += min;
                for (int i = 0; i < n; i++)
                {
                    order[i] -= min;
                }//вычитаем из всех покупателей время

                for (int i = 0; i < n; i++)
                {
                    if (order[i] == 0)
                    {
                        order[i] = customers[tmp];
                        tmp++;
                    }
                }//заполнение свободных касс
            }
            for (int i = 0; i < n; i++)
            {
                if (order[i] > max)
                {
                    max = order[i];
                }
            }//ищем человека с самым максимальным временем
            sum += max;
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] check1 = { 5, 3, 4 };
            Console.Write("([5,3,4], 1). Результат: ");//ответ должен быть 12
            Console.WriteLine(HW1.QueueTime(check1, 1));
            int[] check2 = { 10, 2, 3, 3 };
            Console.Write("([10,2,3,3], 2). Результат: ");//ответ должен быть 10
            Console.WriteLine(HW1.QueueTime(check2, 2));
            int[] check3 = { 2, 3, 10 };
            Console.Write("([2,3,10], 2). Результат: ");//ответ должен быть 12
            Console.WriteLine(HW1.QueueTime(check3, 2));
            int[] check4 = { 3, 3, 2, 8 };
            Console.Write("([3,3,2,8], 2). Результат: ");//ответ должен быть 11
            Console.WriteLine(HW1.QueueTime(check4, 2));
        }
    }
}
