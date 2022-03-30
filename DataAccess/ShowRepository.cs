using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShowRepository : IShowRepository
    {
        private readonly TheaterDbContext theaterDbContext;
        public ShowRepository(TheaterDbContext theaterDbContext)
        {
            this.theaterDbContext = theaterDbContext;
        }
        public void Add(ShowEntity show)
        {
            theaterDbContext.Add(show);
            theaterDbContext.SaveChanges();
        }

        public void DeleteShow(ShowEntity show)
        {
            theaterDbContext.Remove(show);
            theaterDbContext.SaveChanges();
        }

        public List<ShowEntity> GetAllShows()
        {
            return theaterDbContext.ShowEntities.ToList();
        }

        public ShowEntity GetShowByID(int id)
        {
            return theaterDbContext.ShowEntities.Where(x =>x.Id==id).FirstOrDefault();
        }

        public void UpdateShow(ShowEntity show)
        {
            theaterDbContext.ShowEntities.Update(show);
            theaterDbContext.SaveChanges();
        }
    }
}
