# H1 InstructionShpielerij

Adds functionality for instruction and instructionhandler objects.
This package was made to solve the problem of method chaining in nested classes.

Check out the [Example Project](https://github.com/ComboKarel/instruction-shpielerij/tree/main/Voorbeeld)

Licensed under the MIT License.

## H2 Example

```cs
using InstructionShpielerij;

TopLayer topLayer = new TopLayer();
Instruction instruction = new Instruction("GetNumber", new Type[] { typeof(BottomLayer) });
InstructionHandledResult instructionHandledResult = topLayer.PassInstruction(instruction);
Console.WriteLine(instructionHandledResult.Value);

public class TopLayer : InstructionHandler
{
    public BottomLayer bottomLayer = new BottomLayer();
}

public class BottomLayer : InstructionHandler
{
    public override string[] Instructions => new string[] { "GetNumber" };

    public int GetNumber()
    {
        return 50;
    }
}

````

[Github Repository](https://github.com/ComboKarel/instruction-shpielerij)
