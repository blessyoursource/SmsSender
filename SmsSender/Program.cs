using System;
using SmsSender;
using SMS4B;
using SmsSender.SmsSender;
using System.Linq;
using SmsSender.Models;

namespace SmsSender
{
    class Program
    {
        static void Main(string[] args)
        {
            DBHelper helper = new DBHelper();
            helper.getSenderData();

            SMS4BSender sms4BSender = new SMS4BSender();
            SMS4BSender sms = new SMS4BSender(WSSMSoapClient.EndpointConfiguration.WSSMSoap);

            Console.WriteLine(sms4BSender.returnClient());
            sms4BSender.checkClientStatus();

            Console.WriteLine("Enter Login: ");
            sms4BSender.login = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            sms4BSender.password = Console.ReadLine();

            Console.WriteLine("Enter Source: ");
            sms4BSender.source = Console.ReadLine();

            Console.WriteLine("Enter Phone: ");
            sms4BSender.phone = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Text: ");
            sms4BSender.text = Console.ReadLine();

            int id = helper.insertSender(sms4BSender.login, sms4BSender.password, sms4BSender.phone, sms4BSender.source, sms4BSender.text);
            string result = sms4BSender.send();
            helper.insertResponse(id, result);

            helper.getSenderData();
            helper.getResponseData();
            helper.getSenderResponse();

            sms4BSender.abortClient();
            sms4BSender.checkClientStatus();
        }
    }
}
