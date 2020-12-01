using System;
using Ticketing_Client.Context;
using Ticketing_Client.Model;

namespace Ticketing_Client
{
    public class DataService
    {
        public void List()
        {
            using (var ctx = new TicketContext())
            {
                System.Console.WriteLine("--TICKET LIST---");
                foreach(var item in ctx.Tickets)
                    System.Console.WriteLine($"{item.Id}-{item.Title}");
                System.Console.WriteLine("--------");
            }
        }
        public bool Add(Ticket t)
        {
            try {
                using (var ctx = new TicketContext())
                {
                  if (t != null)
                    {
                        ctx.Tickets.Add(t);
                        ctx.SaveChanges();

                    }
                        
                  else
                        Console.WriteLine("Ticket nullo :C");

                }
                return true;
            }
            catch(Exception e) {
                System.Console.WriteLine(e.Message);
                return false;
            }


        }
    }
}