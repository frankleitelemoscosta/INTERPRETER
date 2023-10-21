using System;


namespace src.interpreter.expr
{
    public enum Op {
			EQUAL,
			NOT_EQUAL,
			LOWER,
			GREATER,
			LOWER_EQUAL,
			GREATER_EQUAL
		}
    public class SingleBoolExpr : BoolExpr
    {
        
        public IntExpr left { get; set; }
        public IntExpr right { get; set; }

        public Op op;


        public SingleBoolExpr(int line, IntExpr left, Op op, IntExpr right) : base(line)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }

        public override bool expr()
        {
            int v1 = this.left.expr();
            int v2 = this.right.expr();

            switch (this.op) {
            case Op.EQUAL:
                return v1 == v2;
            case Op.NOT_EQUAL:
                return v1 != v2;
            case Op.LOWER:
                return v1 < v2;
            case Op.LOWER_EQUAL:
                return v1 <= v2;
            case Op.GREATER:
                return v1 > v2;
            case Op.GREATER_EQUAL:
            default:
                return v1 >= v2;
        }

        }

    }
}