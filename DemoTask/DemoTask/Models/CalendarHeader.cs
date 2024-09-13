namespace DemoTask.Models
{
    public class CalendarHeader
    {
        public int CurrentYear { get; set; } // Year displayed on the calendar
        public int CurrentMonth { get; set; } // Month displayed on the calendar (1-12)
        public List<int> AvailableYears { get; set; } // Years that can be clicked through
        public List<int> AvailableMonths { get; set; } // Months that can be clicked through for the selected year
    }
}
