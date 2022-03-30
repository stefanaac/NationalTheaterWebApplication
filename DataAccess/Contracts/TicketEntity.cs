using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public string ShowTitle { get; set; }

        public int SeatRow { get; set; }

        public int SeatNumber { get; set; }

        public ShowEntity Show{ get; set;}
    }
}
