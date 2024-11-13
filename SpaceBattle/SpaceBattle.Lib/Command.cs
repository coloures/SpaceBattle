using System.ComponentModel.Design;
using System.Linq;
namespace SpaceBattle.Lib;

public interface ICommand
{
    void Execute();
}

public class MacroCommand: ICommand
{
    ICommand[] cmds;
    public MacroCommand(params ICommand[] cmds)
    {
        this.cmds = cmds;
    }
    public void Execute()
    {
        Array.ForEach(cmds, cmd => cmd.Execute());
    }
}

public class EmptyCommand: ICommand
{
      public void Execute()
    {
    }
}

interface Injectable
{
    void Inject(ICommand cmd);
}
public class BridgeCommand: ICommand, Injectable
{







    // ISender q;
    // c1 = new MoveCommand();
    // bridgeCommand = new BridgeCommand();
    // c2 = new RepeatCommand(bridgeCommand, q);
    // c3 = new MacroCommand(c1, c2);
    // bridgeCommand.Inject(c3);








    ICommand Cmd;
    //public BridgeCommand(ICommand cmd)
    //{
    //    Cmd = cmd;
    //}
    public void Execute()
    {
        Cmd.Execute();
    }
    public void Inject(ICommand other)
    {
        Cmd = other;
    }
}





// ISender q;
    // c1 = new MoveCommand();
    // bridgeCommand = new BridgeCommand();
    // c2 = new RepeatCommand(bridgeCommand, q);
    // c3 = new MacroCommand(c1, c2);
    // bridgeCommand.Inject(c3); 