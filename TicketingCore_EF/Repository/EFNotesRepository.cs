using System;
using System.Collections.Generic;
using System.Text;
using TicketingCore.Model;
using TicketingCore.Repository;

namespace TicketingCore_EF.Repository
{
    public class EFNotesRepository : INoteRepository
    {
        public bool Add(Notes item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notes> Get(Func<Notes, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Notes GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Notes item)
        {
            throw new NotImplementedException();
        }
    }
}
