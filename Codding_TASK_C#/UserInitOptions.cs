using System;

namespace Codding
{
    public class UserInitOptions                
    {
        public Boolean FileInput { get; set; } = false;
        public String FileInputName { get; set; }

        public Boolean OptionalLines { get; set; } = false;
        public int OptionalLinesNumber { get; set; }

        public Boolean FileOutput { get; set; } = false;
        public String FileOutputName { get; set; }

        public String WordToFind { get; set; }
        public String WordToReplace { get; set; }
    }
}