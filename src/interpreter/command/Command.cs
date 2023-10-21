using System;

namespace src.interpreter.command
{

    public abstract class Command
    {
        public int counterline { get; set; }

        public Command(int lines)
        {
            this.counterline = lines;
        }

        public abstract void execute();

    }
}