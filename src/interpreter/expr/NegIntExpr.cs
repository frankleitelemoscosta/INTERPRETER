using System;

namespace src.interpreter.expr
{
    public class NegIntExpr : IntExpr
    {
        private IntExpr _expr;

        public NegIntExpr(int line, IntExpr expr) : base(line)
        {
            this._expr = expr;
        }

        public override int expr()
        {
            return -this._expr.expr();
        }
    }
}