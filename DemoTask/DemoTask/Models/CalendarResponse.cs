namespace DemoTask.Models
{
    public class CalendarResponse
    {
        public CalendarHeader Header { get; set; }
        public List<CalendarDay> Days { get; set; }
    }
}
