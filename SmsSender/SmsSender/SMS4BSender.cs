using System;
using System.Collections.Generic;
using System.Text;
using SmsSender.SmsSender;
using SMS4B;

namespace SmsSender.SmsSender
{
    public class SMS4BSender : ISmsSender
    {
        private WSSMSoapClient client;
        public string login { get; set; }
        public string password { get; set; }
        public string source { get; set; }
        public long phone { get; set; }
        public string text { get; set; }

        public SMS4BSender()
        {
            var client = new WSSMSoapClient(WSSMSoapClient.EndpointConfiguration.WSSMSoap12);
            this.client = client;
        }
        public WSSMSoapClient returnClient()
        {
            return client;
        }

        public void checkClientStatus()
        {
            Console.WriteLine("Client: " + client.State.ToString());
        }
        public void abortClient()
        {
            client.Abort();
        }
        public string send()
        {
            var result = client.SendSMSAsync(login, password, source, phone, text);
            Console.WriteLine(result.Result.ToString());
            return result.Result.ToString();
        }
    }

}
