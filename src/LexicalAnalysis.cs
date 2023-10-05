using System;
using System.IO;
using Enum;

namespace Interpreter 
{
public partial class LexicalAnalysis{
  public LexicalAnalysis()
  {}
  public Lexema LexicalAnalysisAN(ref int Savecaractere,StreamReader file,ref bool check,ref int aux_caracter, ref int counter, ref bool key,ref int aux2_caracter,ref int counter_aux)
  {
	
	Lexema lex = new Lexema();
	SymbolTable symbols = new SymbolTable();
    
	int state = 1;
	int caractereLido = 0;
	
		caractereLido = file.Read();
	
	
	
	
		//in here before the read a file i add the check of the a struct have a ;, if yes construction the token and close this function

	  while (state != 7 && state != 8){
	  		if(caractereLido == -1)
	    {
	      check = true;
	    }
	  
		switch(state)
		{
		  case 1:	 
			//if the readed caractere is 10 if the value is \n
		    if(caractereLido == 10)
		    { 
		      //aux_caracter = caractereLido;
		      state = 1;
		    }else if(caractereLido == 32 || caractereLido == 9 || caractereLido == 13)
		    {
		      state = 1;
		    }else if(caractereLido == 35)//if is a # →	is a comentary
		    {
		      state = 2;
		    }else if(caractereLido == 61 || caractereLido == 62 || caractereLido == 60)//if is a = or > or <.
		    {
		      lex.token += (char)caractereLido;
		      state = 3;
		    }else if(caractereLido == 33)//if is a !.
		    {
		      lex.token += (char)caractereLido;
		      state = 4;
		    }else if(caractereLido == 59 || caractereLido == 43 || caractereLido == 45 || caractereLido == 42 || caractereLido == 47 || caractereLido == 37 )
		    {
		      lex.token += (char)caractereLido;
		      state = 7;
		    }else if((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122) || caractereLido == 95)//check if the caracter is a letter or undescore.
		    {
		      lex.token += (char)caractereLido;
		      state = 5;
		    }
		    else if(caractereLido >= 48 && caractereLido <= 57) 
		    {
		      lex.token += (char)caractereLido; 
		      state = 6; 
		    }
		    else{ 
		      if(caractereLido == -1) {
				lex.type = TokenType.TT_END_OF_FILE;
				state = 8;
		      }else
		      {
				lex.token += (char)caractereLido;
				lex.type = TokenType.TT_INVALID_TOKEN;
				state = 8;
		      }
		    }

		    break;
		  case 2:
		    if(caractereLido == 10)//aqui vou ter de pensar o que fazer pois é nesse ponto que se trata do token do ;
		    {
		      state = 1;
		    }
		    else if(caractereLido == -1)
		    {
			  lex.type = TokenType.TT_END_OF_FILE;
		      state = 8;
		    }else
		    {
		      state = 2;
		    }

		    break;
		  case 3:
		    if(caractereLido == 61)
		    {
		      lex.token += (char)caractereLido;
		      state = 7;
			  Savecaractere = caractereLido;
		    }
		    else
		    {
		      if(caractereLido != -1)
		      {
				//aqui é outro lugar onde vou ter de fazer alguma coisa
		      }
		      state = 7;//this means that the loop will finish, and the caractere will be save.
		    }
		    break;
		  case 4:
		    if(caractereLido == 61)
		    {
		      lex.token += (char)caractereLido;
		      state = 7;
		    }
		    else
		    {
		      if(caractereLido == -1)
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
		    if(caractereLido == 95 || ((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122)) || (caractereLido >= 47 && caractereLido <= 57))
		      {
		      lex.token += (char)caractereLido;
		      state = 5;
		      }
		    else{
		      if(caractereLido != -1)
			{
			  Savecaractere = caractereLido;
			}
		      state = 7;
		      }
		    break;
		  case 6:
		    if((caractereLido >= 47 && caractereLido <= 57))
		      {
				lex.token += (char)caractereLido;
				state = 6;
		      }
		    else{
		      if(caractereLido != -1)
			{
			  Savecaractere = caractereLido;//ungectc → i will think a way for make this of other form.
			}
			
		      lex.type = TokenType.TT_NUMBER;//TT_NUMBER → add after
		      state = 8;

		      }

		    break;
		  default:
		      Console.WriteLine("invalid state");
		    break;

		}//end of switch case
		if(Savecaractere != 15000)
	  {
			caractereLido = aux_caracter;
			Savecaractere = 15000;//change for the standard number for in future changes not make problems
			key = true;
			counter = 1;
	  }
	  

		aux_caracter = caractereLido;

		if(key != true)
		{
	    	caractereLido = file.Read();	    
		}else if(key == true && counter == 0)
		{
			caractereLido = aux2_caracter;
			key = false;
		}else
		{
			counter = 0;
		}

		if(key != true)aux2_caracter = caractereLido;



	  }
		  if(state == 7)
		    {
			lex.type = symbols.Find(lex.token);		//tenho de ver o que fazer com isso	
		    }
	   
	return lex;   
	}

 
	
 }
}

