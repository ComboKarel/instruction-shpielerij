using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionShpielerij
{
    public class InstructionHandledResult
    {
        public object? Value { get; private set; }

        public InstructionHandledResult(object? value)
        {
            Value = value;
        }
    }
}
