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
    
      LexicalAnalysis lanalysis = new LexicalAnalysis();  
      lanalysis(args);//pass to construct the name file

    }
  }
}

//end code
