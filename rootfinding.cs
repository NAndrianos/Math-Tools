//Student name: Niko Andrianos
//Student number: 82977380

using System;

namespace Lab7
{
    public class Program
    {

        static void Main()
        {
            //You could mainly use unit tests for testing.

            // Bisection test 1
            double a1 = -10;
            double b1 = 10;
            double eps1 = 0.000000001;
            double biTest1 = RootFinding.Bisection(TestFunction1, a1, b1, eps1);
            Console.WriteLine($"Bisection test 1: root = {biTest1}");

            // Secant test 1
            double a2 = -5;
            double b2 = 5;
            double eps2 = 0.0001;
            double secTest1 = RootFinding.Secant(TestFunction1, a2, b2, eps2);
            Console.WriteLine($"Secant test 1: root = {secTest1}");
        }

        static double TestFunction1(double x)
        {
            return Math.Cos(x) - x * x * x;
        }
    }
    public class RootFinding
    {
        // Delegate for any function whose root we want to find
        public delegate double Function(double x);

        /// <summary>
        /// Finds a root of f() using the Bisection method.
        /// The cap for the # of attempted iterations is 300.
        /// </summary>
        /// <param name="f">A delegate representing the function f to find the root of.</param>
        /// <param name="a">Left side of (a, b) that brackets a root.</param>
        /// <param name="b">Right side of (a, b) that brackets a root. b is greater than a. </param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated root. If a root cannot be found, double.NaN is returned.</returns>
        /// <exception cref="ArgumentException">
        /// thrown if f(a)*f(b) is not negative or 
        ///           epsilon is negative. 
        /// </exception>
        public static double Bisection(Function f, double a, double b, double epsilon)
        {
            double xGuess;
            int maxIterations = 300;
            int count = 0;

            // Check if method parameters are valid
            if (f(a) * f(b) >= 0)
            {
                throw new ArgumentException("Invalid a or b interval inputs, they do not bound a root");
            }
            if (epsilon < 0)
            {
                throw new ArgumentException("Epsilon can never be negative or zero");
            }

            while (count < maxIterations) 
            {
                // Calculate midpoint
                xGuess = (a + b) / 2;

                // Check if function input can be returned
                if (Math.Abs(f(xGuess)) < epsilon)
                {
                    return xGuess;
                }

                // Set next interval (a,b) to use by checking midpoint of both a and b
                if (f(a)*f((a+b)/2)<0)
                {
                    b = (a + b) / 2;
                }
                else if(f((a+b)/2) * f(b) < 0)
                {
                    a = (a + b) / 2;
                }

                count++;
            }

            // returned if no guess is found in under 300 iterations      
            return double.NaN;
        }

        /// <summary>
        /// Finds a root of f() using the Secant method.
        /// </summary>
        /// <param name="f">A delegate representing the function f to find the root of.</param>
        /// <param name="x0">Initial guess x0.</param>
        /// <param name="x1">Initial guess x1 where x1 is greater than x0. </param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated root. If a root cannot be found, double.NaN is returned.</returns>
        /// <exception cref="ArgumentException">
        /// thrown if x1 is not greater than x0 or 
        ///        epsilon is negative.
        /// </exception>
        public static double Secant(Function f, double x0, double x1, double epsilon)
        {
            double xNext;
            int maxIterations = 300;
            int count = 0;

            // Check if method parameters are valid
            if (x1<=x0)
            {
                throw new ArgumentException("Invalid a or b interval inputs, they do not bound a root");
            }
            if (epsilon < 0)
            {
                throw new ArgumentException("Epsilon can never be negative or zero");
            }

            while (count < maxIterations)
            {
                // Calculate next x value
                xNext = x1 - f(x1) * (x1 - x0) / (f(x1) - f(x0));

                // Check if function input can be returned
                if (Math.Abs(f(xNext)) < epsilon)
                {
                    return xNext;
                }

                // Set next inputs
                x0 = x1;
                x1 = xNext;

                count++;
            }

            return double.NaN;
        }
    }
}