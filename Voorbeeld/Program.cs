using InstructionShpielerij;
using Voorbeeld;

TopLaag topLaag = new TopLaag();

InstructionHandledResult result = topLaag.PassInstruction(new Instruction("GetGetal", new Type[] {typeof(BodemLaag)}));
Console.WriteLine(result.Value);

Console.ReadLine();