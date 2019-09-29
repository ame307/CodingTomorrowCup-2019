using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Protocol
    {
        static TcpClient tcpClient = new TcpClient("31.46.64.35", 12323);
        static NetworkStream networkStream = tcpClient.GetStream();
        static StreamWriter streamWriter = new StreamWriter(networkStream);
        public NetworkStream GetNs() {
            return networkStream;
        }
        
        public string FirstMessageSender(FirstMessage firstmessage)
        {
            JObject token = new JObject();
            token.Add("token", FirstMessage.Firstmessage().Token);
            streamWriter.Write(token.ToString());
            streamWriter.Flush();
            return MessageBecome(networkStream, tcpClient);
        }

        public string MessageSender(string param)
        {
            streamWriter.Write(param.ToString());
            streamWriter.Flush();
            return MessageBecome(networkStream, tcpClient);
        }
        public string MessageBecome(NetworkStream networkStream, TcpClient tcpClient)
        {
            if (networkStream.CanRead)
            {
                byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                networkStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                List<byte> realValue = new List<byte>();
                int i = 0;
                while (bytes[i] != 0)
                {
                    realValue.Add(bytes[i]);
                    i++;
                }
                string returnValue = Encoding.UTF8.GetString(realValue.ToArray());
                return returnValue;
            }
            return "Can't read from stream";
        }

        public void Close()
        {
            tcpClient.Close();
        }
    }
}
