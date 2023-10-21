using System;

namespace src.interpreter.expr
{
    public class ConstBoolExpr : BoolExpr
    {
    private bool value;

    public ConstBoolExpr(int line, bool value) : base(line)
    {
        this.value = value;
    }

    public override bool expr()
    {
        return value;
    }

}
}
