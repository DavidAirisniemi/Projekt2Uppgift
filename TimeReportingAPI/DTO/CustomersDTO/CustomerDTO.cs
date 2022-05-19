using TimeReportingAPI.Data;
using TimeReportingAPI.DTO.ProjectsDTO;

namespace TimeReportingAPI.DTO.CustomersDTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectDTO> Projects { get; set; }
    }
}
