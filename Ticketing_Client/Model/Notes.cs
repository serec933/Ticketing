using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing_Client.Model
{
    public class Notes
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int TicketId { get; set;}  //Foreign key -> ticket

        //Navigation Property:
        public virtual Ticket Ticket { get; set; }
    }
}
