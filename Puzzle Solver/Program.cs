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
                    numberStrings = text.Split(delimiterChars);
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

            int[] spaceArray = new int[numberStrings.Length / 2];
            int[] numberArray = new int[numberStrings.Length / 2];

            // TODO - Put numbers into arrays; Solve the puzzle; End the application
        }
    }
}
