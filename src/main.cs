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

                    while ((caractereLido = sr.Read()) != -1)
                    {
                        
                        //if the readed caractere is 32 so the read file is in a space
                        if(caractereLido != 32)
                        {
                          word +=(char)caractereLido;
                        }
                        else
                        {
                          Console.WriteLine(word);
                          word = "";
                          Console.WriteLine("");
                        }
                        
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
