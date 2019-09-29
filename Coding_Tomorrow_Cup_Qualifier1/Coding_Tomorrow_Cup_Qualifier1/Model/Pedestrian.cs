using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Pedestrian
    {
        public int Id { get; set; }
        public Pos Position { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
        public string NextCommand { get; set; }

        public Pedestrian(int id, Pos position, int speed, string direction, string nextCommand)
        {
            Id = id;
            Position = position;
            Speed = speed;
            Direction = direction;
            NextCommand = nextCommand;
        }
    }
}
