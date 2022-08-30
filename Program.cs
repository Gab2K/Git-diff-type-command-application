using System;
using System.Collections.Generic;
using System.IO;

namespace Git_diff
{
    class Program
    {
        public static void Main(string[] args)
        {

            var file1 = new List<string>(); //File 1 is going to be loaded here/
            var file2 = new List<string>(); //File 2 is going to be loaded here

            var takenWordsList = new List<string>(); //File with all the subtracted words
            var addedWordsList = new List<string>(); //File with all the added words


            int numberOfFiles = 0; //To get number of files that are available


            //creates a new string of files 
            string[] files =
            {   "1.txt", "2.txt", "3.txt", "4.txt", "5.txt",
                "GitRepositories_1a.txt", "GitRepositories_1b.txt",
                "GitRepositories_2a.txt", "GitRepositories_2b.txt",
                "GitRepositories_3a.txt", "GitRepositories_3b.txt" };

            //loops through the string of files
            for (int i = 0; i < files.Length; i++)
            {
                numberOfFiles++;
                Console.Write($"{i + 1}. ");
                Console.Write(files[i]);
                Console.WriteLine();
            }


            bool correctInput = false; //Checks if input is correct
            int First; //First file input
            int Second; //Second file input


            // First input
            while (correctInput == false) //While user doesn't input in correct format
            {
                try
                {
                    Console.Write("\nEnter the first file (number): ");
                    First = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException) //If input is not a number
                {
                    Console.WriteLine($"\nEnter a number between 1 and {numberOfFiles}");
                    continue; //Go back to the beginning of a loop for the first file
                }

                //If input is bigger than 0 or smaller or equal to number of files
                if (First > 0 && First <= numberOfFiles)
                {
                    First--;
                    differenceCheck.loadFiles(files[First], file1); //Passes the file name to the function
                    correctInput = true; //Breaks the loop
                }
                else
                {
                    Console.WriteLine($"\nEnter a number between 1 and {numberOfFiles}");
                    continue; //Goes to the beginning of the loop for first file
                }

            }

            correctInput = false; //Resets correct input so it can be used for the second file


            // Second file
            while (correctInput == false) //While user doesn't input in correct format
            {
                try
                {
                    Console.Write("\nEnter the second file (number): ");
                    Second = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException) //If input is not a number
                {
                    Console.WriteLine($"\nEnter a number between 1 and {numberOfFiles}");
                    continue; //Go back to the beginning of a loop for second file
                }

                //If input is bigger than 0 or smaller or equal to number of files
                if (Second > 0 && Second <= numberOfFiles)
                {
                    Second--;
                    differenceCheck.loadFiles(files[Second], file2); //Passes the file name to the function
                    differenceCheck.compareFiles(file1, file2, takenWordsList, addedWordsList); //Load the function that compares the 2 files
                    correctInput = true; //Breaks the loop
                }
                else
                {
                    Console.WriteLine($"\nEnter a number between 1 and {numberOfFiles}");
                    continue; //Goes to the beginning of the loop for second file
                }

            }

            Console.Clear();

            //Loops through first file
            Console.WriteLine(">>File1<<\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in file1)
            {
                Console.WriteLine(item);
            }

            Console.ResetColor();

            //Loops through second file
            Console.WriteLine("\n>>File2<<\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var item in file2)
            {
                Console.WriteLine(item);
            }


            Console.ResetColor();
            Console.WriteLine("\n\nPress enter for results\n");
            Console.ReadLine();

            if (takenWordsList.Count == 0 && addedWordsList.Count == 0) //If both lists are empty it means that both files are the same
            {
                Console.WriteLine("Files are the same");
            }

            else
            {
                //Outputs all the words that have been removed in red colour
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var item in takenWordsList)
                {
                    Console.WriteLine(item);
                }

                Console.ResetColor();

                //Outputs all the words that have been added in green colour
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in addedWordsList)
                {
                    Console.WriteLine(item);
                }

                Console.ResetColor();


                //Create a log 
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", DateTime.Now.ToString()); //Append date to log file
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", "\n"); //New line

                foreach (var item in addedWordsList)
                {
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", item.ToString());
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", "\n");
                }

                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", "\n"); //New line
                foreach (var item in takenWordsList)
                {
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", item.ToString());
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", "\n"); //New line
                }

                Console.WriteLine($"\nLog file has been created at \n{AppDomain.CurrentDomain.BaseDirectory}");
            }
            
        }
    }
}




    


