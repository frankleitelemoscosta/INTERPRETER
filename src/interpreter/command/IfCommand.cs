using System;
using src.interpreter.expr;

namespace src.interpreter.command
{
    public class IfCommand : Command
    {

        private BoolExpr cond { get; set; }
        private Command thenCmds { get; set; }
        private Command elseCmds { get; set; }

        public IfCommand(int line, BoolExpr cond, Command thenCmds) : this(line, cond, thenCmds, null)
        {
        }

        public IfCommand(int line, BoolExpr cond, Command thenCmds, Command elseCmds) : base(line)
        {
            this.cond = cond;
            this.thenCmds = thenCmds;
            this.elseCmds = elseCmds;
        }

        public override void execute()
        {
            IfCommand cmd;
            cmd = (IfCommand)this.thenCmds; 
            IfCommand f;
            f = (IfCommand)this.elseCmds;

            if (this.cond.expr())
                cmd.execute();
            else
            {
                if (this.elseCmds != null)
                    f.execute();
            }

        }

    }
}