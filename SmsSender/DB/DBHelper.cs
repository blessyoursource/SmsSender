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
                Console.WriteLine("List of Senders: ");
                foreach (Sender s in senders)
                {
                    Console.WriteLine($"{s.IdS}.{s.Login}.{s.Password}.{s.Source}.{s.Phone}.{s.Text}");
                }
                Console.WriteLine("\n");
            }
        }
        public void getResponseData()
        {
            using (SendContext db = new SendContext())
            {
                var responses = db.Responses.ToList();
                Console.WriteLine("List of Responses: ");
                foreach (Response r in responses)
                {
                    Console.WriteLine($"{r.IdR}.{r.Guid}.{r.Response1}");
                }
                Console.WriteLine("\n");
            }
        }

        public int insertSender(string login, string password, long phone, string source, string text)
        {
            var id = 0;
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
                id = senders.IdS;
            }
            return id;
        }

        public void insertResponse(int id, string result)
        {
            using (SendContext db = new SendContext())
            {
                var response = new Response()
                {
                    IdR = id,
                    Response1 = result,
                };
                db.Add(response);
                db.SaveChanges();
            }
        }

        public void getSenderResponse()
        {
            using (SendContext db = new SendContext())
            {
                var senders = db.Senders.ToList();
                var responses = db.Responses.ToList();

                Console.WriteLine("List of Sender Responses: ");

                foreach (Sender s in senders)
                {
                    foreach (Response r in responses)
                    {
                        if (s.IdS == r.IdR)
                        {
                            Console.WriteLine($"{s.IdS}.{s.Login}.{s.Password}.{s.Source}.{s.Phone}.{s.Text}.{r.Guid}.{r.Response1}");
                        }
                    }
                }
                Console.WriteLine("\n");
            }
        }

    }
}
