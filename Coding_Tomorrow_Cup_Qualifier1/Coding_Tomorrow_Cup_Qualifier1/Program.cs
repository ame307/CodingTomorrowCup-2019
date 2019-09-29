using Coding_Tomorrow_Cup_Qualifier1.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declarations
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));

            List<string> messages;
            List<Car> cars = new List<Car>();
            List<Pedestrian> pedestrians = new List<Pedestrian>();
            List<Passenger> passengers = new List<Passenger>();
            List<Pos> routePositions = new List<Pos>();
            Passenger nearestPassenger = new Passenger();
            Routing path = Routing.GetInstance();
            Pos destinyPosition = new Pos(0,0);
            Car myCar;
            int gameid;
            int tick;
            bool isPassengerSearch = true;
            bool isDestinySearch = false; 
            string command = "";
            #endregion

            nearestPassenger.Position = new Pos(6000, 6000);
            do
            {
                gameid = tp.GetGameId();
                tick = tp.GetTick();
                pedestrians = tp.GetPedestrians();
                passengers = tp.GetPassengers();
                messages = tp.GetMessages();
                cars = tp.GetCars();
                myCar = cars[0];
                cars.RemoveAt(0);

                Console.WriteLine(tick);

                if (isPassengerSearch && !(myCar.Position.PosX == nearestPassenger.Position.PosX && myCar.Position.PosY == nearestPassenger.Position.PosY))
                {
                    nearestPassenger = PassengerSearching.Searching(path, myCar, passengers, nearestPassenger);
                    destinyPosition = nearestPassenger.Position;
                    routePositions = path.FindRoute(myCar.Position.PosX, myCar.Position.PosY, destinyPosition.PosX, destinyPosition.PosY, myCar).ToPositions();
                    path.SetTurnCommands();
                    WriteOutData.GetNearestPassangerPosition(myCar, nearestPassenger);
                    WriteOutData.WriteOutRoutePositions(routePositions);

                    isPassengerSearch = false;
                    isDestinySearch = true;


                }
                else if(isDestinySearch && myCar.Position.PosX == nearestPassenger.Position.PosX && myCar.Position.PosY == nearestPassenger.Position.PosY)
                {
                    destinyPosition = nearestPassenger.DestinyPosition;
                    routePositions = path.FindRoute(myCar.Position.PosX, myCar.Position.PosY, destinyPosition.PosX, destinyPosition.PosY, myCar).ToPositions();
                    path.SetTurnCommands();
                    WriteOutData.GetPathandEndPoint(myCar, destinyPosition);
                    WriteOutData.WriteOutRoutePositions(routePositions);

                    isDestinySearch = false;
                    isPassengerSearch = true;
                }

                command = path.FindRoute(myCar.Position.PosX, myCar.Position.PosY, destinyPosition.PosX, destinyPosition.PosY, myCar).ToCommand();
                WriteOutData.WriteOutCommands(command);
                var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + myCar.Id + "},\"command\": \"" + command + "\"}";
                string responseStr = WriteOutData.Response(p, json);
                tp = new TickProcessor(responseStr);
            } while (messages.Count == 0);

            p.Close();

            Console.ReadKey();
        }
    }
}
