using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService showService;
        public ShowController(IShowService showService)
        {
            this.showService = showService;
        }


        [HttpGet]
        [Authorize]
        public IEnumerable<Show> Get()
        {
            var result = new List<Show>();
            foreach (var s in showService.GetAllShows())
            {
                result.Add(new Show { Genre = s.Genre, Title = s.Title, Distribution = s.Distribution, Date = s.Date, NumberOfTickets = s.NumberOfTickets, NumberOfSaledTickets = s.NumberOfSaledTickets });
            }
            return result;
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpDelete("DeleteShow")]
        public bool DeleteShow(ShowModel show)
        {
            try
            {
                showService.DeleteShow(show);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpPut("UpdateShow")]
        public bool UpdateShow(ShowModel show)
        {
            try
            {
                showService.UpdateShow(show);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        //[Auth]
        public void Post(Show s)
        {
            showService.AddShowModel(new ShowModel { Genre = s.Genre, Title = s.Title, Distribution = s.Distribution, Date = s.Date, NumberOfTickets = s.NumberOfTickets, NumberOfSaledTickets = s.NumberOfSaledTickets });
        }

        //GET Show by Id
        [HttpGet("GetShowById")]
        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        public Object GetShowByID(int id)
        {
            try
            {
                var result = showService.GetShowByID(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
    }
}
