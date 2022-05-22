using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.CustomersDTO;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateCustomerDTO updateCustomerDto)
        {
            var customer = _context.Customer.FirstOrDefault(customer => customer.Id == id);
            if (customer == null) return NotFound();

            customer.Name = updateCustomerDto.Name;

            _context.SaveChanges();
            return NoContent();
        }


        [HttpPost]
        public IActionResult Create(CreateCustomerDTO createCustomerDto)
        {
            var customer = new Customer
            {
                Name = createCustomerDto.Name
            };
            _context.Customer.Add(customer);
            _context.SaveChanges();

            var customerDto = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name
            };
            return CreatedAtAction(nameof(GetOne), new { id = customer.Id }, customerDto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Customer.Select(customer => new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name
            }).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var customer = _context.Customer.Include(customer => customer.Id).FirstOrDefault(customer => customer.Id == id);
            if (customer == null)
                return NotFound();

            var customerDto = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Projects = customer.Projects.Select(project => new ProjectDTO
                {
                    Id = project.Id,
                    Name = project.Name
                }).ToList()
            };
            return Ok(customerDto);
        }
    }
}
