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
                using (StreamReader sr = new StreamReader(Walkingfile))
                {
                    int caractereLido;
                    while ((caractereLido = sr.Read()) != -1)
                    {
                        char caractere = (char)caractereLido;
                        // Faça algo com o caractere, por exemplo, exibi-lo na tela
                        Console.Write(caractere);
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
