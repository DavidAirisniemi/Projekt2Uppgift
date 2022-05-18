namespace TimeReportingAPI.Data
{
    public class TimeAndDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfMinutes { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
    }
}
