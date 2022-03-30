using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class ShowEntity
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public string Title { get; set; }

        public string Distribution { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfTickets { get; set; }

        public int NumberOfSaledTickets { get; set; }

       
    }
}
