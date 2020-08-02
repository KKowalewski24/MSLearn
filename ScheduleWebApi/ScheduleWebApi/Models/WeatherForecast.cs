using System;

namespace ScheduleWebApi.Models {

    public class WeatherForecast {

        /*----------------------- PROPERTIES REGION ----------------------*/
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        public string Summary { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
