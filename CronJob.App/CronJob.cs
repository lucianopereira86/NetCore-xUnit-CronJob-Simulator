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
            Console.WriteLine("\nResult:\n");
            List<string> texts = new List<string>();
            string[] fields = line.Trim().Split(" ");
            if (fields.Length != 5)
            {
                string warn = "WARN-000: The cron string must have 5 fields!";
                Console.WriteLine(warn);
                texts.Add(warn);
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
                        texts.Add(value);
                    } else
                    {
                        string key = keys[p].PadRight(14, ' ');
                        string text = $"{key}{value}";
                        Console.WriteLine(text);
                        texts.Add(text);
                    }
                }
            }
            return texts;
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
