using System;
using System.IO;
using System.Collections.Generic;

namespace Codding
{
    class Input
    {
        public String PathInput { get; set; }
        public void SetPathInput(String nameFile) { PathInput = @nameFile; }
        public String[] Text;
        private List<String> List = new List<String>();
        public int NumberOfLines { get; set; } = 0;
        public void ReadFileAndCountLines()
        {
            StreamReader stream = new StreamReader(PathInput);
            while (!stream.EndOfStream)
            {
                List.Add(stream.ReadLine());
            }
            NumberOfLines = List.Count;
            Text = new String[NumberOfLines];
            for( int i = 0 ; i < NumberOfLines; i++)
            {
                Text[i] = List[i];
            }
        }
        public void GetTextFromKeyboard()
        {
            Console.WriteLine("Write sentences - to finish entering write /END");
            String line = Console.ReadLine();
            while(line != "/END")
            {
                List.Add(line);
                NumberOfLines++;
                line = Console.ReadLine();
            }
            Text = new String[NumberOfLines];
            for (int i = 0; i < NumberOfLines; i++)
            {
                Text[i] = List[i];
            }
        }
    }
}
