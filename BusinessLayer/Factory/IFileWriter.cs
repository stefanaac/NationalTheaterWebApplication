using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public interface IFileWriter
    {
        void ExportTickets(int showID);
    }
}
