using System;
using System.IO;

namespace Interpreter{
//this class is token class
  public partial class Lexema
  {
     public string token;
     public TokenType type;
     public StreamReader file;

     //methods
     public Lexema(string args)
      {
	if(File.Exists(args))
	{
	  using(this.file  = new StreamReader(args)){}
	}
      }
      public Lexema(){}
     

  }
}
