using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InstructionShpielerij
{
    public abstract class InstructionHandler
    {
        /// <summary>
        /// Instructions defines a list of methods by name that will be automatically called by HandleInstruction.
        /// Non-corresponding names can also be used, but HandleInstruction will need to be overridden.
        /// </summary>
        public virtual string[] Instructions => Array.Empty<string>();

        /// <summary>
        /// Passes an Instruction to members which belong to the domain.
        /// Members can be explicitly specified by attributes. (WIP)
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns>An InstructionHandledResult which contains the return value of the executed method 
        ///and information about how the instruction was handled. (WIP)</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public InstructionHandledResult PassInstruction(Instruction? instruction)
        {
            // Validation
            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            if (!instruction.IsApplicableForType(GetType()))
            {
                var memberInfos = GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property);
                foreach (MemberInfo memberInfo in memberInfos)
                {
                    object? memberInstance = memberInfo.MemberType == MemberTypes.Field
                        ? ((FieldInfo)memberInfo).GetValue(this)
                        : ((PropertyInfo)memberInfo).GetValue(this);
                    if (memberInstance is InstructionHandler)
                    {
                        InstructionHandler? instructionHandler = memberInstance as InstructionHandler;
                        InstructionHandledResult? result = instructionHandler?.PassInstruction(instruction);
                        if (result != null)
                        {
                            return result;
                        }
                        else
                        {
                            throw new Exception($"Verwittig Daan altublieft, want het is helemaal kapot!!!");
                        }
                    }
                }
                throw new Exception($"Instruction {instruction.Id} has no destination to go to in type {GetType().Name}!!!");
            }
            else
            {
                return HandleInstruction(instruction);
            }
        }

        /// <summary>
        /// Method that gets called when the instruction is applicable here.
        /// Custom behaviour can be implemented by overriding this method.
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        protected virtual InstructionHandledResult HandleInstruction(Instruction instruction)
        {
            MethodInfo? methodInfo = GetType().GetMethod(instruction.Id);
            if (methodInfo == null)
            {
                throw new Exception($"Instruction {instruction.Id} was not found in type {GetType().Name}");
            }
            object? result = methodInfo?.Invoke(this, instruction.Parameters);
            return new InstructionHandledResult(result);

            //throw new NotImplementedException($"HandleInstruction is not implemented in {GetType().Name}, but was called anyway.");
        }
    }
}
