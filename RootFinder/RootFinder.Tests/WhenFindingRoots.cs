using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RootFinder.Tests
{
    [TestClass]
    public class WhenFindingRoots
    {
        private Newton _rootFinder;

        [TestInitialize]
        public void Setup() 
        {
            _rootFinder = new Newton();
        }

        [TestMethod]
        [ExpectedException(typeof(RootNotFoundException))]
        public void Constant_function_does_not_have_a_root()
        {
            double root = _rootFinder.FindRoot(x => 1);                        
        }

        [TestMethod]
        public void Linear_function_has_a_root()
        {
            Func<double, double> f = x => x + 1;
            
            double root = _rootFinder.FindRoot(f);           
            
            Assert.IsTrue(f(root) < _rootFinder.Accuracy);
        }

        [TestMethod]
        public void Root_found_for_quadratic_with_two_roots()
        {
            Func<double, double> f = x => Math.Pow(x, 2) - 10;

            double root = _rootFinder.FindRoot(f);

            Assert.IsTrue(f(root) < _rootFinder.Accuracy);
        }

        [TestMethod]
        [ExpectedException(typeof(RootNotFoundException))]
        public void No_root_found_for_quadratic_with_no_roots()
        {
            _rootFinder.FindRoot(x => Math.Pow(x, 2) + 10);          
        }
    }
}
