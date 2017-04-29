using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

//Структура, що являє собою інтервал, де а - початок інтервалу, b - кінець
//інтервалу, с - середина інтервалу, n - частота виникнення дякої події на даному інтервалі.
public struct IntervalVariant
{
    public double a, b, x;
    public int n;

    public IntervalVariant(double A, double B, int N)
    {
        a = A;
        b = B;
        n = N;
        x = (A + B) / 2;
    }
}

namespace AnalysisHypotheses
{
    //Клас РЯД (Генеральна сукупність), що міcтить в собі змінні (список) дискретного і інтервального рядів.
    static class Row
    {
        private static List<IntervalVariant> Values = new List<IntervalVariant>();
        private static double alpha;

        //Додання елементу до генеральної сукупності
        public static void AddToRow(IntervalVariant obj)
        {
            if (obj.n < 0) throw new Exception("Частота не може приймати від'ємні значення!\n");

            if (obj.a != obj.b && Row.Values.Exists(x => x.a == obj.a) && Row.Values.Exists(x => x.b == obj.b))
                throw new Exception("Даний інтервал (" + obj.a + "; " + obj.b + ") існує!\n");
            else if (obj.a == obj.b && Row.Values.Exists(x => x.x == obj.x))
                throw new Exception("Дана дискретна величина (" + obj.x + ") існує!\n");

            foreach(var i in Values)
            {
                if ((obj.a > i.a && obj.a < i.b) || (obj.b > i.a && obj.b < i.b)) 
                    throw new Exception("Даний інтервал перетинається з інтервалом (" + i.a + ";" + i.b + ")");
            }

            Values.Add(new IntervalVariant(obj.a, obj.b, obj.n));
        }

        //Отримання елементу генеральної сукупності по індексу
        public static IntervalVariant GetByIndex(int index)
        {
            if (index >= Values.Count) throw new Exception("Індекс виходить за межі розміру списку!");
            return Values[index];
        }

        //Отримання кількості едементів генеральної сукупності
        public static int GetCount()
        {
            return Values.Count;
        }

        //Видалення елементу генеральної сукупності по індексу
        public static void RemoveAt(int index)
        {
            Values.RemoveAt(index);
        }

        //Очищення генерального ряду
        public static void ClearRow()
        {
            Values.Clear();
        }
        
        //Встановлення значення рівня значущості
        public static void SetAlpha(double alp)
        {
            alpha = alp;
        }

        //Отримання значення рівня значущості
        public static double GetAlpha()
        {
            return alpha;
        }

        //Отримання об'єму вибірки
        public static int GetSampleSize()
        {
            int N = 0;

            foreach (var i in Values)
                N += i.n;

            return N;
        }

        //Обчислення вибірковового середнього
        public static double GetSampleMean()
        {
            double X = 0;

            foreach (var i in Values)
                X += i.x * i.n;
      
            return X / GetSampleSize();;
        }

        //Отримання критичного значення Хі квадрат
        public static double GetHi2Crit(int countOfParam)
        {
            //Hi2crit
            int l = Row.Values.Count - countOfParam - 1;
            return Functions.Pirson(l, Convert.ToDouble(alpha));
        }

        //Обчислення вибіркової дисперсії
        public static double GetSampleVariance()
        {
            double X = GetSampleMean(), S2 = 0;
            int N = GetSampleSize();

            foreach (var i in Row.Values)
                S2 += (i.x - X) * (i.x - X) * i.n;

            return S2 / N;
        }

