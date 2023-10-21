using System.Collections.Generic;

namespace src.interpreter.expr
{
    public class Variable : IntExpr
    {
        private static Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

        private string name;
        private int value;

        private Variable(string name) : base(-1)
        {
            this.name = name;
            this.value = 0;
        }

        public string getName()
        {
            return this.name;
        }

        public override int expr()
        {
            return this.value;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        public static Variable instance(string name)
        {
            if (!variables.TryGetValue(name, out Variable v))
            {
                v = new Variable(name);
                variables[name] = v;
            }

            return v;
        }
    }
}
