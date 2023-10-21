using System;
using System.Collections.Generic;

namespace Utils
{

    public class Memory{
        public static Dictionary<string,int> map;
    
        public static int read(string name)
        {
            return map[name];
        }
        public static void write(string name, int value)
        {
            map[name] = value;
        }
    }
}