using System;

namespace src.interpreter.expr
{

    public class ReadIntExpr : IntExpr
    {

        public ReadIntExpr(int line) : base(line){}


        public override int expr()
        {
            int value;
            value = int.Parse(Console.ReadLine());
            return value;
        } 
    }
}