        //Перевірка гіпотези про нормальний закон 
        public static void CheckNormalLaw()
        {
            ImportAndExportFiles.Clear();

            ImportAndExportFiles.WriteHTML("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/></head><body>");
            
            ImportAndExportFiles.WriteHTML("<h2>Перевірка гіпотези про розподіл випадкової величини за нормальним законом розподілу:</h2>");
            ImportAndExportFiles.WriteText("Перевірка гіпотези про розподіл випадкової величини за нормальним законом розподілу:");
            
            ImportAndExportFiles.WriteHTML("<h3>Результати обчислень:</h3>");
            ImportAndExportFiles.WriteText("Результати обчислень:\n");

            double X = GetSampleMean(), S = Math.Sqrt(GetSampleVariance());
            int N = GetSampleSize();

            ImportAndExportFiles.WriteHTML("N = " + N + "</br>");
            ImportAndExportFiles.WriteText("N = " + N);
            
            ImportAndExportFiles.WriteHTML("X = " + Math.Round(X, 4) + "</br>");
            ImportAndExportFiles.WriteText("X = " + Math.Round(X, 4));
           
            ImportAndExportFiles.WriteHTML("S = " + Math.Round(S, 4) + "</br></br>");
            ImportAndExportFiles.WriteText("S = " + Math.Round(S, 4) + "\n");

            //Обчислення теоретичних ймовірностей, що будуть заноситися в окремий список данних.
            ImportAndExportFiles.WriteHTML("<table border=\"1\" style=\"width:90%;\">");
            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>[ai; ai+1]</td>");
            var str = "\"[ai; ai+1]\"";

            foreach (var i in Row.Values)
            {
                ImportAndExportFiles.WriteHTML("<td>(" + i.a + "; " + i.b + ")</td>");
                str += ";\"(" + i.a + "; " + i.b + ")\"";
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>ni</td>");
            str = "ni";

            foreach (var i in Row.Values)
            {
                ImportAndExportFiles.WriteHTML("<td>" + i.n + "</td>");
                str += ";" + i.n;
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            var TempCalculation = new List<double>();

            if (Row.Values[0].a == Row.Values[0].x)
            {
                //pi = fi(...)  
                foreach (var i in Row.Values)
                    TempCalculation.Add((1/(S*Math.Sqrt(2*Math.PI)))*Math.Exp(-Math.Pow(i.x-X,2)/(2*S*S)));
            }
            else
            {
                //pi = Ф[(b-X)/S] - Ф[(a-X)/S] 
                foreach (var i in Row.Values)
                    TempCalculation.Add(Functions.Laplase((i.b - X) / S) - Functions.Laplase((i.a - X) / S));
            }

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>pi</td>");
            str = "pi";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            //ni=n*pi
            for (var i = 0; i < TempCalculation.Count; i++)
                TempCalculation[i] = TempCalculation[i] * N;

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>ni = pi * n</td>");
            str = "ni = pi * n";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            //Hi2
            for (var i = 0; i < TempCalculation.Count; i++)
                TempCalculation[i] = Math.Pow(Row.Values[i].n - TempCalculation[i], 2) / TempCalculation[i];

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>((ni-ni')^2)/ni'</td>");
            str = "((ni-ni')^2)/ni'";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteHTML("</table>");
            ImportAndExportFiles.WriteText(str);

            double Hi2 = 0;
            foreach (var i in TempCalculation)
                Hi2 += i;

            ImportAndExportFiles.WriteHTML("</br>Hi2 = " + Math.Round(Hi2, 4));
            ImportAndExportFiles.WriteText("Hi2 = " + Math.Round(Hi2, 4));

            double Hi2Crit = GetHi2Crit(2);
            ImportAndExportFiles.WriteHTML("</br>Hi2Crit = " + Math.Round(Hi2Crit, 4));
            ImportAndExportFiles.WriteText("Hi2Crit = " + Math.Round(Hi2Crit, 4));

            if (Hi2 < Hi2Crit)
            {
                ImportAndExportFiles.WriteHTML("</br><h3>Гіпотеза про розподіл випадкової величини за нормальним законом розподілу приймається.</h3>");
                ImportAndExportFiles.WriteText("Гіпотеза про розподіл випадкової величини за нормальним законом розподілу приймається.");
            }
            else
            {
                ImportAndExportFiles.WriteHTML("</br><h3>Гіпотеза про розподіл випадкової величини за нормальним законом розподілу не приймається.</h3>");
                ImportAndExportFiles.WriteText("Гіпотеза про розподіл випадкової величини за нормальним законом розподілу не приймається.");
            }

            ImportAndExportFiles.WriteHTML("</body></html>");
        }

        //Перевірка гіпотези про закон Пуассона 
        public static void CheckPuassonLaw()
        {
            ImportAndExportFiles.Clear();

            ImportAndExportFiles.WriteHTML("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/></head><body>");

            ImportAndExportFiles.WriteHTML("<h2>Перевірка гіпотези про розподіл випадкової величини за законом Пуассона розподілу:</h2>");
            ImportAndExportFiles.WriteText("Перевірка гіпотези про розподіл випадкової величини за законом Пуассона розподілу:");

            ImportAndExportFiles.WriteHTML("<h3>Результати обчислень:</h3>");
            ImportAndExportFiles.WriteText("Результати обчислень:\n");

            double X = GetSampleMean(), S2 = GetSampleVariance();
            int N = GetSampleSize();

            ImportAndExportFiles.WriteHTML("N = " + N + "</br>");
            ImportAndExportFiles.WriteText("N = " + N);

            ImportAndExportFiles.WriteHTML("X = " + Math.Round(X, 4) + "</br>");
            ImportAndExportFiles.WriteText("X = " + Math.Round(X, 4));

            ImportAndExportFiles.WriteHTML("S2 = " + Math.Round(S2, 4) + "</br>");
            ImportAndExportFiles.WriteText("S2 = " + Math.Round(S2, 4));

            double lambda = (X + S2) / 2;
            ImportAndExportFiles.WriteHTML("lambda = " + Math.Round(lambda, 4) + "</br></br>");
            ImportAndExportFiles.WriteText("lambda = " + Math.Round(lambda, 4) + "\n");

            //Обчислення теоретичних ймовірностей, що будуть заноситися в окремий список данних.
            ImportAndExportFiles.WriteHTML("<table border=\"1\" style=\"width:90%;\">");
            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>[ai; ai+1]</td>");
            var str = "\"[ai; ai+1]\"";

            foreach (var i in Row.Values)
            {
                ImportAndExportFiles.WriteHTML("<td>(" + i.a + "; " + i.b + ")</td>");
                str += ";\"(" + i.a + "; " + i.b + ")\"";
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>ni</td>");
            str = "ni";

            foreach (var i in Row.Values)
            {
                ImportAndExportFiles.WriteHTML("<td>" + i.n + "</td>");
                str += ";" + i.n;
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            var TempCalculation = new List<double>();

            //pi = [exp(-lam)*pow(lam, k)]/k!
            foreach (var i in Row.Values)
                TempCalculation.Add((Math.Exp(-lambda)*Math.Pow(lambda, i.x))/Functions.Factorial(Convert.ToInt32(i.x)));

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>pi</td>");
            str = "pi";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            //ni=n*pi
            for (var i = 0; i < TempCalculation.Count; i++)
                TempCalculation[i] = TempCalculation[i] * N;

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>ni = pi * n</td>");
            str = "ni = pi * n";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteText(str);

            for (var i = 0; i < TempCalculation.Count; i++)
                TempCalculation[i] = Math.Pow(Row.Values[i].n - TempCalculation[i], 2) / TempCalculation[i];

            ImportAndExportFiles.WriteHTML("<tr>");

            ImportAndExportFiles.WriteHTML("<td>((ni-ni')^2)/ni'</td>");
            str = "((ni-ni')^2)/ni'";

            for (var i = 0; i < TempCalculation.Count; i++)
            {
                ImportAndExportFiles.WriteHTML("<td>" + Math.Round(TempCalculation[i], 4) + "</td>");
                str += ";" + Math.Round(TempCalculation[i], 4);
            }
            ImportAndExportFiles.WriteHTML("</tr>");
            ImportAndExportFiles.WriteHTML("</table>");
            ImportAndExportFiles.WriteText(str);

            double Hi2 = 0;
            foreach (var i in TempCalculation)
                Hi2 += i;

            ImportAndExportFiles.WriteHTML("</br>Hi2 = " + Math.Round(Hi2, 4));
            ImportAndExportFiles.WriteText("Hi2 = " + Math.Round(Hi2, 4));

            double Hi2Crit = GetHi2Crit(2);
            ImportAndExportFiles.WriteHTML("</br>Hi2Crit = " + Math.Round(Hi2Crit, 4));
            ImportAndExportFiles.WriteText("Hi2Crit = " + Math.Round(Hi2Crit, 4));

            if (Hi2 < Hi2Crit)
            {
                ImportAndExportFiles.WriteHTML("</br><h3>Гіпотеза про розподіл випадкової величини за законом Пуассона приймається.</h3>");
                ImportAndExportFiles.WriteText("Гіпотеза про розподіл випадкової величини за законом Пуассона приймається.");
            }
            else
            {
                ImportAndExportFiles.WriteHTML("</br><h3>Гіпотеза про розподіл випадкової величини за законом Пуассона не приймається.</h3>");
                ImportAndExportFiles.WriteText("Гіпотеза про розподіл випадкової величини за законом Пуассона не приймається.");
            }

            ImportAndExportFiles.WriteHTML("</body></html>");
        }
    }
}
