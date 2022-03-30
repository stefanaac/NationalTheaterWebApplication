using BusinessLayer.Contracts;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BusinessLayer.Factory
{
    public class MyCsvWriter : IFileWriter
    {
        private readonly ITicketService ticketService;



        public MyCsvWriter(ITicketService ticketService)
        {
            this.ticketService = ticketService;

        }

        public void ExportTickets(int showID)
        {
            List<TicketModel> tickets = ticketService.GetAllTickets();
            MemoryStream mem = new MemoryStream();
            StreamWriter writer = new StreamWriter(mem);
            var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField("Ticket ID");
            csvWriter.WriteField("Seat Number");
            csvWriter.WriteField("Seat Row");
            csvWriter.NextRecord();

            foreach (var t in tickets)
            {
                   if (t.Show.Id == showID)
                    {
                        csvWriter.WriteField(t.Id);
                        csvWriter.WriteField(t.SeatNumber);
                        csvWriter.WriteField(t.SeatRow);
                        csvWriter.NextRecord();
                        csvWriter.NextRecord();
                    }
             }
            writer.Flush();

            var res = Encoding.UTF8.GetString(mem.ToArray());
            File.WriteAllText("F:\\Facultate\\AN3-SEM2\\PS\\LAB\\UTCNSoftwareDesignLab\\lab3\\C#\\LayersOnWeb\\tickets.csv", res);
            Console.WriteLine(res);


        } 
    }

}
