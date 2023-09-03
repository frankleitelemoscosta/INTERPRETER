//this is a library
using System;
using System.IO;

//main function

namespace Interpreter
{
  class Program
  {
    static void Main()
    {
        Lexema lex = new Lexema();
        string Walkingfile = "./dataset/exemplo.txt";

        try
        {
            // Check if file existe
            if (File.Exists(Walkingfile))
            {
                // Open the file using StreamReader
                using(StreamReader sr = new StreamReader(Walkingfile)){

                    int caractereLido;
                    bool sensor = false;
                    int counter = 0;
                    int aux_caracter;
                    int state = 1;

                    //in here before the read a file i add the check of the a struct have a ;, if yes construction the token and close this function

                    //in here

                    while ((caractereLido = sr.Read()) != -1)
                    {
                        switch(state)
                        {
                          case 1:
                            //if the readed caractere is 59 if the value is ;
                            if(caractereLido == 10)
                            { 
                              aux_caracter = caractereLido;
                              state = 1;
                            }else if(caracterLido == 32 || caractereLido == 9 || caracterLido == 13)
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
                              state = 6
                            }

                            break;
                        }//end of switch case

                  }

                }
           
            }
            else
            {
                Console.WriteLine("O arquivo não existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
  }
}

//end code
