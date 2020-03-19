using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool CommandCheck = false;
            while (!CommandCheck)
            {
                string line = Console.ReadLine();
   
                if (line.StartsWith("git diff"))
                {
                    string[] words = line.Split(" ", 4);
                    if (words[2].EndsWith(".txt") && words[3].EndsWith(".txt"))
                    {
                        bool FileCheck = false;
                        string FirstFile = "../../../";
                        string SecondFile = "../../../";
                        try
                        {
                            FirstFile = File.ReadAllText(FirstFile + words[2]);
                        }
                        catch(FileNotFoundException)
                        {
                            Console.WriteLine("File not found, please try again");
                        }
                        try
                        {
                            SecondFile = File.ReadAllText(SecondFile + words[3]);
                            FileCheck = true;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File not found, please try again");
                        }
                        if (FileCheck)
                        {
                            if (FirstFile.Equals(SecondFile))
                            {
                                Console.WriteLine("The two files are the same");
                                CommandCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("The two files are different");
                                CommandCheck = true;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Incorrect files inputted, please try again ");
                    }
                }
                else
                {
                    Console.WriteLine("Command not recognised, please try again.");
                }
            }
        }
    }
}
