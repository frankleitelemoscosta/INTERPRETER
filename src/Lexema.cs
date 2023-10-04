using System;
using System.IO;
using Enum;

namespace Interpreter{
//this class is token class
  public partial class Lexema
  {
    public string token;
    public TokenType type{ get ; set; }
    public int Savecaractere; 
    public int aux;

    //methods
    public Lexema()
    {
      this.Savecaractere = 15000;
    }
      
  }
}
