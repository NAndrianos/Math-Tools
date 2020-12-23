//Student name: Niko Andrianos
//Student number: 82977380

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab8.Tests
{
    [TestClass()]
    public class CalculusTests
    {
        //Put a helper method below for each of the f(x) that you have a test case on
        //Each of these helper methods must take one parameter (type double) and must have a double return type
        double TestFunction1(double x) //a linear function
        {
            return x + 2;
        }
        double TestFunction2(double x) //the cos(x) - x^3 function
        {
            return Math.Cos(x) - x * x * x;
        }
        double TestFunction3(double x) // x^2 + x - 1 polynomial
        {
            return x * x + x - 1;
        }

        // Rectangular method tests
        [TestMethod()]
        public void DefiniteIntegralTest1()
        {
            int n = 500;
            double a = 0;
            double b = 1;

            double result = Calculus.RectangularMethod(TestFunction1, a, b, n);
            Assert.AreEqual(2.5, result, 0.01);
        }

        [TestMethod()]
        public void DefiniteIntegralTest2()
        {
            double a = 0;
            double b = 3;
            int n = 1000;

            double result = Calculus.RectangularMethod(TestFunction3, a, b, n);

            Assert.AreEqual(10.49, result, 0.01);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void DefiniteIntegralTest3()
        {
            Calculus.RectangularMethod(TestFunction2, 0, 1, 0);
        }

        [TestMethod()]
        public void DefiniteIntegralTest4()
        {
            double a = 0;
            double b = 2;
            int n = 1000;

            double result = Calculus.RectangularMethod(TestFunction2, a, b, n);

            Assert.AreEqual(-3.09, result, 0.01);
        }


        // AdaptiveRectangularMethod Tests

        [TestMethod()]
        public void AdaptiveRectangularMethodTest1()
        {
            double a = 0;
            double b = 2;
            int seed = 100;
            double epsilon = 0.0001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction1, a, b, seed, epsilon);

            Assert.AreEqual(6, result, 0.01);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AdaptiveRectangularMethodTest2()
        {
            Calculus.AdaptiveRectangularMethod(TestFunction1, 0, 1, 1, -1);
        }

        [TestMethod()]
        public void AdaptiveRectangularMethodTest3()
        {
            double a = -2;
            double b = 2;
            int seed = 100;
            double epsilon = 0.0001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction1, a, b, seed, epsilon);

            Assert.AreEqual(8, result, 0.01);
        }

        [TestMethod()]
        public void AdaptiveRectangularMethodTest4()
        {
            double a = 0;
            double b = Math.PI/2;
            int seed = 100;
            double epsilon = 0.0001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction2, a, b, seed, epsilon);

            Assert.AreEqual(-0.52202, result, 0.01);
        }

        [TestMethod()]
        public void AdaptiveRectangularMethodTest5()
        {
            double a = 0;
            double b = 2 * Math.PI;
            int seed = 1000;
            double epsilon = 0.001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction2, a, b, seed, epsilon);

            // Open up delta difference - large number 
            Assert.AreEqual(-389.6363, result, 0.5);
        }

        [TestMethod()]
        public void AdaptiveRectangularMethodTest6()
        {
            double a = 0;
            double b = 3;
            int seed = 1000;
            double epsilon = 0.0001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction3, a, b, seed, epsilon);

            
            Assert.AreEqual(10.5, result, 0.01);
        }

        [TestMethod()]
        public void AdaptiveRectangularMethodTest7()
        {
            double a = 0;
            double b = 0;
            int seed = 100;
            double epsilon = 0.0001;

            double result = Calculus.AdaptiveRectangularMethod(TestFunction3, a, b, seed, epsilon);


            Assert.AreEqual(0, result, 0.01);
        }

        // CentralDifferencDerivative Tests

        [TestMethod()]
        public void CentralDifferenceDerivativeTest1()
        {
            double x = 1;
            double h = 1;

            double result = Calculus.CentralDifferenceDerivative(TestFunction1, x, h);

            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void CentralDifferenceDerivativeTest2()
        {
            double x = 1;
            double h = -1;

            double result = Calculus.CentralDifferenceDerivative(TestFunction1, x, h);

            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void CentralDifferenceDerivativeTest3()
        {
            double x = 0;
            double h = 1;

            double result = Calculus.CentralDifferenceDerivative(TestFunction2, x, h);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void CentralDifferenceDerivativeTest4()
        {
            double x = 3;
            double h = 5;

            double result = Calculus.CentralDifferenceDerivative(TestFunction3, x, h);

            Assert.AreEqual(7, result);
        }

        [TestMethod()]
        public void CentralDifferenceDerivativeTest5()
        {
            double x = 5;
            double h = 5;

            double result = Calculus.CentralDifferenceDerivative(TestFunction3, x, h);

            Assert.AreEqual(11, result);
        }

        [TestMethod()]
        public void CentralDifferenceDerivativeTest6()
        {
            double x = 0;
            double h = 5;

            double result = Calculus.CentralDifferenceDerivative(TestFunction3, x, h);

            Assert.AreEqual(1, result);
        }


    }
}