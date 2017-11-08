using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Codding
{
    class Output
    {
        public String PathOutput { get; set; }
        public void SetPathOutput(String nameFile) { PathOutput = @nameFile; }
        public String[] Text ;
        public void WriteToFile()
        {
            if (!File.Exists(PathOutput))
            {
                File.AppendAllLines(PathOutput, Text);
            }
        }
        public void SearchAndReplace(String[] inText, int numberOfLines, String key, String replace, int range)
        {
            Text = new String[numberOfLines];
            if(numberOfLines > 0)
                Text = inText;
            int count = 0;
            while(count != numberOfLines)
            {
                 if(count < range)
                 {
                    bool result = Regex.IsMatch(Text[count], key, RegexOptions.IgnoreCase);
                    if(result)
                    {
                        Text[count] = Regex.Replace( inText[count] , key, replace) ;
                    }
                 }
                 else
                    {
                        Text[count] = inText[count];
                    }
                    count++;
            }
        }
        
        public void WriteTextOnCommandLine()
        {
            Console.WriteLine("\n \nOUTPUT TEXT:");
            foreach (String element in Text)
            {
                Console.WriteLine(element);
            }
        }
    }
}
