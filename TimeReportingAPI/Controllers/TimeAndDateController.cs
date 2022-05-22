using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var timeAndDate = _context.TimeAndDate.FirstOrDefault(timeAndDate => timeAndDate.Id == id);
            if (timeAndDate == null) return NotFound();

            timeAndDate.Date = updateTimeAndDateDto.Date;
            timeAndDate.AmountOfHours = updateTimeAndDateDto.AmountOfHours;
            timeAndDate.AmountOfMinutes = updateTimeAndDateDto.AmountOfMinutes;
            timeAndDate.Description = updateTimeAndDateDto.Description;
            timeAndDate.Customer = updateTimeAndDateDto.Customer;
            timeAndDate.Project = updateTimeAndDateDto.Project;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CreateTimeAndDateDTO createTimeAndDateDto)
        {
            var timeAndDate = new TimeAndDate
            {
                Date = createTimeAndDateDto.Date,
                AmountOfHours = createTimeAndDateDto.AmountOfHours,
                AmountOfMinutes = createTimeAndDateDto.AmountOfMinutes,
                Description = createTimeAndDateDto.Description,
                Customer = createTimeAndDateDto.Customer,
                Project = createTimeAndDateDto.Project
            };
            _context.TimeAndDate.Add(timeAndDate);
            _context.SaveChanges();

            var timeAndDateDto = new TimeAndDateDTO
            {
                Date = timeAndDate.Date,
                AmountOfHours = timeAndDate.AmountOfHours,
                AmountOfMinutes = timeAndDate.AmountOfMinutes,
                Description = timeAndDate.Description,
                Customer = timeAndDate.Customer,
                Project = timeAndDate.Project
            };
            return CreatedAtAction(nameof(GetOne), new { id = timeAndDate.Id }, timeAndDateDto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.TimeAndDate.Select(timeAndDate => new TimeAndDateDTO
            {
                Date = timeAndDate.Date,
                AmountOfHours = timeAndDate.AmountOfHours,
                AmountOfMinutes = timeAndDate.AmountOfMinutes,
                Customer = timeAndDate.Customer,
                Project = timeAndDate.Project
            }).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var timeAndDate = _context.TimeAndDate.Include(timeAndDate => timeAndDate.Id).FirstOrDefault(timeAndDate => timeAndDate.Id == id);
            if (timeAndDate == null)
                return NotFound();

            var timeAndDateDto = new TimeAndDateDTO
            {
                Id = timeAndDate.Id,
                Date = timeAndDate.Date,
                AmountOfHours = timeAndDate.AmountOfHours,
                AmountOfMinutes = timeAndDate.AmountOfMinutes,
                Description = timeAndDate.Description,
                Customer = timeAndDate.Customer,
                Project = timeAndDate.Project
            };
            return Ok(timeAndDateDto);
        }
    }
}
