using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootFinder
{
    public interface IRootFinder
    {
        double FindRoot(Func<double, double> f);
    }
}
