using System;
using src.interpreter.expr;

namespace src.interpreter.command
{
    public class WhileCommand : Command
    {

    private BoolExpr cond;
    private Command cmds;

    public WhileCommand(int line, BoolExpr cond, Command cmds) : base(line)
    {
        this.cond = cond;
        this.cmds = cmds;
    }

    public override void execute()
    {
        WhileCommand whi;
        whi = (WhileCommand)this.cmds;

        while (this.cond.expr())
            whi.execute();
    }

}
}