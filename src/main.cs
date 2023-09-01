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
                using (FileStream fileStream = new FileStream(Walkingfile,FileMode.Open,FileAccess.Read))
                {
                  using(StreamReader sr = new StreamReader(fileStream)){

                    int caractereLido;
                    long startPosition = fileStream.Position;
                    int counter = 0;
                    int counter_aux = 0;
                    int counter_for_free = 0;

                    while ((caractereLido = sr.Read()) != -1)
                    {
                        char caractere = (char)caractereLido;
                        if(caractere != ' ' && counter_for_free == 0)
                        {
                          counter++;
                          word += caractere;
                          counter_for_free = 0;
                        }
                        else{
                      
                          if(counter_for_free == 0){
                            fileStream.Seek(startPosition, SeekOrigin.Begin);
                            Console.WriteLine(word);
                            word = "";
                            while(counter_aux != (counter-1))
                            {
                              counter_aux++;
                              caractereLido = sr.Read();
                              caractere = (char)caractereLido;
                            }
                            counter_aux = 0;
                            Console.WriteLine(" ");
                            Console.Write(caractere);
                          }
                          else{
                            counter_for_free = 0;
                          }
                          counter_for_free ++;


                         }
                        // Console.Write(caractere);
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
