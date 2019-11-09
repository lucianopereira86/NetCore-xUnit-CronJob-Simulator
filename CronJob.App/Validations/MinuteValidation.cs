using System;

namespace CronJob.App.Validations
{
    public class MinuteValidation
    {
        public string GetMinute(string field)
        {
            try
            {
                string value = "";

                if (field.Equals("*"))
                {
                    var minutes = new int[60];
                    for (int m = 1; m <= 60; m++)
                        minutes[m - 1] = m;
                    value = string.Join(' ', minutes);
                }
                else
                {
                    int minute = Convert.ToInt32(field);
                    if (minute < 1 || minute > 60)
                    {
                        return "WARN-002: Field 'minute' must be from 1 to 60";
                    }
                    value = minute.ToString();
                }
                return value;
            }
            catch (Exception)
            {
                return "WARN-001: Field 'minute' is invalid";
            }
        }
    }
}
