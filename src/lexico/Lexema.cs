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
    public int Savecaractere;
    public int aux;
    public StreamReader file { get; set; }
    public int counter { get; set; }
    public int aux_caracter { get; set; }

    public int aux2_caracter { get; set; }

    public int counter_aux { get; set; }

    public bool key { get; set; }

    public int counterLine { get; set; }
    public bool check { get; set; }

    //methods
    public Lexema(string aux)
    {
      this.file = new StreamReader(aux);
      this.Savecaractere = 15000;
      this.counter = 0;
      this.aux_caracter = 0;
      this.aux2_caracter = 0;
      this.counter_aux = 0;
      this.key = false;
      this.counterLine = 1;
      this.check = false;
    }

    public Lexema()
    {

    }

  }
}
