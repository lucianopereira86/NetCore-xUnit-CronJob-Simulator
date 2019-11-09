using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CronJob.Test
{
    public class TheoryTest
    {
        private readonly App.CronJob cronJob;
        private readonly ITestOutputHelper output;

        public TheoryTest(ITestOutputHelper o)
        {
            cronJob = new App.CronJob();
            output = o;
        }

        [Theory]
        [InlineData("* * * *", "000")]
        [InlineData("* * * * * *", "000")]
        public void LineTest(string line, string errorCode)
        {
            GetWarns(line, errorCode);
        }

        private void GetWarns(string line, string errorCode)
        {
            var warns = cronJob.CheckLine(line);
            string warn = warns.SingleOrDefault(w => w.Contains(errorCode));
            output.WriteLine(warn);
        }

        [Theory]
        [InlineData("abc", "001")]
        [InlineData("0", "002")]
        [InlineData("61", "002")]
        public void MinuteTest(string minute, string errorCode)
        {
            string line = $"{minute} 0 0 0 0";
            GetWarns(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "003")]
        [InlineData("24", "004")]
        [InlineData("0-24", "005")]
        [InlineData("15-10", "006")]
        public void HourTest(string hour, string errorCode)
        {
            string line = $"0 {hour} 0 0 0";
            GetWarns(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "007")]
        [InlineData("0", "008")]
        [InlineData("32", "008")]
        public void DayOfMonthTest(string day, string errorCode)
        {
            string line = $"0 0 {day} 0 0";
            GetWarns(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "009")]
        [InlineData("0", "010")]
        [InlineData("13", "010")]
        public void MonthTest(string month, string errorCode)
        {
            string line = $"0 0 0 {month} 0";
            GetWarns(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "011")]
        [InlineData("MUN,TUE,SAT", "012")]
        public void DayOfWeekTest(string day, string errorCode)
        {
            string line = $"0 0 0 0 {day}";
            GetWarns(line, errorCode);
        }
    }
}
