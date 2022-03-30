using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public class ConcreteCreatorB : Creator
    {
        private readonly ITicketService ticketService;
        public ConcreteCreatorB(ITicketService ticket)
        {
            this.ticketService = ticket;
        }
        public override IFileWriter getWriter()
        {
            return new MyXmlWriter(ticketService);
        }
    }
}
