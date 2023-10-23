using System;
using System.IO;
using Enum;

namespace src.lexico
{
	public partial class LexicalAnalysis
	{
		public LexicalAnalysis()
		{ }
		public Lexema LexicalAnalysisAN(Lexema lanalysis)
		{

			Lexema lex = new Lexema();
			SymbolTable symbols = new SymbolTable();
			lex.counter = lanalysis.counter;
			lex.counterLine = lanalysis.counterLine;
      		lex.check = lanalysis.check;
			lex.vet = lanalysis.vet;
			lex.size = lanalysis.size;

			int state = 1;

			//in here before the read a file i add the check of the a struct have a ;, if yes construction the token and close this function

			while (state != 7 && state != 8)
			{
				lex.counter = lex.counter + 1;
				try
				{
					if (lex.vet[lex.counter] != ' '){}
				}catch(System.IndexOutOfRangeException e)
				{
					lex.type = TokenType.TT_END_OF_FILE;
					lex.token = "";
					lex.check = false;
					state = 9;
					break;
				}

				switch (state)
				{
					case 1:
						//if the readed caractere is 10 if the value is \n
						if (lex.vet[lex.counter] == '\n')
						{
							lex.counterLine++;
							state = 1;
						}
						else if (lex.vet[lex.counter] == ' ' || lex.vet[lex.counter] == '\t' || lex.vet[lex.counter] == '\r')
						{
							state = 1;
						}
						else if (lex.vet[lex.counter] == '#')//if is a # →	is a comentary
						{
							state = 2;
						}
						else if (lex.vet[lex.counter] == '=' || lex.vet[lex.counter] == '>' || lex.vet[lex.counter] == '<')//if is a = or > or <.
						{
							lex.token += lex.vet[lex.counter];
							state = 3;
						}
						else if (lex.vet[lex.counter] == '!')//if is a !.
						{
							lex.token += lex.vet[lex.counter];
							state = 4;
						}
						else if (lex.vet[lex.counter] == ';' || lex.vet[lex.counter] == '+' || lex.vet[lex.counter] == '-' || lex.vet[lex.counter] == '*' || lex.vet[lex.counter] == '/' || lex.vet[lex.counter] == '%')
						{
							lex.token += lex.vet[lex.counter];
							state = 7;
						}
						else if (char.IsLetter(lex.vet[lex.counter]) || lex.vet[lex.counter] == '_')//check if the caracter is a letter or undescore.
						{
							lex.token += lex.vet[lex.counter];
							state = 5;
						}
						else if (char.IsDigit(lex.vet[lex.counter]))
						{
							lex.token += lex.vet[lex.counter];
							state = 6;
						}
						else
						{
							lex.token += lex.vet[lex.counter];
							lex.type = TokenType.TT_INVALID_TOKEN;
							state = 8;
						}

						break;
					case 2:
						if (lex.vet[lex.counter] == '\n')//aqui vou ter de pensar o que fazer pois é nesse ponto que se trata do token do ;
						{
							lex.counterLine++;
							state = 1;
						}
						else
						{
							state = 2;
						}

						break;
					case 3:
						if (lex.vet[lex.counter] == '=')
						{
							lex.token += lex.vet[lex.counter];
							state = 7;

						}
						else
						{
							lex.counter = lex.counter - 1; //ungetc
							state = 7;//this means that the loop will finish, and the caractere will be save.
						}
						break;
					case 4:
						if (lex.vet[lex.counter] == '=')
						{
							lex.token += lex.vet[lex.counter];
							state = 7;
						}
						else
						{
							lex.token += lex.vet[lex.counter];
							lex.type = TokenType.TT_INVALID_TOKEN;//invalide toke → tem de colocar aqui depois
							lex.check = false;
							state = 8;
						}
						break;
					case 5:
						if (lex.vet[lex.counter] == '_' || char.IsLetter(lex.vet[lex.counter]) || char.IsDigit(lex.vet[lex.counter]))
						{
							lex.token += lex.vet[lex.counter];
							state = 5;
						}
						else
						{
							
							lex.counter = lex.counter - 1; 
							state = 7;
						}
						break;
					case 6:
						if (char.IsDigit(lex.vet[lex.counter]))
						{
							lex.token += lex.vet[lex.counter];
							state = 6;
						}
						else
						{
							lex.counter = lex.counter - 1;//ungectc → i will think a way for make lex of other form.
							lex.type = TokenType.TT_NUMBER;//TT_NUMBER → add after
							state = 8;

						}

						break;
					default:
						Console.WriteLine("invalid state");
						break;

				}//end of switch case


			}
			if (state == 7)
			{
				lex.type = symbols.Find(lex.token);     //tenho de ver o que fazer com isso	
			}


			return lex;
		}



	}
}
