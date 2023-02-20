using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS4B;

namespace SmsSender.DB
{
    public class DBHelper
    {
       public DBHelper()
        {

        }

        public void getSenderData()
        {
            using (SendContext db = new SendContext())
            {
                var senders = db.Senders.ToList();
                Console.WriteLine("List of Senders:");
                foreach (Sender s in senders)
                {
                    Console.WriteLine($"{s.IdS}.{s.Login}.{s.Password}.{s.Source}.{s.Phone}.{s.Text}");
                }
            }
        }
        public void getResponseData()
        {

        }

        public void insertSender(string login, string password, long phone, string source, string text)
        {
            using (SendContext db = new SendContext())
            {
                var senders = new Sender()
                {
                    Login = login,
                    Password = password,
                    Phone = phone.ToString(),
                    Source = source,
                    Text = text,
                };
                db.Add(senders);
                db.SaveChanges();
            }   
        }


    }
}
