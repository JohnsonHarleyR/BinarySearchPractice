using System;
using System.Collections.Generic;

namespace BinarySearchPractice
{
    class Program
    {
        static void Main()
        {
            // I realize there is a binary search method already or perhaps other ways to retrieve,
            // perhaps another Collection type, but this is to practice setting up a binary search.

            // variables
            List<int> numbers = new List<int>() { 5, 26, 73, 23, 654, 231, 67, 43, 145, 346, 21, 1, 98,
                                                54, 79, 433, 65, 87, 985, 256, 987, 58, 84, 34, 46};
            int input;
            int index;

            Console.WriteLine("This is a simple exercise to create a binary search method that " +
                "returns the index of a number from a list.");

            numbers.Sort(); // sort the numbers for the binary search and display

            Console.WriteLine();
            Console.WriteLine("Here are the numbers to search from: ");
            Console.WriteLine();
            // display list of numbers
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            // loop until the user says to exit at the end
            while (true)
            {
                
                Console.WriteLine();
                while (true) // keep asking for the input until they enter an actual integer
                {
                    Console.WriteLine();
                    Console.WriteLine("Return the index of which number?");
                    try
                    {
                        input = Int32.Parse(Console.ReadLine());
                        break;
                    } catch (Exception)
                    {
                        // do nothing, loop back
                    }
                }

                Console.WriteLine($"Length of list: {numbers.Count}"); // test

                // now call the method to search for the number
                index = BinarySearch(numbers, input, 0, numbers.Count - 1);


                // show result
                Console.WriteLine();
                if (index == -1) // this indicates there was no match.
                {
                    Console.WriteLine("That number is not in the list.");
                }
                else
                {
                    Console.WriteLine($"Index: {index}");
                }




                // ask if they want to go again, keep going unless they enter "no"
                // not making it too fancy for this quick exercise
                Console.WriteLine();
                Console.WriteLine("Find another number?");
                if (Console.ReadLine().Equals("no", StringComparison.OrdinalIgnoreCase)) { break; }

            }
        }

        // binary search method
        public static int BinarySearch(List<int> list, int number, int start, int end)
        {

            // for a binary search, it must look at the middle number.
            int middle = (end + start) / 2;
            Console.WriteLine($"Start index: {start} Middle index: {middle} End index: {end}"); // test

            if (list[middle] == number)
            {
                Console.WriteLine("Match"); // test
                return middle;
            } else if (end - start == 1) // if it doesn't match, but there's only a difference of 1, there's no match
            {
                Console.WriteLine("No match."); // test
                return -1;
            }
            else if (list[middle] < number) // If it doesn't match, find out if it's higher or lower,
            {
                Console.WriteLine($"The number is greater than {list[middle]}."); // test
                // if it's lower, then set the end to middle number.
                // this should be the default order for sort
                start = middle;
                return BinarySearch(list, number, start, end);// recursion
            } else // otherwise the number must be greater than the middle value, so set it to the start value
            {
                Console.WriteLine($"The middle number is less than {list[middle]}."); // test
                end = middle;
                return BinarySearch(list, number, start, end);// recursion
            }
        }
    }
}
