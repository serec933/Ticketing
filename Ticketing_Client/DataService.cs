using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing_Client.Context;
using Ticketing_Client.Model;

namespace Ticketing_Client
{
    public class DataService
    {

            public List<Ticket> List()
            {
                using var ctx = new TicketContext();
            Console.WriteLine("-- TICKET LIST --");
            foreach (var t in ctx.Tickets)
            {
                Console.WriteLine($"[{t.Id}] {t.Title}");
                foreach (var x in t.Notes)
                {
                    Console.WriteLine(($"\t[{x.Id}] {x.Comments}"));
                }
            }
            Console.WriteLine("-----------------");
            return ctx.Tickets
                .ToList();
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
        public bool AddNotes(Notes t)
        {
            try
            {
                using (var ctx = new TicketContext())
                {
                    
                    if (t != null)
                    {
                        var ticket = ctx.Tickets.Find(t.TicketId);
                        if (ticket != null)
                        {
                            ticket.Notes.Add(t);  //ho già un ticket-> devo aggiungere una nota al ticket
                            //ctx.Notes.Add(t);
                            ctx.SaveChanges();
                        }
                        //OPPURE:
                        //t.Ticket=ticket;   -> associo il ticket alla nota
                       // ctx.Notes.Add(t);
                        //ctx.SaveChanges();
                    }

                    else
                        Console.WriteLine("Nota nulla :C");

                }
                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }


        }
        public Ticket GetTicketById(int id)
        {
            using var ctx = new TicketContext();
            SqlParameter idParam = new SqlParameter("@id", id);

            var result = ctx.Tickets.FromSqlRaw("exec stpGetTicketById @id", idParam).AsEnumerable();

            return result.FirstOrDefault();
        }

        public Ticket GetById(int id)
        {
            using var ctx = new TicketContext();
            if (id > 0)
                return ctx.Tickets.Find(id);
            return null;
        }

        internal bool Edit(Ticket t)
        {
            using var ctx = new TicketContext();
            try
            {
                if (t == null)
                    return false;

                ctx.Entry<Ticket>(t).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(("Error: " + ex.Message));
                return false;
            }
        }
    }
}