using System;
using System.IO;
using Enum;

namespace src.lexico
{
  //this class is token class
  public partial class Lexema
  {
    public string token;
    public TokenType type { get; set; }
    public int counter { get; set; }

    public int counterLine { get; set; }
    public bool check { get; set; }
    public string vet;
    public int size;

    //methods
    public Lexema(string aux)
    {
      this.counter = -1;
      this.counterLine = 1;
      this.check = true;
      this.vet = aux;
      this.size = this.vet.Length;
    }

    public Lexema()
    {

    }

  }
}
