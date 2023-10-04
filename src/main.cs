//this is a library
using System;
using System.IO;
using Interpreter;//add the file of the automato of the lexical analysis

//main function

namespace mainspace
{
  class Program
  {
    static void Main(string[] args)
    {
      string aux;
      bool check = false;
      bool key = true;
      int Savecaractere = 15000;
      int counter = 0;

      //try received
      foreach (string arg in args)
      {
        Console.WriteLine(arg);
      }
      aux = string.Join("",args);

	if(File.Exists(aux))
	{
	  try
	  {
	    using(StreamReader file  = new StreamReader(aux)){

		  Interpreter.Lexema lanalysis = new Interpreter.Lexema();
	      Interpreter.LexicalAnalysis lexical =  new Interpreter.LexicalAnalysis();
	
	      while(key == true)
	      {
			if(check == true)
			{
			  break;
			}

			  lanalysis = lexical.LexicalAnalysisAN(ref Savecaractere,file,ref check);
			  Console.WriteLine($"tipo token: {lanalysis.type}, o token: {lanalysis.token}");
	      }

	   }
	  }catch(IOException e)
	  {
	    Console.Write($"Erro ao abrir o arquivo: {e.Message}");
	  }
	}

      
      
    }
  }
}

//end code
