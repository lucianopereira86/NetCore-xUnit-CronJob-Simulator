using System;

namespace CronJob.App.Validations
{
    public class HourValidation: BaseValidation
    {
        public string GetHour(string field)
        {
            try
            {
                return GeneralValidation("hour", field, 0, 23, () => callback(field));
            }
            catch (Exception)
            {
                return "WARN-008: Field 'hour' is invalid";
            }
        }

        private string callback(string field)
        {
            int hour = Convert.ToInt32(field);
            if (hour > 23)
            {
                return "WARN-009: Field 'hour' must be from 0 to 23";
            }
            return hour.ToString();
        }
    }
}
