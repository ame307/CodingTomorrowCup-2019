using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1.Common
{
    static class PassengerSearching
    {
        public static Passenger Searching(Routing path, Car myCar, List<Passenger> passengers, Passenger nearestPassenger)
        {
            Console.WriteLine("-------Utas keresése--------");
            int nearestPassangerDistance = path.FindRoute(myCar.Position.PosX, myCar.Position.PosY, passengers[0].Position.PosX, passengers[0].Position.PosY, myCar).ToPositions().Count;
            nearestPassenger = passengers[0];
            for (int i = 1; i < passengers.Count; i++)
            {
                int passangerDistance = path.FindRoute(myCar.Position.PosX, myCar.Position.PosY, passengers[i].Position.PosX, passengers[i].Position.PosY, myCar).ToPositions().Count;
                if (nearestPassangerDistance > passangerDistance && nearestPassangerDistance != 2)
                {
                    nearestPassenger = passengers[i];
                }
            }
            return nearestPassenger;
        }
    }
}
