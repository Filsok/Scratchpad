using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    public class GenericDelegates
    {
        public static void TestSet()
        {
            var delegates = new Delegates();
            Delegates.Display display = Console.WriteLine;
            display("Delegate display called from GenericDelegates.TestSet()");
            delegates.Main();
            Console.WriteLine("");
        }
    }

    internal class Delegates
    {
        public delegate void Display(string value);

        public delegate bool GenericPredicate<T>(T value);

        private Display? display;

        public void Main()
        {
            //display = Console.WriteLine;
            //display = Console.Write;
            display = (string value) => Console.Write(value + ", ");
            display("Delegate display called from Delegates.Main()");
            Console.WriteLine("");

            var numbers = new int[] { 10, 30, 50 };
            DisplayNumbers(numbers, display);
            Console.WriteLine("\n\n");
            //var count = Count(numbers, 15);
            var count = Count(numbers, (int value) => value > 35);
            Console.WriteLine(count);
            Console.WriteLine("\n");

            var strings = new string[] { "Generic", "Delegate", "Test" };
            count = Count(strings, value => value.Length > 4);
            Console.WriteLine(count);
        }

        private static void DisplayNumbers(IEnumerable<int> numbers, Display display)
        {
            foreach (var number in numbers)
            {
                //Console.WriteLine(number);
                display(number.ToString());
            }
        }

        //private static int Count<T>(IEnumerable<T> elements, GenericPredicate<T> predicate)
        private static int Count<T>(IEnumerable<T> elements, Predicate<T> predicate)
        {
            int count = 0;

            foreach (T element in elements)
            {
                if (predicate(element))
                    count++;
            }
            return count;
        }
    }
}

//Predefiniowane generyczne delegaty:
//przyjmują do 15 argumentów
//Action - void
//Predicate - Boolean
//Func - <T>