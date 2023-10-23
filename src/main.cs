//this is a library
using System;
using System.IO;
using src.lexico;
using src.syntatic;
using src.interpreter.command;

//main function

namespace mainspace
{
  class Program
  {
    static void Main(string[] args)
    {

      string aux;
      bool key_aux = true;
      string text;
            
      foreach (string arg in args)
      {
        Console.WriteLine(arg);
      }
      aux = string.Join("", args);
      
      text = File.ReadAllText(aux);


      Lexema lanalysis = new Lexema(text);
      LexicalAnalysis lexical = new LexicalAnalysis();
      /*while (key_aux == true)
      {
        if (lanalysis.check != true)
        {
          break;
        }
        lanalysis = lexical.LexicalAnalysisAN(lanalysis);
        Console.WriteLine($"tipo token: {lanalysis.type}, o token: {lanalysis.token}");
      }*/
      SyntaticalAnalysis sintatical = new SyntaticalAnalysis(lanalysis,lexical);

      BlocksCommand cmd = (BlocksCommand)sintatical.Start();
      cmd.execute();

    }
  }
}

//end code
