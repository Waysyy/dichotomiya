using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing.Drawing2D;
using org.mariuszgromada.math.mxparser;


namespace grahpics
{
    class Class1
    {

        static void dichotomya(string[] args)
        {
            //погрешность вычисления
            const double epsilon = 1e-10;
            double a, b;
            //интервал [0.5,1.5].
            a = 0.5;
            b = 1.5;
            while (b - a > epsilon)
            {
                double c = (a + b) / 2;
                if (f(b) * f(c) < 0)
                    a = c;
                else
                    b = c;
            }
            //найденное значение x в нуле функции
            Console.WriteLine((a + b) / 2);
        }

        static double f(double x)
        {
            //ваша функция F(x)=4sin(3x-1)-(x в степени корень квадратный из 2)+1
            double tmp = Math.Pow(2, 0.5); //квадратный корень из 2
            return 4 * Math.Sin(3 * x - 1) - Math.Pow(x, tmp) + 1;
        }

    }
}
