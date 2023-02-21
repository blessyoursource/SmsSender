using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsSender.Models
{
    public class DBHelper
    {
        public DBHelper()
        {

        }

        public void getSenderData()
        {
            using (SendDBContext db = new SendDBContext())
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
            using (SendDBContext db = new SendDBContext())
            {
                var responses = db.Responses.ToList();
                Console.WriteLine("List of Responses: ");
                foreach (Response r in responses)
                {
                    Console.WriteLine($"{r.IdR}.{r.Result}");
                }
                Console.WriteLine("\n");
            }
        }

        public int insertSender(string login, string password, long phone, string source, string text)
        {
            var id = 0;
            using (SendDBContext db = new SendDBContext())
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
            using (SendDBContext db = new SendDBContext())
            {
                var response = new Response()
                {
                    IdR = id,
                    Result = result,
                };
                db.Add(response);
                db.SaveChanges();
            }
        }

        public void getSenderResponse()
        {
            using (SendDBContext db = new SendDBContext())
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
                            Console.WriteLine($"{s.IdS}.{s.Login}.{s.Password}.{s.Source}.{s.Phone}.{s.Text}.{r.Result}");
                        }
                    }
                }
                Console.WriteLine("\n");
            }
        }


    }

}
