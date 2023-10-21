using System;

namespace src.interpreter.expr
{
    public class NotBoolExpr : BoolExpr
    {

    public BoolExpr expre;

    public NotBoolExpr(int line, BoolExpr expr) : base(line)
    {   
        this.expre = expr;
    }

    public override bool expr()
    {
        return !expre.expr();
    }

}
}