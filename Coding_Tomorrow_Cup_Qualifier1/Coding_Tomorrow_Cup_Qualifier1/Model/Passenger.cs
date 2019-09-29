using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Passenger
    {

        public Passenger() { }

        public int Id { get; set; }
        public Pos Position { get; set; }
        public Pos DestinyPosition { get; set; }
        public int CarId { get; set; }

        public Passenger(int id, Pos position, Pos destinyPostion)
        {
            Id = id;
            Position = position;
            DestinyPosition = destinyPostion;
        }

        public Passenger(int id, Pos position, Pos destinyPostion, int carId)
        {
            Id = id;
            Position = position;
            DestinyPosition = destinyPostion;
            CarId = carId; 
        }

   }
}
