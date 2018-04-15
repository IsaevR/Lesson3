using System;

namespace Parser2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var s = Console.ReadLine();                // записывает строку в переменной "s"
                var datestart = DateTime.Now;              // сохраняет текущее время в переменной "datestart" 
                Console.WriteLine(Parse(s));
                Console.WriteLine("\nВремя выполнения вычислений");
                Console.WriteLine(DateTime.Now - datestart); // вычитает время старта программы от времени 
                                                             // его завершения (время выполнения)
            }
        }
            /// <summary>
            /// метод Parse выполняет сложение и вычитание
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            static int Parse(string s)
            {
                int index = 0;
                int num = MultDiv(s, ref index);
                while (index < s.Length)
                {
                    if (s[index] == '+')
                    {
                        index++;
                        int b = MultDiv(s, ref index);
                        num += b;
                    }
                    else if (s[index] == '-')
                    {
                        index++;
                        int b = MultDiv(s, ref index);
                        num -= b;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        return 0;
                    }
                }
                return num;
            }
            /// <summary>
            /// Метод MultDiv выполняет умножение и деление
            /// И возвращает "num" - значение с ответом
            /// выполненного действия 
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            static int MultDiv(string s, ref int index)
            {
                int num = Factor(s, ref index);
                while (index < s.Length)
                {
                    if (s[index] == '*')
                    {
                        index++;
                        int b = Factor(s, ref index);
                        num *= b;
                    }
                    else if (s[index] == '/')
                    {
                        index++;
                        int b = Factor(s, ref index);
                        num /= b;
                    }
                    else
                    {
                        return num;
                    }
                }
                return num;
            }
        /// <summary>
        /// метод "Factor" вычисляет факториал. Например 5!  a=1*2*3*4*5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int Factor(string s, ref int index)
        {
            int num = Num(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '!')
                {
                    int res = 1;
                    for (int i = 1; i <= num; ++i)
                        res *= i;
                    num = res;
                }
                else
                {
                    return num;
                }
                index++;
            }
            return num;
        }
        /// <summary>
        /// метод Num определяет цыфровые символы в строке 
        /// до знака действия и возвращает переменную с числовым
        /// значением в метод "Parse" в качестве аргумента
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        static int Num(string s, ref int i)
            {
                string buff = "0";
                for (; i < s.Length && char.IsDigit(s[i]); i++)
                {
                    buff += s[i];
                }
                return int.Parse(buff);//01
            }

       
    }
}
