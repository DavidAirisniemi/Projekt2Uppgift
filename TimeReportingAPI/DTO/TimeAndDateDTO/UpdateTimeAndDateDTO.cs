using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.DTO.TimeAndDateDTO
{
    public class UpdateTimeAndDateDTO
    {
        public DateTime Date { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfMinutes { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
