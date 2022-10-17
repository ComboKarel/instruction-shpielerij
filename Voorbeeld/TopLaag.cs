using InstructionShpielerij;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld
{
    internal class TopLaag : InstructionHandler
    {
        public MidLaag MidLaag { get; set; }

        public TopLaag()
        {
            MidLaag = new MidLaag();
        }
    }
}
