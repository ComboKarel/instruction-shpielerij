using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstructionShpielerij
{
    public class Instruction
    {
        /// <summary>
        /// The name of the instruction, get this from the INSTRUCTIONS enum in the correct class(es).
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The domain where this instruction should be executed, this can consist of one or more classes.
        /// </summary>
        public Type[] Domain { get; private set; }

        public object?[]? Parameters { get; private set; }

        public Instruction(string id, Type[] domain)
        {
#if DEBUG
            // Validation (only execute in debug mode)
            foreach (Type type in domain)
            {
                if (type.GetProperty("Instructions") == null)
                {
                    throw new Exception($"Type {type.Name} does not inherit from InstructionHandler, but was used in the domain of instruction {id}");
                }
            }
#endif

            Id = id;
            Domain = domain;
        }
        public Instruction(string id, Type[] domain, object?[]? parameters) : this(id, domain)
        {
            Parameters = parameters;
        }

        public bool IsApplicableForType(Type type)
        {
            return Domain.Contains(type);
        }
    }
}