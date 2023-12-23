using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// Get the factorial number
        /// </summary>
        /// <param name="n">Number to perform calculation</param>
        /// <returns>Total</returns>
        /// <exception cref="ArgumentException">Throws an exception if the number is negative value</exception>
        public static int GetFactorial(int n)
        {
            //Note: Is possible to resolve this solution using recursion which can turn the code more
            //cleaner although if performance is a must is better to avoid whenever possible.
            /*
                eg.:
                if(n == 0) return 1;
                else return n * GetFactorial(n - 1);
            */

            if (n >= 0 && n <= 1) return 1;
            else if (n < 0) throw new ArgumentException("Please use only positive integers");

            //first calculation you can subtract one number from the integer
            //note doing it you can subtract two numbers from the calculation
            int total = n * (n - 1);
            int needle = n - 2;

            //perform simple for
            for (int i = needle; i >= 1; i--)
            {
                total *= i;
            }

            return total;
        }

        /// <summary>
        /// Format the separators and return a concatened string
        /// </summary>
        /// <param name="items">List of string</param>
        /// <returns>Concatened string in a specific pattern</returns>
        /// <exception cref="ArgumentNullException">Throws an exception if the list is null</exception>
        public static string FormatSeparators(params string[] items)
        {
            //Basic checks to ensure integrity
            if (items == null) throw new ArgumentNullException();
            else if (items.Length == 0) return string.Empty;
            else if (items.Length == 1) return items.First();

            //Save the last value from the list
            string lastItem = items.Last();

            //Create a new list without last element
            string[] newItems = items.SkipLast(1).ToArray();

            //join the new list using the pattern
            string joinedItems = string.Join(", ", newItems);

            //return the joined list adding the last element
            return $"{joinedItems} and {lastItem}";
        }
    }
}