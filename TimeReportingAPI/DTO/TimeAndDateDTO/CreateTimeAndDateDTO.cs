using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.CustomersDTO;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.DTO.TimeAndDateDTO
{
    public class CreateTimeAndDateDTO
    {
        public DateTime Date { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfMinutes { get; set; }
        public string Description { get; set; }
        public CustomerDTO Customer { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
