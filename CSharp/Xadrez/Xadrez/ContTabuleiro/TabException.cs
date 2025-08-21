using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContTabuleiro
{
    internal class TabException : Exception
    {
        public TabException(string msg) : base(msg) 
        {

        }
    }
}
