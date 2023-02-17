using System;
using SmsSender;
using SMS4B;
using SmsSender.SmsSender;

namespace SmsSender
{
    class Program
    {
        static void Main(string[] args)
        {
            SMS4BSender sms4BSender = new SMS4BSender();
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
            
            sms4BSender.send();

            sms4BSender.abortClient();
            sms4BSender.checkClientStatus();
        }
    }
}
