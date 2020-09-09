using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader
{
    public interface IStream
    {
        public char GetNext();
        public bool HasNext();
    }
}
