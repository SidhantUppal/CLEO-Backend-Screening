namespace DemoTask.Models
{
    public class CalendarDay
    {
        public int Day { get; set; } // Day of the month
        public bool IsSelectable { get; set; } // True if the day is selectable, false if it's greyed out
        public bool IsSelected { get; set; } // True if this is the currently selected day
        public int PositionsCount { get; set; } // Number of positions scheduled for that day (0 or more)
        public DateTime Date { get; set; } // The exact date (can be useful for future operations)
    }
}
