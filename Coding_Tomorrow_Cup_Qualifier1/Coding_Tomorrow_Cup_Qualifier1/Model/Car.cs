using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Car
    {

        public int Id { get; set; }
        public Pos Position { get; set; }
        public int Life { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
        public string NextCommand { get; set; }
        public int TransportedPedestrians { get; set; }
        public int PassengerId { get; set; }

        public Car(int id, Pos position, int life, int speed, string direction, string nextcommand, int transportedPredestrians)
        {
            Id = id;
            Position = position;
            Life = life;
            Speed = speed;
            Direction = direction;
            NextCommand = nextcommand;
            TransportedPedestrians = transportedPredestrians;
        }

        public Car(int id, Pos position, int life, int speed, string direction, string nextcommand, int transportedPredestrians, int passengerId)
        {
            Id = id;
            Position = position;
            Life = life;
            Speed = speed;
            Direction = direction;
            NextCommand = nextcommand;
            TransportedPedestrians = transportedPredestrians;
            PassengerId = passengerId;
        }
    }
}
