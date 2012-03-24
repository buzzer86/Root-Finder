using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootFinder
{
    public class Newton : IRootFinder
    {        
        public double Accuracy { get; set; }
        public double StepSize { get; set; }
        public int MaxSteps { get; set; }
        public double Seed { get; set; }        

        public Newton() 
        {            
            Accuracy = 0.00001;
            StepSize = 0.00001;
            MaxSteps = 100;
            Seed = 0;
        }
        
        public double FindRoot(Func<double, double> f)
        {
            double x = Seed;
                        
            for (int i = 0; i < MaxSteps; i++)
            {
                double y = f(x);
                
                if (y < Accuracy)
                {
                    return x;
                }

                x = x - (y / Grad(f, x));
            }

            throw new RootNotFoundException();            
        }

        private double Grad(Func<double, double> f, double x)
        {
            double y0 = f(x);
            double y1 = f(x + StepSize);

            return (y1 - y0) / StepSize;
        }
    }
}
