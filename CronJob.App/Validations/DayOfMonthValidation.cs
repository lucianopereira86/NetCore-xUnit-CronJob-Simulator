using System;

namespace CronJob.App.Validations
{
    public class DayOfMonthValidation : BaseValidation
    {
        public string GetDayOfMonth(string field)
        {
            try
            {
                return GeneralValidation("day of month", field, 1, 31, () => callback(field));
            }
            catch (Exception)
            {
                return "WARN-010: Field 'day of month' is invalid";
            }
        }

        private string callback(string field)
        {
            int day = Convert.ToInt32(field);
            if (day < 1 || day > 31)
            {
                return "WARN-011: Field 'day of month' must be from 1 to 31";
            }
            return day.ToString();
        }
    }
}
