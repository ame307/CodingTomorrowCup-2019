using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Response
    {
        public int GameId { get; set; }

        public int Tick { get; set; }

        public int CarId { get; set; }

        public string Command { get; set; }

        public Response(int gameId, int tick, int carId, string command)
        {
            GameId = gameId;
            Tick = tick;
            CarId = carId;
            Command = command;
        }
        public static List<string> GetResponseFromDirections(List<string> legrovidebbut)
        {
            List<string> responses = new List<string>();
            Response temp;
            for (int i = 0; i < legrovidebbut.Count; i++)
            {
                temp = new Response(1, i + 2, 1, legrovidebbut[i]);
                string valami = JsonConvert.SerializeObject(temp);

                StringBuilder sb = new StringBuilder(valami);
                for (int j = 0; j < sb.Length; j++)
                {
                    if (sb[i].Equals(@"\"))
                    {
                        sb[i] = '\0';
                    }
                }

                responses.Add(valami);
            }
            return responses;
        }
        public string StringFromObject()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
