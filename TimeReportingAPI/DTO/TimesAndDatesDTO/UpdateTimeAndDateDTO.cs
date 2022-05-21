using TimeReportingAPI.DTO.CustomersDTO;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.DTO.TimesAndDatesDTO
{
    public class UpdateTimeAndDateDTO
    {
        public DateTime Date { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfMinutes { get; set; }
        public string Description { get; set; }
        public CustomerDTO Customer { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
