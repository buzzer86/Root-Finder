using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RootFinder.Tests
{
    [TestClass]
    public class WhenParsingTheFunction
    {
        FunctionParser _parser;

        [TestInitialize]
        public void Setup() 
        {
            _parser = new FunctionParser();
        }

        private void Can_parse_function(string input, double x, double y)
        {
            var f = _parser.Parse(input);

            Assert.AreEqual(y, f(x));
        }
        
        [TestMethod]
        public void Can_parse_constant_function_1()
        {
            Can_parse_function("1", 1000, 1);
        }

        [TestMethod]
        public void Can_parse_constant_function_2()
        {
            Can_parse_function("2", 1000, 2);
        }
                
        [TestMethod]
        public void Can_parse_simple()
        {
            Can_parse_function("2x + 4", 3, 10);
        }

        [TestMethod]
        public void Can_parse_multiple_terms()
        {
            Can_parse_function("-3x - 3 + 2 + 4x", 5, 4);
        }

        [TestMethod]
        public void Can_parse_double_minus()
        {
            Can_parse_function("-3x -- 3 + 2 + 4x", 5, 10);
        }

        [TestMethod]
        public void Can_parse_inconsistent_whitespace()
        {
            Can_parse_function("-   3x   -- 3  + 4    +5x", 5, 17);
        }

        [TestMethod]
        public void Can_parse_quadratic()
        {
            Can_parse_function("2x^2 + 3x - 1", 2, 13);
        }

        [TestMethod]
        public void Can_parse_third_order()
        {
            Can_parse_function("-x^3 + 2x^2 + 3x - 1", 3, -1);
        }
    }
}
