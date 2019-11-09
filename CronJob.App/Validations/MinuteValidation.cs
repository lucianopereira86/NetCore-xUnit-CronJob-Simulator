using System;

namespace CronJob.App.Validations
{
    public class MinuteValidation: BaseValidation
    {
        public string GetMinute(string field)
        {
            try
            {
                return GeneralValidation("minute", field, 1, 60, () => callback(field));
            }
            catch (Exception)
            {
                return "WARN-006: Field 'minute' is invalid";
            }
        }

        private string callback(string field)
        {
            int minute = Convert.ToInt32(field);
            if (minute < 1 || minute > 60)
            {
                return "WARN-007: Field 'minute' must be from 1 to 60";
            }
            return minute.ToString();
        }
    }
}
