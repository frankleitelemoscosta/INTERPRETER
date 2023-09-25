using System;
using System.IO;
using Interpreter;

namespace Interpreter 
{
public partial class Lexema{
  public Lexema LexicalAnalysis()
  {
	Lexema lex = new Lexema();
        try
        {

            int caractereLido;
            bool sensor = false;
            int counter = 0;
            int aux_caracter;
            int state = 1;

            //in here before the read a file i add the check of the a struct have a ;, if yes construction the token and close this function

            //in here

          while (state != 7 && state != 8)
          {
                caractereLido = this.file.Read();
                switch(state)
                {
                  case 1:
                    //if the readed caractere is 10 if the value is \n
                    if(caractereLido == 10)
                    { 
                      aux_caracter = caractereLido;
                      state = 1;
                    }else if(caractereLido == 32 || caractereLido == 9 || caractereLido == 13)
                    {
                      state = 1;
                    }else if(caractereLido == 35)//if is a # →  is a comentary
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
                    }else if(caractereLido >= 47 && caractereLido <= 57)
                    {
                      lex.token += (char)caractereLido;
                      state = 6;
                    }else{
                      if(caractereLido == -1)
                      {
                        state = 8;
                      }else
                      {
                        lex.token += (char)caractereLido;
                        state = 8;
                      }
                    }

                    break;
                  case 2:
                    if(caractereLido == 10)//aqui vou ter de pensar o que fazer pois é nesse ponto que se trata do token do ;
                    {
                      lex.token += (char)caractereLido;
                      state = 1;
                    }
                    else if(caractereLido == -1)
                    {
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
                    }
                    else
                    {
                      if(caractereLido != -1)
                      {
                        //aqui é outro lugar onde vou ter de fazer alguma coisa
                      }
                      state = 7;
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
                        //unexpectede eof → tem de colocar aqui depois
                        state = 8;
                      }
                      else
                      {
                        //invalide toke → tem de colocar aqui depois
                        state = 8;
                      }
                    }
                    break;
                  case 5:
                    if(caractereLido == 95 || ((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122)) || (caractereLido >= 47 && caractereLido <= 57))
                      {
                      lex.token += (char)caractereLido;
                      state = 6;
                      }
                    else{
                      if(caractereLido != 1)
                        {
                          //ungect→ add after.
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
                          //ungectc → i will think a way for make this of other form.
                        }
                        
                      //TT_NUMBER → add after
                      state = 8;

                      }

                    break;
                  default:
                      Console.WriteLine("invalid state");
                    break;

                }//end of switch case

          }
                  if(state == 7)
                    {

                    }
                
           
           
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
	}
 
return lex;
 }
}
}
