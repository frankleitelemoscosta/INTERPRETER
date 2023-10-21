using System;

namespace src.interpreter.expr
{
    public abstract class BoolExpr
    {
        public int line { get; set; }

        public BoolExpr(int line)
        {
            this.line = line;
        }

        public abstract bool expr();

    }
}