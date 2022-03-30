using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShowService : IShowService

    {
        private readonly IShowRepository repository;
        public ShowService(IShowRepository repository)
        {
            this.repository = repository;
        }
        public void AddShowModel(ShowModel show)
        {
            repository.Add(new ShowEntity { Genre = show.Genre, Title = show.Title, Distribution = show.Distribution, Date=show.Date, NumberOfTickets=show.NumberOfTickets,NumberOfSaledTickets=show.NumberOfSaledTickets });
        }

        public bool DeleteShow(ShowModel show)
        {
            try
            {
                var DataList = repository.GetAllShows().Where(x => x.Id == show.Id).ToList();
                foreach (var item in DataList)
                {
                    repository.DeleteShow(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public List<ShowModel> GetAllShows()
        {
            List<ShowModel> result = new List<ShowModel>();
            foreach (var x in repository.GetAllShows())
            {
                result.Add(new ShowModel { Genre = x.Genre, Title = x.Title, Distribution = x.Distribution, Date = x.Date, NumberOfTickets = x.NumberOfTickets, NumberOfSaledTickets = x.NumberOfSaledTickets });
            }
            return result;
        }

        public ShowModel GetShowByID(int id)
           
        {
            ShowModel result = new ShowModel();
            var x = repository.GetShowByID(id);
            
            return new ShowModel { Id=x.Id, Genre = x.Genre, Title = x.Title, Distribution = x.Distribution, Date = x.Date, NumberOfTickets = x.NumberOfTickets, NumberOfSaledTickets = x.NumberOfSaledTickets };
        }

        public bool UpdateShow(ShowModel show)
        {
            try
            {
                var item = repository.GetAllShows().Where(x => x.Id == show.Id).FirstOrDefault();
                if (show.Title != null)
                {
                    item.Title = show.Title;
                }
                if (show.Genre!= null)
                {
                    item.Genre = show.Genre;
                }
                if(show.Distribution != null)
                {
                    item.Distribution = show.Distribution;
                }
                if(show.NumberOfSaledTickets != null)
                {
                    item.NumberOfSaledTickets = show.NumberOfSaledTickets;
                }
                if (show.NumberOfTickets != null)
                {
                    item.NumberOfTickets = show.NumberOfTickets;

                }
                repository.UpdateShow(item);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
