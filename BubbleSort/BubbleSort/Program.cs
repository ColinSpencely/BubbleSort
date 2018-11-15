using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    /* Program will bubble sort a list of numbers of user-defined size.
     * Time complexity of bubble sort: O(n^2)
     * Space complexity of bubble sort: O(1)
     * 
     * Pseudocode
     * 
     * JUMP to FillList
     * JUMP to PrintPrettyList to print unsorted list.
     * JUMP to BubbleSort to sort list.
     * JUMP to PrintPrettyList to print sorted list.
     * 
     * BubbleSort (list of ints):
     *      temp = 0
     *      FOR each number i in the list:
     *          FOR each number j in the list:
     *              IF the numbers are in the same position:
     *                  CONTINUE
     *              IF i > J:
     *                  temp = i
     *                  i = j
     *                  j = temp
     *      RETURN list of ints
     * 
     * PrintPrettyList (list of ints):
     *      j = 0 (column count)
     *      FOR each number in the list:
     *          INCREMENT j
     *          IF j < 10:
     *              PRINT number with left-padding of 5 spaces.
     *          ELSE:
     *              PRINT number and new line.
     *              Reset j to 0.
     *              
     * FillList (list of ints):
     *      WHILE until user enters a list size greater than 10:
     *          Prompt user for list size.
     *          IF list size string is non-numeric:
     *              Print error message.
     *          If list size is numeric and list size is less than 10:
     *              Print error message.
     *      WHILE list of nums is less than list size:
     *          Generate random number between 1 and list size + 1
     *          IF random number is not already in list:
     *              Add random number to list.
     *      RETURN list of ints.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();

            Console.WriteLine("Welcome to Bubble Sort!\nTime Complexity = O(n^2)\nSpace Complexity = O(1)\n");
            numbers = FillList(numbers, rand);
            Console.WriteLine("\nUnsorted List: ");
            PrintPrettyList(numbers);
            numbers = BubbleSort(numbers);
            Console.WriteLine("\nBubble Sort: ");
            PrintPrettyList(numbers);
        }

        static List<int> BubbleSort(List<int> nums)
        {
            int temp = 0;

            for (int j = 0; j < nums.Count; j++)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (i + 1 < nums.Count)
                    {
                        if (nums[i] > nums[i + 1])
                        {
                            temp = nums[i];
                            nums[i] = nums[i + 1];
                            nums[i + 1] = temp;
                        }
                    }
                }
            }

            return nums;
        }

        // Function prints a list of ints with 10 ints per row.
        // Function takes a list of int as an argument.
        // Function returns void.
        static void PrintPrettyList(List<int> nums)
        {
            // Loop through each number in the list.
            for (int i = 0, j = 0; i < nums.Count; i++)
            {
                string numString = nums[i].ToString();
                numString = numString.PadLeft(5); // Adds 5 leading spaces to each number to even out the column width.

                j++; // Counts the number of ints in a single row.

                // Puts 10 numbers in a row.
                if (j < 10)
                {
                    Console.Write(numString + " ");
                }
                // At the end of a row, reset the counter.
                else
                {
                    j = 0;
                    Console.WriteLine(numString);
                }
            }
        }


        // Function fills list with random numbers.
        // Function takes a Random seed and a list of int as arguments.
        // Function returns unsorted list of ints to calling function.
        static List<int> FillList(List<int> nums, Random rand)
        {
            int randomInt = 0;
            int listSize = 0;
            bool check = false;

            while (!check)
            {
                Console.Write("How big is your list of numbers? ");
                check = int.TryParse(Console.ReadLine(), out listSize);
                if (!check)
                {
                    Console.WriteLine("That was not a number, compadre!");
                }
                if (check && listSize < 10)
                {
                    Console.WriteLine("List size must be greater than or equal to 10!");
                    check = false;
                }
            }

            while (nums.Count < listSize)
            {
                randomInt = rand.Next(1, listSize + 1);
                // If number is not already in list, add number.
                if (!nums.Contains(randomInt))
                    nums.Add(randomInt);
            }
            return nums;
        }
    }
}
