//Student name: Niko Andrianos
//Student number: 82977380

using System;

namespace Lab8
{
    public class Program
    {
        static void Main()
        {
            double result = Calculus.AdaptiveRectangularMethod(Func1, 0, 2, 100, 0.0001);

            Console.WriteLine($"Actual result = 6, adaptive numerical Result = {result}");
        }

        public static double Func1(double x) //a linear function
        {
            return x + 2;
        }
    }
    public class Calculus
    {
        // Delegate for any function whose definite integral or derivative we want to calculate
        public delegate double Function(double x);

        /// <summary>
        /// Finds the definite integral of f between a and b using 
        /// the rectangular method for a given n (sub-intervals).
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="a">Lower limit of the integral.</param>
        /// <param name="b">upper limit of the integral.</param>
        /// <param name="n">The number of subintervals between a and b for the rectangular method.</param>
        /// <returns>Returns the calculated integral value.</returns>
        /// <exception cref="ArgumentException">
        /// thrown if n is not a positive number.
        /// </exception>
        public static double RectangularMethod(Function f, double a, double b, int n)
        {
            double result = 0;
            // Function input f(x)
            double x = a;

            if (n <= 0)
            {
                throw new ArgumentException("The number of subintervals 'n' cannot be negative!");
            }

            double h = (b - a) / n;

            // While rectangle count (i) is less than n-1 perform calculation
            for(int i = 0; i < n; i++)
            {
                x = a + i * h;
                result += f(x);
            }

            // Multiply result by h, as every term is multiplied by h in algorithm
            return result * h;
        }

        /// <summary>
        /// Finds the definite integral adaptively by starting from 
        /// a seed value for n (# of sub-intervals), until the desired
        /// accuracy is achieved.
        /// This method uses RectangularMethod() in its implementation.
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="a">Lower limit of the integral.</param>
        /// <param name="b">upper limit of the integral.</param>
        /// <param name="SeedForN">The starting (seed) n for the rectangular method.</param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated integral value. 
        /// If an acceptable result is not found, returns double.NaN.</returns>
        ///<exception cref="ArgumentException">
        /// thrown if epsilon is not a positive number.
        /// </exception>
        public static double AdaptiveRectangularMethod(Function f, double a, double b, int SeedForN, double epsilon)
        {
            // Set as constant - fixed value
            const int maxIterations = 10;
            double compare = 0;
            double result0 = 0;
            double result1 = 0;

            // Epsilon must be positive to be valid - cannot be negative of 0
            if (epsilon <= 0)
            {
                throw new ArgumentException("Epsilon must be positive!");
            }

            int n0 = SeedForN;
            int n1;

            // Start iterative process
            for(int i = 0; i<maxIterations; i++)
            {
                n1 = n0 * 2;

                result0 = RectangularMethod(f, a, b, n0);
                result1 = RectangularMethod(f, a, b, n1);

                // Get absolute difference of rectangular difference with n0 and n1 iterations
                compare = Math.Abs(result1 - result0);

                if (compare < epsilon)
                {
                    return result1;  // Return the more accurate result (more iterations) - n1
                }

                // Causes n1 to double as well
                n0 *= 2;
            }

            // If no result is found after maxIterations return double.NaN
            return double.NaN;
        }

        /// <summary>
        /// Finds the derivative of f() at the given x.
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="x">The point at which to calculate the derivative.</param>
        /// <param name="h">The h used for the central difference method.</param>
        /// <returns>Returns the calculated derivative value. </returns>
        public static double CentralDifferenceDerivative(Function f, double x, double h)
        {
            // Only one calculation required
            return (f(x - 2 * h) - 8 * f(x - h) + 8 * f(x + h) - f(x + 2 * h)) / (12 * h);
        }
    }
}