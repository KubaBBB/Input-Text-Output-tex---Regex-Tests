using System;
using System.IO;

namespace Codding
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello!" +
                    " Choose options: \n" +
                    "1.Input filename \n" +
                    "2.Range of input Lines to process \n" +
                    "3.Output filename\n" +
                    "4.Start \n" +
                    "Default settings: input - command line, range - all Lines, output - command line");
                
                UserInitOptions userInitOptions = new UserInitOptions();
                String caseSwitch;
                do
                {
                    Console.WriteLine("Choose your option...(Setting up Input and Output isnt neccessary)");
                    caseSwitch = Console.ReadLine();
                    switch (caseSwitch)                                                                        
                    {
                        case "1":
                            userInitOptions.FileInput = true;
                            Console.WriteLine("Write input file name:");
                            userInitOptions.FileInputName = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Write range of input Lines which you want to process:");
                            userInitOptions.OptionalLines = true;
                            userInitOptions.OptionalLinesNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(userInitOptions.OptionalLinesNumber);
                            Console.WriteLine("Success");
                            break;
                        case "3":
                            userInitOptions.FileOutput = true;
                            Console.WriteLine("Write output file name:");
                            userInitOptions.FileOutputName = Console.ReadLine();
                            break;
                        case "4":
                            Console.WriteLine("Configuration complete");
                            break;
                        default:
                            Console.WriteLine("Sorry...Invalid Selection");
                            break;
                    }
                }
                while (caseSwitch != "4");
 
                Input input = new Input();                                                 
                Output output = new Output();

                if (userInitOptions.FileInput)                              
                {
                    input.SetPathInput(userInitOptions.FileInputName);
                    input.ReadFileAndCountLines();
                    if (!userInitOptions.OptionalLines)                     
                    {
                        userInitOptions.OptionalLines = true;
                        userInitOptions.OptionalLinesNumber = input.NumberOfLines; 
                    }
                    SetKeyAndReplaceWord(ref userInitOptions);
                    if (userInitOptions.FileOutput)                         
                    {
                        output.SetPathOutput(userInitOptions.FileOutputName);
                        output.SearchAndReplace(input.Text, input.NumberOfLines, userInitOptions.WordToFind,userInitOptions.WordToReplace, userInitOptions.OptionalLinesNumber);
                        output.WriteToFile();
                    }
                   else
                    {
                        output.SearchAndReplace(input.Text, input.NumberOfLines, userInitOptions.WordToFind, userInitOptions.WordToReplace, userInitOptions.OptionalLinesNumber);
                        output.WriteTextOnCommandLine();
                    }

                }
                else
                {
                    input.GetTextFromKeyboard();
                    SetKeyAndReplaceWord(ref userInitOptions);
                    if (!userInitOptions.OptionalLines)                     
                    {
                        userInitOptions.OptionalLines = true;
                        userInitOptions.OptionalLinesNumber = input.NumberOfLines;
                    }
                    if (userInitOptions.FileOutput)
                    {
                        output.SetPathOutput(userInitOptions.FileOutputName);
                        output.SearchAndReplace(input.Text, input.NumberOfLines, userInitOptions.WordToFind, userInitOptions.WordToReplace, userInitOptions.OptionalLinesNumber);
                        output.WriteToFile();
                    }
                    else
                    {
                        output.SearchAndReplace(input.Text, input.NumberOfLines, userInitOptions.WordToFind, userInitOptions.WordToReplace, userInitOptions.OptionalLinesNumber);
                        output.WriteTextOnCommandLine();
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Program couldnt run :");
                Console.WriteLine(exception.ToString());
            }
        }
        static void SetKeyAndReplaceWord(ref UserInitOptions user)
        {
            Console.WriteLine("What word would you like to replace?");
            user.WordToFind = Console.ReadLine();
            Console.WriteLine("Replaced word:");
            user.WordToReplace = Console.ReadLine();
            Console.WriteLine("Okay...so i will find: \"" + user.WordToFind + "\" and i will replace it with: \"" + user.WordToReplace + "\"");
        }
    }
}
