using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader
{
    class Stream : IStream
    {
        public string Vogals = "A E I O U";
        public string Consoants = "B C D F G J K L M N P Q R S T V W X Y Z";
        public int Iteration { get; set; }
        public int Lenght { get; set; }
        public string Characters { get; set; }

        public char GetNext()
        {
            char charResult = char.MinValue;
            for (int i = 1; i < Lenght; i++)
            {
                if (i == Iteration)
                {
                    charResult = Characters[i];
                    Iteration++;
                    break;
                }
            }

            return charResult;
        }

        public bool HasNext()
        {
            if (Iteration < Lenght)
            {
                return true;
            }

            return false;
        }
    }
}
