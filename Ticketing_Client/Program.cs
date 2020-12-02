using System;
using System.Collections.Generic;
using TicketingCore.Model;

namespace TicketingCore_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Ticket Management ---");
            bool quit = false;
            do 
            {
                Console.WriteLine("Comando: ");
                DataService dataService = new DataService();
                string command = Console.ReadLine();
                switch (command)
                {
                    case "q":
                        quit = true;
                        break;
                    case "a":
                        Ticket ticket = new Ticket();
                        ticket.Title=GetData("Titolo");
                        ticket.Description = GetData("Descrizione");
                        ticket.Category = GetData("Categoria");
                        ticket.Priority = GetData("Priorità");
                        ticket.Requestor = "Gianni";
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;
                        var result=dataService.Add(ticket);
                        Console.WriteLine("Operation " +(result ? "Completed" : "Failed"));
                        break;
                    case "l":
                        //Console.WriteLine("-- TICKET LIST --");
                        //foreach (var t in dataService.List())
                        //{
                        //    Console.WriteLine($"[{t.Id}] {t.Title}");
                        //    foreach (var x in t.Notes)
                        //    {
                        //        Console.WriteLine(($"[{x.Id}] {x.Comments}"));
                        //    }
                        //}
                        //Console.WriteLine("-----------------");
                        List<Ticket> l = (dataService.List());
                        break;
                    case "n":
                        //Aggiungi note
                        var ticketId = GetData("Ticket ID");
                        var comment = GetData("Commento");
                        int.TryParse(ticketId, out int tId);
                        Notes newNote = new Notes
                        {
                            TicketId = tId,
                            Comments = comment
                        };
                        var res=dataService.AddNotes(newNote);
                        Console.WriteLine("Operation " + (res ? "Completed" : "Failed"));
                        break;
                    case "e":
                        //edit
                        var ticketId1 = GetData("Ticket ID");
                        int.TryParse(ticketId1, out int tId1);
                        var ticket3 =dataService.GetById(tId1);
                        ticket3.Title = GetData("Titolo", ticket3.Title);
                        ticket3.Description = GetData("Descrizione", ticket3.Description);
                        ticket3.Category = GetData("Categoria", ticket3.Category);
                        ticket3.Priority = GetData("Priorità", ticket3.Priority);
                        ticket3.State = GetData("Stato", ticket3.State);
                        var editResult = dataService.Edit(ticket3);
                        Console.WriteLine("Operation " + (editResult ? "Completed" : "Failed"));
                        break;
                    case "d":
                        //delete
                        break;
                    default:
                        Console.WriteLine("comando sconosciuto");
                        break;
                }

            } while (!quit);
            Console.WriteLine("--- Bye Bye ---");
        }

        private static string GetData (string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            return value;
        }
        private static string GetData(string message,string valueIn)
        {
            Console.Write(message + $": ({valueIn})  ");
            string value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? valueIn : value;
        }
    }
}
