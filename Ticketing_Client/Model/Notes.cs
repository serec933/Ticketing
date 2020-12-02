using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing_Client.Model
{
    public class Notes
    {
        //public Notes()
        //{
        //    Ticket = new Ticket();
        //}
        public int Id { get; set; }
        public string Comments { get; set; }
        public int TicketId { get; set;}  //Foreign key -> ticket
        public Byte[] RowVersion { get; set; }
        //Navigation Property:
        public virtual Ticket Ticket { get; set; }
    }
}
