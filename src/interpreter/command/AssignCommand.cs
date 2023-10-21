using System;
using src.interpreter.expr;

namespace src.interpreter.command
{

    public class AssignCommand : Command
    {
        public Variable var { get; set; }
        public IntExpr expre { get; set; }

        public AssignCommand(int lines, Variable var, IntExpr expr) : base(lines)
        {
            this.var = var;
            this.expre = expr;
        }

        public override void execute()
        {
            int value = expre.expr();
            this.var.setValue(value);
        }
    }
}