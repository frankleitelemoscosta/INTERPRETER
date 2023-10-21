using System;
using src.interpreter.expr;

namespace src.interpreter.command
{
    public class OutputCommand : Command
    {
        public IntExpr expr; 

        public OutputCommand(int line,IntExpr expr) : base(line)
        {
            this.expr = expr;
        }

        public override void execute()
        {
            Console.WriteLine(this.expr.expr());
        }

    }
}