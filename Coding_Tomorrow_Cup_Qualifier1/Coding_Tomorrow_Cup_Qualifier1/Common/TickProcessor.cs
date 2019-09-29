using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class TickProcessor
    {
        public JObject Tick { get; set; }

        public TickProcessor(string fromServer)
        {           
            if(fromServer == "")
            {
                Tick = null;
            }
            else
            {
                Tick = JObject.Parse(fromServer);
            } 
        }

        public int GetGameId()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["game_id"];
        }

        public int GetTick()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["tick"];
        }

        public int GetCarId()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["car_id"];
        }

        public List<Car> GetCars()
        {
            JArray jsonCars = (JArray)Tick["cars"];
            List<Car> cars = new List<Car>();

            for (int i=0;i<jsonCars.Count;i++)
            {
                Car temp = new Car((int)jsonCars[i]["id"], new Pos((int)jsonCars[i]["pos"]["x"], (int)jsonCars[i]["pos"]["y"]), (int)jsonCars[i]["life"],
                (int)jsonCars[i]["speed"], (string)jsonCars[i]["direction"], (string)jsonCars[i]["command"],
                (int)jsonCars[i]["transported"]);

                cars.Add(temp);                
            }

            return cars;
        }

        public List<Pedestrian> GetPedestrians()
        {
            JArray jsonPedestrians = (JArray)Tick["pedestrians"];
            List<Pedestrian> pedestrians = new List<Pedestrian>();

            for (int i = 0; i < jsonPedestrians.Count; i++)
            {
                Pedestrian temp = new Pedestrian((int)jsonPedestrians[i]["id"], new Pos((int)jsonPedestrians[i]["pos"]["x"], (int)jsonPedestrians[i]["pos"]["y"]), (int)jsonPedestrians[i]["speed"],
                (string)jsonPedestrians[i]["direction"], (string)jsonPedestrians[i]["next_command"]);

                pedestrians.Add(temp);
            }

            return pedestrians;
        }

        public List<Passenger> GetPassengers()
        {
            JArray jsonPassengers = (JArray)Tick["passengers"];
            List<Passenger> passengers = new List<Passenger>();

            for (int i = 0; i < jsonPassengers.Count; i++)
            {
                Passenger temp = new Passenger((int)jsonPassengers[i]["id"], new Pos((int)jsonPassengers[i]["pos"]["x"], (int)jsonPassengers[i]["pos"]["y"]),
                new Pos((int)jsonPassengers[i]["dest_pos"]["x"], (int)jsonPassengers[i]["dest_pos"]["y"]));

                passengers.Add(temp);
            }

            return passengers;
        }

        public List<string> GetMessages() 
        {
            JArray jsonMessages = (JArray)Tick["messages"];
            List<string> messages = new List<string>();

            for (int i = 0; i < jsonMessages.Count; i++)
            {
                messages.Add(jsonMessages[i].ToString());
            }

            return messages;
        }
       
    }
}
