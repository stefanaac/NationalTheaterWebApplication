using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ITicketRepository
    {
        List<TicketEntity> GetAll();
        void Add(TicketEntity ticket);
        void DeleteTicket(TicketEntity ticket);
        void UpdateTicket(TicketEntity ticket);

        TicketEntity GetTicketByID(int id);
    }
}
