using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalysisHypotheses
{
    static class Functions
    {
        //Функція Лапласа (Ф(х)). Значення функції завантажуються з файлу 
        public static double Laplase(double x) 
        {
            bool negate = false;
            x = Math.Round(x, 2);

            if(-5 <= x && x <= 5)
            {
                if(x < 0)
                {
                    negate = true;
                    x *= -1;
                }

                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/lib/Laplase.txt");
                string str = "";
                string str2 = "";

                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    str2 = str.Trim().Substring(0, 4);
                    if (x == Convert.ToDouble(str2)) break;
                }
                str2 = str.Trim().Substring(5, 7);
                
                if(!negate) return Convert.ToDouble(str2);
                else return -1 * Convert.ToDouble(str2);
            }

            else if(x > 5 || x < -5)
            {
                if (x < 0) return -0.5;
                else return 0.5;
            }

            else return -1;
        }

        //Функція Пірсона (Хі квадрат). Значення функції завантажуються з файлу 
        public static double Pirson(int l, double a)
        {
            string filename = "";

            if (a == 0.01) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.01.txt";
            else if (a == 0.025) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.025.txt";
            else if (a == 0.05) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.05.txt";
            else if (a == 0.1) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.1.txt";
            else if (a == 0.25) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.25.txt";
            else if (a == 0.5) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.5.txt";
            else if (a == 0.75) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.75.txt";
            else if (a == 0.9) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.9.txt";       
            else if (a == 0.95) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.95.txt";
            else if (a == 0.975) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.975.txt";
            else if (a == 0.99) filename = Directory.GetCurrentDirectory() + "/lib/Pirson_0.99.txt";

            StreamReader sr = new StreamReader(filename);
            string str = "";
            string str2 = "";

            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                str2 = str.Trim().Substring(0, 2);
                if (l == Convert.ToInt32(str2)) break;
            }
            str2 = str.Trim().Substring(3, 8);

            return Convert.ToDouble(str2);
        }

        //Функція обчислення факторіалу
        public static int Factorial(int x)
        {
            int result = 1;
            if (x == 0 || x == 1) return result;
            else if (x < 0) throw new Exception("Параметр має бути більшим нуля!");
            else
            {
                for (var i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

    }
}
