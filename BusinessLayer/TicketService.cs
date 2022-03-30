using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository repository;
        private readonly IShowRepository showRepository;

        public TicketService(ITicketRepository repository, IShowRepository showRepository)
        {
            this.repository = repository;
            this.showRepository = showRepository;
        }
        public int AddTicketModel(TicketModel ticket)
        {
            ShowEntity s = showRepository.GetShowByID(ticket.Show.Id);
            int nr = s.NumberOfSaledTickets;
            if(nr == s.NumberOfTickets)
            {
                return -1;
            }
            else
            {
                s.NumberOfSaledTickets++;
                repository.Add(new TicketEntity { ShowTitle = ticket.ShowTitle, SeatNumber = ticket.SeatNumber, SeatRow = ticket.SeatRow, Show = s });
                return s.NumberOfTickets - s.NumberOfSaledTickets;
            }
            
        }

        public bool DeleteTicket(TicketModel ticket)
        {
            ShowEntity s = showRepository.GetShowByID(ticket.Show.Id);
            try
            {
                var DataList = repository.GetAll().Where(x => x.Id == ticket.Id).ToList();
                foreach (var item in DataList)
                {
                    repository.DeleteTicket(item);
                    s.NumberOfSaledTickets--;
                    showRepository.UpdateShow(s);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public List<TicketModel> GetAllTickets()
        {
            List<TicketModel> output = new List<TicketModel>();
            var result = repository.GetAll().ToList();
            foreach (var x in result)
            {
                var ss = showRepository.GetAllShows().Where(y => y.Id == x.Show.Id).FirstOrDefault();
                ShowModel myShow = new ShowModel { Id = ss.Id, Genre = ss.Genre, Title = ss.Title, Distribution = ss.Distribution, Date = ss.Date, NumberOfSaledTickets = ss.NumberOfSaledTickets, NumberOfTickets = ss.NumberOfTickets };
                output.Add(new TicketModel { ShowTitle=x.ShowTitle, Id=x.Id, SeatNumber=x.SeatNumber, SeatRow=x.SeatRow, Show=myShow });
            }
            return output;
        }

        ///it does not work
        public List<TicketModel> GetAllTicketsByShowId(int id)
        {
            List<TicketModel> result = new List<TicketModel>();
            var myShow = showRepository.GetAllShows().Where(x => x.Id == id).FirstOrDefault();
            foreach (var x in repository.GetAll())
            {
                ShowModel show = new ShowModel { Id = myShow.Id, Genre = myShow.Genre, Title = myShow.Title, Distribution = myShow.Distribution, Date = myShow.Date, NumberOfSaledTickets = myShow.NumberOfSaledTickets, NumberOfTickets = myShow.NumberOfTickets };
                if(x.Show.Id == id)
                {
                    result.Add(new TicketModel { ShowTitle = x.ShowTitle, SeatNumber = x.SeatNumber, SeatRow = x.SeatRow, Show=show}); 

                }
            }
            return result;
        }

        public bool UpdateTicket(TicketModel ticket)
        {
            try
            {
                var itemTicket = repository.GetAll().Where(x => x.Id == ticket.Id).FirstOrDefault();
                if (ticket.SeatNumber != null)
                {
                    itemTicket.SeatNumber = ticket.SeatNumber;
                }
                if (ticket.SeatRow != null)
                {
                    itemTicket.SeatRow = ticket.SeatRow;
                }
                
                repository.UpdateTicket(itemTicket);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
