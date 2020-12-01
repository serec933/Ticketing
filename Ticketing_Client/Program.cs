using System;
using Ticketing_Client.Model;

namespace Ticketing_Client
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
                        dataService.Add(ticket);
                        break;
                    case "l":
                        dataService.List();
                        break;
                    case "e":
                        //edit
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
    }
}
