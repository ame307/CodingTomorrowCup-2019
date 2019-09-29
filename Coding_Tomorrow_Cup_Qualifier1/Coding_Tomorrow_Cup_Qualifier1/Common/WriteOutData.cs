using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    static class WriteOutData
    {
        public static void WriteOutMessages(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public static void WriteOutCommands(string cmd)
        {
            Console.WriteLine("\n\nÚtvonal utasítás: {0}",cmd);
            
        }

        public static void WriteOutRoutePositions(List<Pos> routePositions)
        {
            Console.WriteLine("\n\nÚtvonal pozíciók:");
            for (int i = 0; i < routePositions.Count; i++)
            {
                Console.WriteLine("({0};{1})", routePositions[i].PosX, routePositions[i].PosY);
            }
        }

        public static string Response(Protocol p, string json)
        {
            Console.WriteLine("Elküldött parancs: {0}", json);
            string response = p.MessageSender(json);
            Console.WriteLine("Szerver válasza: {0}", response);
            return response;
        }

        public static void GetNearestPassangerPosition(Car myCar, Passenger nearestPassenger)
        {
            Console.WriteLine("Kocsi induló pozíció: ({0};{1})", myCar.Position.PosX, myCar.Position.PosY);
            Console.WriteLine("Kocsi iránya: {0}", myCar.Direction);
            Console.WriteLine("Legközelebbi utas:\nId:{0}\nPosition: ({1};{2})\nDestiny position: ({3};{4})", nearestPassenger.Id, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY, nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY);
        }

        public static void GetPathandEndPoint(Car myCar, Pos destinyPosition)
        {
            Console.WriteLine("-------Útvonal keresése--------");
            Console.WriteLine("Kocsi induló pozíció: ({0};{1})", myCar.Position.PosX, myCar.Position.PosY);
            Console.WriteLine("Végpont: ({0};{1})", destinyPosition.PosX, destinyPosition.PosY);
        }
    }
}
