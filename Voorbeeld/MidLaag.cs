using InstructionShpielerij;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld
{
    internal class MidLaag : InstructionHandler
    {
        public BodemLaag BodemLaag { get; set; }

        public MidLaag()
        {
            BodemLaag = new BodemLaag();
        }
    }
}
