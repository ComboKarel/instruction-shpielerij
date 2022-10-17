using InstructionShpielerij;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld
{
    internal class BodemLaag : InstructionHandler
    {
        public override string[] Instructions => new string[] {"GetGetal", "GetGetal2"};

        public int GetGetal()
        {
            return 5;
        }

        public int GetGetal2()
        {
            return 6;
        }
    }
}
