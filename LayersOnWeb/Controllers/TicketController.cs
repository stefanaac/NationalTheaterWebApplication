using BusinessLayer.Contracts;
using BusinessLayer.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class TicketController : ControllerBase
        {
            private readonly ITicketService ticketService;
            private readonly IShowService showService;
            private readonly IFileWriter fileWriter;
        private readonly ITicketValidator ticketValidator;
        public TicketController(ITicketService ticketService, IShowService showService)
            {
                this.ticketService = ticketService;
                this.showService = showService;
               
            }


            [HttpGet("GetAllTickets")]
            //[Authorize]
            [AllowAnonymous]
            public IEnumerable<Ticket> Get()
            {
                var result = new List<Ticket>();
                foreach (var s in ticketService.GetAllTickets())
                {
                   
                     result.Add(new Ticket { ShowTitle = s.ShowTitle, SeatRow = s.SeatRow, SeatNumber = s.SeatNumber, Show=s.Show });

            }
                return result;
            }

           

            [HttpPost("SellTicket")]
            //[Authorize(Roles = "Cashier")]
            [AllowAnonymous]
            //[Auth]
            public String Post(Ticket s)
            {
            
                int t =ticketService.AddTicketModel(new TicketModel { ShowTitle = s.ShowTitle, SeatRow = s.SeatRow, SeatNumber = s.SeatNumber, Show=s.Show });
                if (t==-1)
                {
                    return "There are no more tickets for this show!!";
                }
                return "Added!";
            }




        //[Authorize(Roles = "Cashier")]
        [AllowAnonymous]
        [HttpDelete("CancelReservation")]
        public bool DeleteTicket(TicketModel ticket)
        {
            try
            {
                ticketService.DeleteTicket(ticket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //[HttpGet]
        [AllowAnonymous]
        [HttpGet("GetSoldTicketsFromAShow")]
        public IEnumerable<Ticket> GetAllSoldTickets(int id)
        {
            var result = new List<Ticket>();
            foreach (var t in ticketService.GetAllTicketsByShowId(id))
            {
               
                if(t.Show.Id == id)
                {
                    result.Add(new Ticket { ShowTitle = t.ShowTitle, SeatRow = t.SeatRow, SeatNumber = t.SeatNumber, Show=t.Show });
                }

                
            }
            return result;
        }

        //[Authorize(Roles = "Cashier")]
        [AllowAnonymous]
        [HttpPut("EditReservation")]
        public bool UpdateTicket(TicketModel ticket)
        {
            
            if (ticketValidator.ValiidateTicket(ticket)==false)
            {
                throw new Exception("The ticket info are not valid!!!!");
            }
            try
            {
                ticketService.UpdateTicket(ticket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        
        [HttpPost("ExportTicketsCsv")]
        //[Authorize(Roles = "Cashier")]
        [AllowAnonymous]
        //[Auth]
        public String Export(int id)
        {
            try
            {
                ConcreteCreator c = new ConcreteCreator(ticketService);
                c.getWriter().ExportTickets(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return ex.GetBaseException().ToString();
            }
            return "The tickets have been exported";

        }
        [HttpPost("ExportTicketsXml")]
        //[Authorize(Roles = "Cashier")]
        [AllowAnonymous]
        //[Auth]
        public String ExportXml(int id)
        {
            try
            {
                ConcreteCreatorB c = new ConcreteCreatorB(ticketService);
                c.getWriter().ExportTickets(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return ex.GetBaseException().ToString();
            }
            return "The tickets have been exported";

        }

    }
    
}
