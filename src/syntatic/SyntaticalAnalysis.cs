using System;
using Enum;
using src.interpreter.expr;
using src.interpreter.command;
using src.lexico;

namespace src.syntatic
{
    public class SyntaticalAnalysis
    {
        public Lexema token_current { get; set; }
        public LexicalAnalysis lexicalAnalysis { get; set; }

        public SyntaticalAnalysis(Lexema passedInstance, LexicalAnalysis passedObject)
        {
            this.token_current = new Lexema();
            this.lexicalAnalysis = new LexicalAnalysis();
            this.token_current = passedInstance;
            this.lexicalAnalysis = passedObject;
            this.token_current = this.lexicalAnalysis.LexicalAnalysisAN(this.token_current);
        }

        public Variable procVar()
        {
            string tmp = this.token_current.token;

            eat(TokenType.TT_VAR);
            //Console.WriteLine(tmp);

            //Variable var = new Variable(tmp);
            return src.interpreter.expr.Variable.instance(tmp);
        }

        public ConstIntExpr procConst()
        {

            string tmp = this.token_current.token;
            eat(TokenType.TT_NUMBER);
            int line = this.token_current.counterLine;

            int numberr;
            try
            {
                numberr = int.Parse(tmp);
            }
            catch (Exception e)
            {
                numberr = 0;
            }
            ConstIntExpr cons = new ConstIntExpr(line, numberr);

            return cons;
        }

        public IntExpr procIntTerm()
        {
            
            if (this.token_current.type == TokenType.TT_VAR)
            {
                return procVar();
            }
            else if (this.token_current.type == TokenType.TT_NUMBER)
            {
                return procConst();
            }
            else
            {
                eat(TokenType.TT_READ);
                int line = this.token_current.counterLine;
                ReadIntExpr var = new ReadIntExpr(line);
                return var;
            }
        }

        public IntExpr procIntExpr()
        {
            bool is_negative = false;
            if (this.token_current.type == TokenType.TT_ADD)
            {
                Advance();
            }
            else if(this.token_current.type == TokenType.TT_SUB)
            {
                Advance();
                is_negative = true;
            }

            IntExpr left;
            if (is_negative)
            {
                int line = this.token_current.counterLine;
                IntExpr tmp = procIntTerm();
                left = new NegIntExpr(line, tmp);
            }else{
                left = procIntTerm();
            }

            if(this.token_current.type == TokenType.TT_ADD |
                this.token_current.type == TokenType.TT_SUB |
                this.token_current.type == TokenType.TT_MUL |
                this.token_current.type == TokenType.TT_DIV |
                this.token_current.type == TokenType.TT_MOD)
            {
                int line = this.token_current.counterLine;

                Opcao op;
                switch(this.token_current.type) {
                    case TokenType.TT_ADD:
                        op = Opcao.ADD;
                        break;
                    case TokenType.TT_SUB:
                        op = Opcao.SUB;
                        break;
                    case TokenType.TT_MUL:
                        op = Opcao.MUL;
                        break;
                    case TokenType.TT_DIV:
                        op = Opcao.DIV;
                        break;
                    case TokenType.TT_MOD:
                    default:
                        op = Opcao.MOD;
                        break;
                }
                Advance();

                IntExpr right = procIntTerm();

                return new BinaryIntExpr(line, left, op, right);
            }else{
                return left;
            }
        }

        public AssignCommand procAssign()
        {
            int line = this.token_current.counterLine;
            Variable var = procVar();

            eat(TokenType.TT_ASSIGN);
            IntExpr expr = procIntExpr();

            return new AssignCommand(line, var, expr);
        }

        public OutputCommand procOutput()
        {
            eat(TokenType.TT_OUTPUT);
            int line = this.token_current.counterLine;

            IntExpr expr = procIntExpr();

            return new OutputCommand(line, expr);
        }

