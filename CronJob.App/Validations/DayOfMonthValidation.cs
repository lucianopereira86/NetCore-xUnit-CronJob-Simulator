using System;

namespace CronJob.App.Validations
{
    public class DayOfMonthValidation
    {
        public string GetDayOfMonth(string field)
        {
            try
            {
                string value = "";
                if (field.Equals("?"))
                {
                    var days = new int[31];
                    for (int d = 1; d <= 31; d++)
                        days[d - 1] = d;
                    value = string.Join(' ', days);
                }
                else
                {
                    int day = Convert.ToInt32(field);
                    if (day < 1 || day > 31)
                    {
                        return "WARN-008: Field 'day of month' must be from 1 to 31";
                    }
                    value = day.ToString();
                }
                return value;
            }
            catch (Exception)
            {
                return "WARN-007: Field 'day of month' is invalid";
            }
        }
    }
}
