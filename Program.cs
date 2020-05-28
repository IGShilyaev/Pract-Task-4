using System;

namespace Pract_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите требуемую точность вычислений");
            double eps = EnterDoubleNumber();
            double lowBound = 0;
            double upBound = 2;
            double res;
            if (Math.Abs(ValueOfFunction(lowBound)) <= eps) res = lowBound;
            else if (Math.Abs(ValueOfFunction(upBound)) <= eps) res = upBound;
            else res = FunctionRoot(lowBound, upBound, eps);
            Console.WriteLine($"Результат вычисления значения корня ур-я (x+ln(x+0.5)-0.5=0) с точностью {eps} :");
            Console.WriteLine(res);
        }

        static double FunctionRoot(double left, double right, double eps)
        {
            bool stop = false;
            double root = 0;
            do
            {
                double x = (left + right) / 2.0;
                double y = ValueOfFunction(x);
                if (Math.Abs(y) <= eps) { root = x; stop = true; }
                else if(y*ValueOfFunction(left)<=0) { right = x; }
                else { left = x; }
            } while (!stop);
            return root;
        }

        static double ValueOfFunction(double x)
        {
            return (x + Math.Log(x + 0.5) - 0.5);
        }


        static double EnterDoubleNumber()
        {
            bool ok = false;
            double n;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n)&&(n>0);
                if (!ok) { Console.Write("Ошибка! Не удалось преобразовать введенное значение в положительное действительное число. Введите другое значение: "); }
            } while (!ok);
            return n;
        }

    }
}
