using CronJob.App.Validations;
using System;
using System.Collections.Generic;

namespace CronJob.App
{
    public class CronJob
    {
        private readonly string[] keys = { "minute", "hour", "day of month", "Month", "day of week" };
        
        public List<string> CheckLine(string line)
        {
            List<string> warns = new List<string>();
            string[] fields = line.Trim().Split(" ");
            if (fields.Length != 5)
            {
                string warn = "WARN-000: The cron string must have 5 fields!";
                Console.WriteLine(warn);
                warns.Add(warn);
            }
            else
            {
                for (int p = 0; p < fields.Length; p++)
                {
                    string field = fields[p];
                    string value = GetValue(field, p);
                    if (value.StartsWith("WARN"))
                    {
                        Console.WriteLine(value);
                        warns.Add(value);
                    } else
                    {
                        string key = keys[p].PadRight(14, ' ');
                        Console.WriteLine($"{key}{value}");
                    }
                }
            }
            return warns;
        }

        private string GetValue(string field, int position)
        {
            string value = null;
            switch (position)
            {
                case 0:
                    value = new MinuteValidation().GetMinute(field);
                    break;
                case 1:
                    value = new HourValidation().GetHour(field);
                    break;
                case 2:
                    value = new DayOfMonthValidation().GetDayOfMonth(field);
                    break;
                case 3:
                    value = new MonthValidation().GetMonth(field);
                    break;
                case 4:
                    value = new DayOfWeekValidation().GetDayOfWeek(field);
                    break;
                default:
                    break;
            }
            return value;
        }
    }
}
