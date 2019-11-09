using System;

namespace CronJob.App.Validations
{
    public class MonthValidation: BaseValidation
    {
        public string GetMonth(string field)
        {
            try
            {
                return GeneralValidation("month", field, 1, 12, () => callback(field));
            }
            catch (Exception)
            {
                return "WARN-012: Field 'Month' is invalid";
            }
        }

        private string callback(string field)
        {
            int month = Convert.ToInt32(field);
            if (month < 1 || month > 12)
            {
                return "WARN-013: Field 'Month' must be from 1 to 12";
            }
            return month.ToString();
        }
    }
}
