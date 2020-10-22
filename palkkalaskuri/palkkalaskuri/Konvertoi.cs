using System;
using System.Collections.Generic;
using System.Text;

namespace palkkalaskuri
{
    public static class Konvertoi
    {

        public static dynamic saaArvo<T>(string x)
        {
            bool y = false;
            do
            {
                try
                {
                    if (typeof(T) == typeof(int))
                        return int.Parse(x);
                    else if (typeof(T) == typeof(double))
                        return double.Parse(x);
                    y = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    x = Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    x = Console.ReadLine();
                }
            } while (y == false);

            return "";
        }
    }
}
