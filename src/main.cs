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
        string word = "";
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

                    while ((caractereLido = sr.Read()) != -1)
                    {
                        


                        //if the readed caractere is 32 so the read file is in a space or 10 if the value is \n end 59 if the value is ;
                        if(caractereLido == 59)
                        {
                          aux_caracter = caractereLido;
                          //in here i call the method that construct the token
                          //--
                          //in now i call the method and construct a token for ;
                        }
                        //if is a letter or undescore
                        if((caractereLido >= 65 && caractereLido <= 90) || (caractereLido >= 97 && caractereLido <= 122) || caractereLido == 95)
                        {
                          lex.token += (char)caractereLido;
                          
                          if(47 < (int)lex.token[0] && (int)lex.token[0] < 57 )
                          {
                            Console.WriteLine("a err of write, begin with a number and after write a letter.");
                            Console.Write("O primeiro caracter é: ");
                            Console.Write(lex.token[0]);
                            return;
                          }
                        }
                        //if is a number:
                        else if(caractereLido >= 47 && caractereLido <= 57)
                        {
                          lex.token += (char)caractereLido; 
                        }

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
