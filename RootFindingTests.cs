//Student name: Niko Andrianos
//Student number:

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab7.Tests
{
    [TestClass()]
    public class RootFindingTests
    {
        //Put a helper method below for each of the f(x) that you have a test case on
        //Each of these helper methods must take one parameter (type double) and must have a double return type
        double TestFunction1(double x) //a quadratic equation
        {
            return x * x + (-3) * x + 2;
        }
        double TestFunction2(double x) //a linear function
        {
            return x - 1;
        }

        // Bisection tests

        [TestMethod()]
        public void BisectionTest1()
        {
            double epsilon = 0.0001;
            double a = 0.5;
            double b = 1.5;
            double result = RootFinding.Bisection(TestFunction1, a, b, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionTest2()
        {
            RootFinding.Bisection(TestFunction1, 0.8, 0.85, 0.0001);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionTest3()
        {
            RootFinding.Bisection(TestFunction1, -0.8, 0.85, -0.0001);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionTest4()
        {
            RootFinding.Bisection(TestFunction1, -0.8, 0.85, 0);
        }

        [TestMethod()]
        public void BisectionTest5()
        {
            double epsilon = 0.00000000000000000001;
            double a = 0;
            double b = 3;
            double result = RootFinding.Bisection(TestFunction2, a, b, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionTest6()
        {
            RootFinding.Bisection(TestFunction1, 1, 2, 0.0001);
        }

        [TestMethod()]
        public void BisectionTest7()
        {
            double epsilon = 0.0000000000000000000000000001;
            double a = -1*double.MaxValue;
            double b = double.MaxValue;
            double result = RootFinding.Bisection(TestFunction1, a, b, epsilon);
            Assert.AreEqual(double.NaN, result);
        }

        // Secant tests

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SecantTest1()
        {
            RootFinding.Secant(TestFunction1, 0.85, 0.80, 0.0001);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SecantTest2()
        {
            RootFinding.Secant(TestFunction1, -0.8, 0.85, -0.0001);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SecantTest3()
        {
            RootFinding.Secant(TestFunction1, -0.8, 0.85, 0);
        }

        [TestMethod()]
        public void SecantTest4()
        {
            double epsilon = 0.00000000000000000001;
            double x0 = 0;
            double x1 = 3;
            double result = RootFinding.Secant(TestFunction2, x0, x1, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }

        [TestMethod()]
        public void SecantTes5()
        {
            double epsilon = 0.0001;
            double x0 = 0.5;
            double x1 = 1.5;
            double result = RootFinding.Secant(TestFunction1, x0, x1, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }
    }
}