using System;
using System.Collections.Generic;

namespace src.interpreter.command
{
    public class BlocksCommand : Command
    {
        public List<Command> list { get; set; }

        public BlocksCommand(int lines) : base(lines)
        {
            this.list = new List<Command>();
        }
        
        public void AddCommand(Command cmd)
        {
            this.list.Add(cmd);
        } 

        public override void execute()
        {
            foreach(Command a in this.list)
            {
                a.execute();             
            }
        }
    }
}