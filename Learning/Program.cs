using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("введите выражение");
                Console.ResetColor();
                var test = Console.ReadLine();
                Console.Write($"= {Calc.Calculate(test)}");
                Console.WriteLine();
            }
        }
    }

    public class Calc
    {

        public static double Calculate(string expression)
        {
            var sCnt = 0;
            var ind = 0;
            var bs = false;
            var fsInd = -1;
            var lsInd = 0;

            foreach (var lex in expression)
            {
                if (lex == '(')
                {
                    sCnt++;
                    bs = true;
                    if(fsInd == -1) fsInd = ind;
                }

                if (lex == ')')
                {
                    lsInd = ind;
                    sCnt--;
                }

                if (lex == '+' && sCnt == 0)
                    return Calculate(expression.Substring(0, ind)) + Calculate(expression.Substring(ind + 1));

                if (lex == '-' && sCnt == 0)
                    return Calculate(expression.Substring(0, ind)) - Calculate(expression.Substring(ind + 1));

                //if (lex == '*' && sCnt == 0)
                //    return Calculate(expression.Substring(0, ind)) * Calculate(expression.Substring(ind + 1));

                //if (lex == '/' && sCnt == 0)
                //    return Calculate(expression.Substring(0, ind)) / Calculate(expression.Substring(ind + 1));

                if (sCnt != 0)
                {
                    ind++;
                    continue;
                }

                if(bs && ind == expression.Length-1)
                    return Calculate(expression.Substring(fsInd+1, lsInd - (fsInd + 1)));
               
                ind++;
            }
            return Convert.ToDouble(expression);
        }
    }
}
