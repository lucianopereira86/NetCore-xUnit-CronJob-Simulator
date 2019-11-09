using System;

namespace CronJob.App.Validations
{
    public class MonthValidation
    {
        public string GetMonth(string field)
        {
            try
            {
                string value = "";
                if (field.Equals("*"))
                {
                    var months = new int[12];
                    for (int m = 1; m <= 12; m++)
                        months[m - 1] = m;
                    value = string.Join(' ', months);
                }
                else
                {
                    int month = Convert.ToInt32(field);
                    if (month < 1 || month > 12)
                    {
                        return "WARN-010: Field 'Month' must be from 1 to 12";
                    }
                    value = month.ToString();
                }
                return value;
            }
            catch (Exception)
            {
                return "WARN-009: Field 'Month' is invalid";
            }
        }
    }
}
