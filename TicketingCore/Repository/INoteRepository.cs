using System;
using System.Collections.Generic;
using System.Text;
using TicketingCore.Model;

namespace TicketingCore.Repository
{
    public interface INoteRepository: IRepository<Notes>
    {
        //Il vantaggio di questa specializzazione è che in questo modo posso 
        //definire metodi nuovi

    }
}
