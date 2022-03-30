using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TicketValidator : ITicketValidator
    {
        public bool ValiidateTicket(TicketModel ticketToValidate)
        {
            bool isValid = true;
            if (ticketToValidate.SeatNumber == 0 || ticketToValidate.SeatNumber < 0)
            {
                isValid = false;
            }
                 
            if (ticketToValidate.SeatRow == 0 || ticketToValidate.SeatRow < 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
