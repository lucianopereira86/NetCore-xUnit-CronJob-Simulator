using System;

namespace CronJob.App.Validations
{
    public class HourValidation
    {
        public string GetHour(string field)
        {
            try
            {
                string value = "";
                if (field.Equals("*"))
                {
                    var hours = new int[23];
                    for (int h = 0; h <= 23; h++)
                        hours[h] = h;
                    value = string.Join(' ', hours);
                }
                else
                {
                    if (field.Contains("-"))
                    {
                        string[] range = field.Split('-');
                        int min = int.Parse(range[0]);
                        int max = int.Parse(range[1]);
                        if (max > 23)
                        {
                            return "WARN-005: Field 'hour' must be from 0 to 23";
                        }
                        else if (min > max)
                        {
                            return "WARN-006: Range from field 'hour' is invalid";
                        }
                        int diff = max - min;
                        var hours = new int[diff + 1];
                        for (int h = 0; h <= diff; h++)
                        {
                            hours[h] = min;
                            min++;
                        }
                        value = string.Join(' ', hours);
                    }
                    else
                    {
                        int hour = Convert.ToInt32(field);
                        if (hour > 23)
                        {
                            return "WARN-004: Field 'hour' must be from 0 to 23";
                        }
                        value = hour.ToString();
                    }
                }
                return value;
            }
            catch (Exception)
            {
                return "WARN-003: Field 'hour' is invalid";
            }
        }
    }
}
