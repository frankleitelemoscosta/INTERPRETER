using System;

namespace src.interpreter.expr
{

    public class ConstIntExpr : IntExpr
    {
        public int value { get; set; }

        public ConstIntExpr(int line, int value) : base(line)
        {
            this.value = value;
        }

        public override int expr() {
        return this.value;
    }
    }
}