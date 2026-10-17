using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrZhang
{
    class MyCustomAttribute : Attribute
    {

    }
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Player
    {
        [MyCustom()]
        public string name;
        public int atk;
        public int def;
        public int hp;
        public Position pos;
    }
}