        public BoolExpr procBoolExpr()
        {
            
            if (this.token_current.type == TokenType.TT_FALSE)
            {
                Advance();
                return new ConstBoolExpr(this.token_current.counterLine, false);
            }
            else if (this.token_current.type == TokenType.TT_TRUE)
            {
                Advance();
                return new ConstBoolExpr(this.token_current.counterLine, false);
            }
            else if (this.token_current.type == TokenType.TT_NOT)
            {
                Advance();
                int line = this.token_current.counterLine;
                BoolExpr expr = procBoolExpr();
                return new NotBoolExpr(line,expr);
            }
            else{
                int line = this.token_current.counterLine;
                IntExpr left = procIntTerm();

                Console.WriteLine(this.token_current.type);

            Op op = Op.GREATER;

            switch (this.token_current.type) {
                case TokenType.TT_EQUAL:
                    op = Op.EQUAL;
                    break;
                case TokenType.TT_NOT_EQUAL:
                    op = Op.NOT_EQUAL;
                    break;
                case TokenType.TT_LOWER:
                    op = Op.LOWER;
                    break;
                case TokenType.TT_LOWER_EQUAL:
                    op = Op.LOWER_EQUAL;
                    break;
                case TokenType.TT_GREATER:
                    op = Op.GREATER;
                    break;
                case TokenType.TT_GREATER_EQUAL:
                    op = Op.GREATER_EQUAL;
                    break;
                default:
                    ShowError();
                    break;
            }

            Advance();
            Console.WriteLine(this.token_current.type);

            IntExpr right = procIntTerm();


            return new SingleBoolExpr(line, left, op, right);
            }
        }

        public IfCommand procIf()
        {
            eat(TokenType.TT_IF);
            int line = this.token_current.counterLine;

            BoolExpr cond = procBoolExpr();
            eat(TokenType.TT_THEN);
            Command thenCmds = procCmdList();
            Command elseCmds = null;
            if (this.token_current.type == TokenType.TT_ELSE)
            {
                Advance();
                elseCmds = procCmdList();
            }
            eat(TokenType.TT_DONE);

            return new IfCommand(line, cond, thenCmds, elseCmds);
        }

        public WhileCommand procWhile()
        {
            eat(TokenType.TT_WHILE);
            int line = this.token_current.counterLine;

            BoolExpr expr = procBoolExpr();
            eat(TokenType.TT_DO);
            Command cmds = procCmdList();
            eat(TokenType.TT_DONE);

            return new WhileCommand(line, expr, cmds);
        }

        public Command procCMD()
        {
            Command cmd = null;

            if (this.token_current.type == TokenType.TT_VAR)
            {//pega o token que ja foi chamado que foi salvo em m_current e faz as verificações para saber para onde ele tem de ir agora
                cmd = procAssign();
            }
            else if (this.token_current.type == TokenType.TT_OUTPUT)
            {
                cmd = procOutput();
            }
            else if (this.token_current.type == TokenType.TT_IF)
            {
                cmd = procIf();
            }
            else if (this.token_current.type == TokenType.TT_WHILE)
            {
                cmd = procWhile();
            }
            else
            {
                ShowError();
            }

            eat(TokenType.TT_SEMICOLON);
            return cmd;
        }

        public Command procCmdList()
        {
            int line = token_current.counterLine;
            BlocksCommand cmds = new BlocksCommand(line);

            Command cmd = procCMD();
            cmds.AddCommand(cmd);

            while (this.token_current.type == TokenType.TT_VAR ||
           this.token_current.type == TokenType.TT_OUTPUT ||
           this.token_current.type == TokenType.TT_IF ||
           this.token_current.type == TokenType.TT_WHILE)
            {
                cmd = procCMD(); //proc é o mesmo que próximo
                cmds.AddCommand(cmd);
            }
            return cmds;
        }

        public Command procProgram()
        {
            eat(TokenType.TT_PROGRAM);
            Command cmd = procCmdList();
            return cmd;
        }

        public Command Start()
        {
            Command cmd = procProgram();
            eat(TokenType.TT_END_OF_FILE);
            return cmd;
        }

        public void Advance()
        {
            this.token_current = this.lexicalAnalysis.LexicalAnalysisAN(this.token_current);
            Console.WriteLine($"tipo token: {this.token_current.type}, o token: {this.token_current.token}");
        }

        public void ShowError()
        {
            Environment.Exit(0);
        }

        public void eat(TokenType tokenType)
        {
            if (this.token_current.type == tokenType)
            {
                Advance();
            }
            else
            {
                ShowError();
            }
        }
    }
}