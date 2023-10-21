using System;

namespace src.interpreter.expr
{

    public abstract class IntExpr{
        public int counterUnivercitylines { get; set; }
    
        public IntExpr(int lines)
        {
            this.counterUnivercitylines = lines;
        }
    
        public abstract int expr();
    }
}