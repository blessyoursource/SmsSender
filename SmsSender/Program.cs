﻿using System;
using SmsSender;
using SMS4B;
using SmsSender.SmsSender;
using System.Linq;

namespace SmsSender
{
    class Program
    {
        static void Main(string[] args)
        {
            DB.DBHelper helper = new DB.DBHelper();
            helper.getSenderData();

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

            int id = helper.insertSender(sms4BSender.login, sms4BSender.password, sms4BSender.phone, sms4BSender.source, sms4BSender.text);
            string result = sms4BSender.send();

            helper.insertResponse(id, result);

            helper.getSenderData();
            helper.getResponseData();

            sms4BSender.abortClient();
            sms4BSender.checkClientStatus();
        }
    }
}
