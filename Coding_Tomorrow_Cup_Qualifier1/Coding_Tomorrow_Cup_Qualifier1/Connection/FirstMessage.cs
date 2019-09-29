using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class FirstMessage
    {
        private readonly string token = "S3NXTghJpdr80PdfSKkQlmWQALHpisv46JMjRbZGcoRZ6ZswcGuxnN0aqyVzOSaUqIzN8DKJjmx";
        public string Token
        {
            get { return token; }
        }

        private static FirstMessage firstmessage;
        public static FirstMessage Firstmessage()
        {
            if(firstmessage == null)
            {
                firstmessage = new FirstMessage();
            }
            return firstmessage;
        }
    }
}
