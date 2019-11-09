using System;
using System.Collections.Generic;
using System.Linq;

namespace CronJob.App.Validations
{
    public class DayOfWeekValidation: BaseValidation
    {
        private readonly Dictionary<string, int> daysOfWeek;

        public DayOfWeekValidation()
        {
            daysOfWeek = new Dictionary<string, int>();
            daysOfWeek.Add("SUN", 0);
            daysOfWeek.Add("MON", 1);
            daysOfWeek.Add("TUE", 2);
            daysOfWeek.Add("WED", 3);
            daysOfWeek.Add("THU", 4);
            daysOfWeek.Add("FRI", 5);
            daysOfWeek.Add("SAT", 6);
        }
        public string GetDayOfWeek(string field)
        {
            return GeneralValidation("day of week", field, 0, 6, () => callback(field), daysOfWeek);
        }

        private string callback(string field)
        {
            bool isValid = daysOfWeek.Any(a => a.Key.Equals(field));
            if (!isValid)
            {
                return "WARN-014: Field 'day of week' is invalid";
            }
            return daysOfWeek[field].ToString();
        }
    }
}
