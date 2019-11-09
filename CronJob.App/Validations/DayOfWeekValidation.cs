using System;
using System.Collections.Generic;
using System.Linq;

namespace CronJob.App.Validations
{
    public class DayOfWeekValidation
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
            string value = "";
            if (field.Equals("?"))
            {
                var days = new int[7];
                for (int d = 0; d < 7; d++)
                    days[d] = d;
                value = string.Join(' ', days);
            }
            else
            {
                if (field.Contains(","))
                {
                    string[] days = field.Split(',');

                    foreach (string day in days)
                    {
                        bool isValid = daysOfWeek.Any(a => a.Key.Equals(day));
                        if (!isValid)
                        {
                            return "WARN-012: Field 'day of week' is invalid";
                        }
                    };

                    var positions = new List<int>();
                    days.ToList().ForEach(day =>
                    {
                        int position = daysOfWeek[day];
                        positions.Add(position);
                    });
                    value = string.Join(' ', positions.ToArray());
                }
                else
                {
                    bool isValid = daysOfWeek.Any(a => a.Key.Equals(field));
                    if (!isValid)
                    {
                        return "WARN-011: Field 'day of week' is invalid";
                    }
                    value = daysOfWeek[field].ToString();
                }
            }
            return value;
        }
    }
}
