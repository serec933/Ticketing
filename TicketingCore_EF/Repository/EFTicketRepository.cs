using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketingCore.Model;
using TicketingCore.Repository;
using TicketingCore_EF.Context;

namespace TicketingCore_EF.Repository
{
    public class EFTicketRepository : ITicketiRepository
    {
        private TicketContext _ctx = new TicketContext();
        public bool Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            if (filter != null)
                return _ctx.Tickets.
                    Where(filter);

             return _ctx.Tickets;
        }

        public Ticket GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
