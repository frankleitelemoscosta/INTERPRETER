using System;

namespace src.interpreter.expr
{
    public enum Opcao {
			ADD,
			SUB,
			MUL,
			DIV,
			MOD
		};
    public class BinaryIntExpr : IntExpr{

        
        public IntExpr left { get; set; }
        public IntExpr right { get; set; }

        public Opcao op;

        public BinaryIntExpr(int line, IntExpr left, Opcao op, IntExpr right) : base(line){
            this.left = left;
            //this.op = op;
            this.right = right;
        }

        public override int expr() {
            int v1 = left.expr();
            int v2 = right.expr();

            switch (this.op) {
                case Opcao.ADD:
                    return v1 + v2;
                case Opcao.SUB:
                    return v1 - v2;
                case Opcao.MUL:
                    return v1 * v2;
                case Opcao.DIV:
                    return v1 / v2;
                case Opcao.MOD:
                default:
                    return v1 % v2;
            }
        }
    
    }
}