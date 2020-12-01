using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ticketing_Client.Model
{
    public class Ticket
    {
        public int Id { get; set; } //riconosce la chiave primaria
        public DateTime IssueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
        public string Requestor { get; set; }

        //NAVIGATION PROPERTY
        public virtual List<Notes> Notes { get; set; } ///Monodirezionale: da ticket alle note
       

    }
}
