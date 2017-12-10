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
        public class Priority
        {
            public string Lexem { get; set; }
            public int Level { get; set; }

            public Priority(string lexem, int level)
            {
                Lexem = lexem;
                Level = level;
            }

        }

        public List<Priority> LexemPriority { get; set; }

        public static double Calculate(string expression)
        {
            var sCnt = 0;
            var ind = 0;
            var bs = false;
            var fsInd = -1;
            var lsInd = 0;
            var needNeg = 1;

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

                if(ind == 0 &&lex == '-' )
                {
                    ind++;
                    needNeg = -1;
                    continue;
                }

                if (lex == '+' && sCnt == 0)
                    return Calculate(expression.Substring(0, ind)) + Calculate(expression.Substring(ind + 1));

                if (lex == '-' && sCnt == 0)
                    return Calculate(expression.Substring(0, ind)) + Calculate(expression.Substring(ind));

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
                    return Calculate(expression.Substring(fsInd+1, lsInd - (fsInd + 1))) * needNeg;
               
                ind++;
            }
            return Convert.ToDouble(expression);
        }
    }
}
