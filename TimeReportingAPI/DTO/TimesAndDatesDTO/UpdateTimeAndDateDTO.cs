﻿using TimeReportingAPI.Data;

namespace TimeReportingAPI.DTO.TimesAndDatesDTO
{
    public class UpdateTimeAndDateDTO
    {
        public DateTime Date { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfMinutes { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public Project Project { get; set; }
    }
}
