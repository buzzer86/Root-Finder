using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootFinder
{
    public class FunctionParser
    {
        public Func<double, double> Parse(string input)
        {
            input = Clean(input);

            var terms = input.Split(new[] { "+" }, StringSplitOptions.RemoveEmptyEntries);

            Func<double, double> f = x =>
            {
                double sum = 0;
                
                foreach (var term in terms)
                {
                    sum += Eval(term, x);
                }

                return sum;
            };

            return f;
        }

        private double Eval(string term, double x)
        {
            double product = 1;
            
            while(term.Contains("x^"))
            {
                var i = term.IndexOf("x^");

                var power = term.GetNumberAtIndex(i + 2);
                
                term = term.Remove(i, power.ToString().Length + 2);

                product *= Math.Pow(x, power);                
            }

            while (term.Contains('x')) 
            {                
                term = term.Remove(term.IndexOf('x'), 1);
                product *= x;
            }

            if (term.Length > 0)
            {
                product *= double.Parse(term);
            }

            return product;
        }

        private string Clean(string input)
        {
            return input.Replace(" ", "")
                        .Replace("--", "+")
                        .Replace("-", "+-")   
                        .Replace("-x", "-1x")
                        .ToLower();      
        }
    }
}
