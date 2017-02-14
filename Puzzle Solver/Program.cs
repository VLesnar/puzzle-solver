using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // Add the file classes

namespace Puzzle_Solver
{
    class Program
    {
        static private int gridCount;

        static void Main(string[] args)
        {
            // Begin by introducing user to puzzle solver
            // Allow user to input which difficulty they'd like
            Console.WriteLine("Welcome to my Nurikabe puzzle solver!");
            Console.WriteLine("Please begin by choosing a puzzle.");
            Console.WriteLine("1 = Easier, 2 = Average, 3 = Harder");
            Console.Write("\nPlease enter 1, 2, or 3: ");

            // Check to make sure we have valid input
            // If not, keep asking for valid input
            string file = Console.ReadLine();
            bool success = false;
            while (!success) {
                if (file == "1" || file == "2" || file == "3")
                {
                    success = true;
                }
                else
                {
                    Console.Write("\nPlease enter 1, 2, or 3: ");
                    file = Console.ReadLine();
                }
            }

            // Read the file in
            StreamReader input = null;
            string[] numberStrings = null;  // Used to hold data from a text file

            try
            {
                // Open the file
                input = new StreamReader(file + ".txt");

                // Loop to read the file
                // File format: Number spaces, Status spaces
                string text = "";
                char[] delimiterChars = { ',' };

                while ((text = input.ReadLine()) != null)
                {
                    numberStrings = text.Split(',');
                }
            }
            catch (IOException ioe)
            {
                return;
            }
            finally
            {
                input.Close();
            }

            int[] numberArray = new int[numberStrings.Length / 2];
            int[] spaceArray = new int[numberStrings.Length / 2];

            for (int i = 0; i < numberStrings.Length / 2; i++)
            {
                numberArray[i] = int.Parse(numberStrings[i]);
            }

            int j = 0;

            for (int i = numberStrings.Length / 2; i < numberStrings.Length; i++)
            {
                spaceArray[j] = int.Parse(numberStrings[i]);
                j++;
            }

            Console.WriteLine();

            gridCount = (int)Math.Sqrt(numberArray.Length);
            int arraySize = numberArray.Length;

            printGrid(numberArray, spaceArray);
            
            // Find 1 # values and fill in adjacent spaces
            for (int i = 0; i < arraySize; i++)
            {
                if(numberArray[i] == 1)
                {
                    if (!(i - 1 < 0) && !(i % gridCount == 0))  // Checks for left space of 1
                    {
                        spaceArray[i - 1] = 0;
                    }
                    if (!(i + 1 > arraySize) && !(i % gridCount == (gridCount - 1))) // Checks for right space of 1
                    {
                        spaceArray[i + 1] = 0;
                    }
                    if (!(i - gridCount < 0)) // Checks for top space of 1
                    {
                        spaceArray[i - gridCount] = 0;
                    }
                    if (!(i + gridCount > arraySize)) // Checks for bottom space of 1
                    {
                        spaceArray[i + gridCount] = 0;
                    }
                }
            }

            // Place black squares in spaces surrounded by numbers
            for (int i = 0; i < arraySize; i++)
            {
                if (numberArray[i] > 1)
                {
                    if (i - 2 >= 0 &&
                        numberArray[i - 2] > 1 &&
                        numberArray[i - 1] == 0 &&
                        i % gridCount > (i - 2 % gridCount))
                    {
                        spaceArray[i - 1] = 0;
                    }
                    if (i + 2 <= arraySize && 
                        numberArray[i + 2] > 1 &&
                        numberArray[i + 1] == 0 &&
                        i % gridCount < (i + 2 % gridCount))
                    {
                        spaceArray[i + 1] = 0;
                    }
                    if (i - 2 * gridCount >= 0 &&
                        numberArray[i - 2 * gridCount] > 1 &&
                        numberArray[i - 1 * gridCount] == 0)
                    {
                        spaceArray[i - gridCount] = 0;
                    }
                    if (i + 2 * gridCount <= arraySize &&
                        numberArray[i + 2 * gridCount] > 1 &&
                        numberArray[i + 1 * gridCount] == 0)
                    {
                        spaceArray[i + gridCount] = 0;
                    }
                }
            }

            printGrid(numberArray, spaceArray);

            // Place a black square - Check to see if placing a black square violates a constraint

            // Solve the puzzle; End the application

            // See if there are any # values that match the amount of squares open to them

            Console.ReadLine();


        }

        // This method prints the number array and the space array to the screen - Takes two int[]
        static void printGrid(int[] num, int[] space)
        {
            // Prints each number in the number array in the grid 
            for (int i = 0; i < num.Length; i++)
            {
                Console.Write(num[i]);
                if(i % gridCount == (gridCount - 1)) // Skips to the next line if the end of the row is reached
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            // Prints each space value in the space array in the grid
            for (int i = 0; i < space.Length; i++)
            {
                Console.Write(space[i]);
                if (i % gridCount == (gridCount - 1)) // Skips to the next line if the end of the row is reached
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}
