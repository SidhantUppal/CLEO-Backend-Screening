using DemoTask.Models;

namespace DemoTask.Services
{
    public interface ICalendarService
    {
        CalendarResponse GetCalendarData(int year, int month);
        bool SelectDay(int year, int month, int day);
    }

    public class CalendarService : ICalendarService
    {
        public CalendarResponse GetCalendarData(int year, int month)
        {
            // Logic to generate calendar data for the given year and month
            // This includes generating available days, setting selectability, positions count, etc.
            var calendar = new CalendarResponse
            {
                Header = new CalendarHeader
                {
                    CurrentYear = year,
                    CurrentMonth = month,
                    AvailableYears = new List<int> { year - 1, year, year + 1 },
                    AvailableMonths = Enumerable.Range(1, 12).ToList()
                },
                Days = GenerateCalendarDays(year, month)
            };

            return calendar;
        }

        public bool SelectDay(int year, int month, int day)
        {
            // Logic to mark the day as selected.
            // This might involve storing the selection state in a database or cache.
            // For simplicity, this is just returning true for now.
            return true;
        }

        private List<CalendarDay> GenerateCalendarDays(int year, int month)
        {
            // Simplified logic to generate days for a specific month
            var days = new List<CalendarDay>();
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Example logic to mark some days as selectable/non-selectable
            for (int i = 1; i <= daysInMonth; i++)
            {
                days.Add(new CalendarDay
                {
                    Day = i,
                    IsSelectable = true, // Assume all days are selectable
                    IsSelected = false,   // By default, no day is selected
                    PositionsCount = GetPositionsCountForDay(year, month, i),
                    Date = new DateTime(year, month, i)
                });
            }

            // Example of adding greyed-out days from the previous month
            for (int i = 28; i <= 31; i++)
            {
                days.Insert(0, new CalendarDay
                {
                    Day = i,
                    IsSelectable = false, // Greyed out, not selectable
                    IsSelected = false,
                    PositionsCount = 0,
                    Date = new DateTime(year, month - 1, i)
                });
            }

            return days;
        }

        private int GetPositionsCountForDay(int year, int month, int day)
        {
            // This is where you'd check for positions in the database.
            // For simplicity, return a random value.
            return new Random().Next(0, 5);
        }
    }

}
