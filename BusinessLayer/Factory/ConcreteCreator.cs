using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public class ConcreteCreator : Creator
    {
        private readonly ITicketService ticketService;
        public ConcreteCreator(ITicketService ticket)
        {
            this.ticketService = ticket;
        }
        public override IFileWriter getWriter(){
            return new MyCsvWriter(ticketService);
        }
    }


}
