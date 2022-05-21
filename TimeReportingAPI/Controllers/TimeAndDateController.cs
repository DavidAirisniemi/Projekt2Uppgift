using Microsoft.AspNetCore.Mvc;
using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.TimesAndDatesDTO;

namespace TimeReportingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeAndDateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeAndDateController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateTimeAndDateDTO updateTimeAndDateDto)
        {
            var project = _context.Project.FirstOrDefault(project => project.Id == id);
            if (project == null) return NotFound();


            

            _context.SaveChanges();
            return NoContent();
        }
    }
}
