using DemoTask.Models;
using DemoTask.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        // 1. Get calendar data for a specific month/year
        [HttpGet("GetCalendar/{year}/{month}")]
        public ActionResult<CalendarResponse> GetCalendar(int year, int month)
        {
            var calendar = _calendarService.GetCalendarData(year, month);
            return Ok(calendar);
        }

        // 2. Get calendar data for current month
        [HttpGet("GetCalendarForCurrentMonth")]
        public ActionResult<CalendarResponse> GetCalendarForCurrentMonth()
        {
            var calendar = _calendarService.GetCalendarData(DateTime.Now.Year, DateTime.Now.Month);
            return Ok(calendar);
        }

        // 3. Select a day (to mark it as selected)
        [HttpPost("SelectDay")]
        public ActionResult SelectDay([FromBody] SelectDayRequest request)
        {
            var result = _calendarService.SelectDay(request.Year, request.Month, request.Day);
            if (result) return Ok();
            return BadRequest("Day could not be selected.");
        }





        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
