using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLayer.Factory
{
    public class MyXmlWriter : IFileWriter
    {

        private readonly ITicketService ticketService;

        public MyXmlWriter(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        public void ExportTickets(int showID)
        {
            var result = new List<TicketModel>();
            XmlWriter xmlWriter = XmlWriter.Create("F:\\Facultate\\AN3-SEM2\\PS\\LAB\\UTCNSoftwareDesignLab\\lab3\\C#\\LayersOnWeb\\tickets.xml");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("tickets");
            foreach (var s in ticketService.GetAllTickets())
            {
                if (s.Show.Id == showID)
                {
                    xmlWriter.WriteStartElement("ticket");
                    xmlWriter.WriteAttributeString("TicketId", s.Id.ToString());
                    xmlWriter.WriteAttributeString("RowNumber", s.SeatRow.ToString());
                    xmlWriter.WriteAttributeString("SeatNumber", s.SeatNumber.ToString());
                    xmlWriter.WriteEndElement();
 

                }
            }
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
}
