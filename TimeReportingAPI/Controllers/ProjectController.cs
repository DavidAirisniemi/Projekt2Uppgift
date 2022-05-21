using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateProjectDTO updateProjectDto)
        {
            var project = _context.Project.FirstOrDefault(project => project.Id == id);
            if (project == null) return NotFound();

            project.Name = updateProjectDto.Name;

            _context.SaveChanges();
            return NoContent();
        }


        [HttpPost]
        public IActionResult Create(CreateProjectDTO createProjectDto)
        {
            var project = new Project
            {
                Name = createProjectDto.Name
            };
            _context.Project.Add(project);
            _context.SaveChanges();

            var projectDto = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
            };
            return CreatedAtAction(nameof(GetOne), new { id = project.Id }, projectDto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Project.Select(project => new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name
            }).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var project = _context.Project.Include(project => project.Id).FirstOrDefault(project => project.Id == id);
            if (project == null)
                return NotFound();

            var projectDto = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name
            };
            return Ok(projectDto);
        }
    }
}
