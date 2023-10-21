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

			int state = 1;
			int caractereLido = 0;

			caractereLido = lanalysis.file.Read();

			if (caractereLido == -1)
			{
				lanalysis.check = true;//use for break the read
			}

			//in here before the read a file i add the check of the a struct have a ;, if yes construction the token and close this function

			while (state != 7 && state != 8 && lanalysis.check != true)
			{

				switch (state)
				{
					case 1:
						//if the readed caractere is 10 if the value is \n
						if (caractereLido == 10)
						{
							//aux_caracter = caractereLido;
							lanalysis.counterLine++;
							state = 1;
						}
						else if (caractereLido == 32 || caractereLido == 9 || caractereLido == 13)
						{
							state = 1;
						}
						else if (caractereLido == 35)//if is a # →	is a comentary
						{
							state = 2;
						}
						else if (caractereLido == 61 || caractereLido == 62 || caractereLido == 60)//if is a = or > or <.
						{
							lex.token += (char)caractereLido;
							state = 3;
						}
						else if (caractereLido == 33)//if is a !.
						{
							lex.token += (char)caractereLido;
							state = 4;
						}
						else if (caractereLido == 59 || caractereLido == 43 || caractereLido == 45 || caractereLido == 42 || caractereLido == 47 || caractereLido == 37)
						{
							lex.token += (char)caractereLido;
							state = 7;
						}
						else if ((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122) || caractereLido == 95)//check if the caracter is a letter or undescore.
						{
							lex.token += (char)caractereLido;
							state = 5;
						}
						else if (caractereLido >= 48 && caractereLido <= 57)
						{
							lex.token += (char)caractereLido;
							state = 6;
						}
						else
						{
							if (caractereLido == -1)
							{
								lex.type = TokenType.TT_END_OF_FILE;
								state = 8;
							}
							else
							{
								lex.token += (char)caractereLido;
								lex.type = TokenType.TT_INVALID_TOKEN;
								state = 8;
							}
						}

						break;
					case 2:
						if (caractereLido == 10)//aqui vou ter de pensar o que fazer pois é nesse ponto que se trata do token do ;
						{
							lanalysis.counterLine++;
							state = 1;
						}
						else if (caractereLido == -1)
						{
							lex.type = TokenType.TT_END_OF_FILE;
							state = 8;
						}
						else
						{
							state = 2;
						}

						break;
					case 3:
						if (caractereLido == 61)
						{
							lex.token += (char)caractereLido;
							state = 7;
							lanalysis.Savecaractere = caractereLido;
						}
						else
						{
							if (caractereLido != -1)
							{
								//aqui é outro lugar onde vou ter de fazer alguma coisa
							}
							state = 7;//this means that the loop will finish, and the caractere will be save.
						}
						break;
					case 4:
						if (caractereLido == 61)
						{
							lex.token += (char)caractereLido;
							state = 7;
						}
						else
						{
							if (caractereLido == -1)
							{
								lex.type = TokenType.TT_UNEXPECTED_EOF; //unexpectede eof → tem de colocar aqui depois
								state = 8;
							}
							else
							{
								lex.type = TokenType.TT_INVALID_TOKEN;//invalide toke → tem de colocar aqui depois
								state = 8;
							}
						}
						break;
					case 5:
						if (caractereLido == 95 || ((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122)) || (caractereLido >= 47 && caractereLido <= 57))
						{
							lex.token += (char)caractereLido;
							state = 5;
						}
						else
						{
							if (caractereLido != -1)
							{
								lanalysis.Savecaractere = caractereLido;
							}
							state = 7;
						}
						break;
					case 6:
						if ((caractereLido >= 47 && caractereLido <= 57))
						{
							lex.token += (char)caractereLido;
							state = 6;
						}
						else
						{
							if (caractereLido != -1)
							{
								lanalysis.Savecaractere = caractereLido;//ungectc → i will think a way for make this of other form.
							}

							lex.type = TokenType.TT_NUMBER;//TT_NUMBER → add after
							state = 8;

						}

						break;
					default:
						Console.WriteLine("invalid state");
						break;

				}//end of switch case
				if (lanalysis.Savecaractere != 15000)
				{
					caractereLido = lanalysis.aux_caracter;
					lanalysis.Savecaractere = 15000;//change for the standard number for in future changes not make problems
					lanalysis.key = true;
					lanalysis.counter = 1;
				}


				lanalysis.aux_caracter = caractereLido;

				if (lanalysis.key != true)
				{
					caractereLido = lanalysis.file.Read();
				}
				else if (lanalysis.key == true && lanalysis.counter == 0)
				{
					caractereLido = lanalysis.aux2_caracter;
					lanalysis.key = false;
				}
				else
				{
					lanalysis.counter = 0;
				}

				if (lanalysis.key != true) lanalysis.aux2_caracter = caractereLido;



			}
			if (state == 7)
			{
				lex.type = symbols.Find(lex.token);     //tenho de ver o que fazer com isso	
			}


			lex.file = lanalysis.file;
			lex.Savecaractere = lanalysis.Savecaractere;
			lex.counter = lanalysis.counter;
			lex.aux_caracter = lanalysis.aux_caracter;
			lex.aux2_caracter = lanalysis.aux2_caracter;
			lex.key = lanalysis.key;
			lex.counter_aux = lanalysis.counter_aux;
			lex.counterLine = lanalysis.counterLine;
			lex.check = lanalysis.check;
			return lex;
		}



	}
}

