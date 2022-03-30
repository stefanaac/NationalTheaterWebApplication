using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface  ITicketService
    {
        List<TicketModel> GetAllTickets();
        int AddTicketModel(TicketModel ticket);

        //update, delete la fel ca la show
        bool DeleteTicket(TicketModel ticket);

        bool UpdateTicket(TicketModel ticket);

        public List<TicketModel> GetAllTicketsByShowId(int id);

    }
}
