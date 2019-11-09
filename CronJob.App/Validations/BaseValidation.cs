using System;
using System.Collections.Generic;
using System.Linq;

namespace CronJob.App.Validations
{
    public class BaseValidation
    {
        protected string GeneralValidation(
            string fieldName,
            string fieldValue,
            int minValue,
            int maxValue,
            Func<string> callback,
            Dictionary<string, int> dict = null)
        {
            string value = "";

            if (fieldValue.Equals("*") || fieldValue.Equals("?"))
            {
                int max = minValue == 0 ? maxValue + 1 : maxValue;
                var array = new int[max];
                for (int m = minValue; m < maxValue + 1; m++)
                {
                    int index = minValue == 0 ? m : m - 1;
                    array[index] = m;
                }
                value = string.Join(' ', array);
            }
            else if (fieldValue.Contains("-"))
            {
                string[] range = fieldValue.Split('-');
                if (dict == null)
                {
                    int minRange = int.Parse(range[0]);
                    int maxRange = int.Parse(range[1]);
                    value = GetValuesFromRange(minValue, maxValue, minRange, maxRange, fieldName);
                }
                else
                {
                    string range0 = range[0];
                    string range1 = range[1];
                    bool isMinValid = dict.Any(a => a.Key.Equals(range0));
                    bool isMaxValid = dict.Any(a => a.Key.Equals(range1));
                    if (!isMinValid || !isMaxValid)
                    {
                        return $"WARN-001: Range in Field '{fieldName}' is invalid";
                    }
                    int minRange = dict[range0];
                    int maxRange = dict[range1];
                    value = GetValuesFromRange(minValue, maxValue, minRange, maxRange, fieldName);
                }
            }
            else if (fieldValue.Contains(","))
            {
                string[] array = fieldValue.Split(',');

                foreach (string element in array)
                {
                    if (dict == null)
                    {
                        if (int.Parse(element) < minValue || int.Parse(element) > maxValue)
                        {
                            return $"WARN-002: Field '{fieldName}' must be from {minValue} to {maxValue}";
                        }
                    }
                    else
                    {
                        bool isValid = dict.Any(a => a.Key.Equals(element));
                        if (!isValid)
                        {
                            return $"WARN-003: Field '{fieldName}' is invalid";
                        }
                    }
                }
                if (dict == null)
                {
                    value = string.Join(' ', array);
                }
                else
                {
                    var positions = new List<int>();
                    array.ToList().ForEach(x =>
                    {
                        int position = dict[x];
                        positions.Add(position);
                    });
                    value = string.Join(' ', positions.ToArray());
                }
            }
            else
            {
                value = callback();
            }
            return value;
        }

        private string GetValuesFromRange(int minValue, int maxValue, int minRange, int maxRange, string fieldName)
        {
            if (minRange < minValue || maxRange > maxValue)
            {
                return $"WARN-004: Field '{fieldName}' must be from {minValue} to {maxValue}";
            }
            else if (minRange > maxRange)
            {
                return $"WARN-005: Range in field '{fieldName}' is invalid";
            }
            int diff = maxRange - minRange;
            var array = new int[diff + 1];
            for (int m = 0; m <= diff; m++)
            {
                array[m] = minRange;
                minRange++;
            }
            return string.Join(' ', array);
        }
    }
}
