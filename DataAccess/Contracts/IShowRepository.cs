using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IShowRepository
    {
        List<ShowEntity> GetAllShows();
        void Add(ShowEntity show);
        void DeleteShow(ShowEntity show);
        void UpdateShow(ShowEntity show);

        ShowEntity GetShowByID(int id);
    }
}
