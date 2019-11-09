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

        private void GetOutput(string line, string errorCode)
        {
            var texts = cronJob.CheckLine(line);
            string warn = texts.SingleOrDefault(w => w.Contains(errorCode));
            output.WriteLine(warn);
        }

        [Theory]
        [InlineData("* * * *", "000")]
        [InlineData("* * * * * *", "000")]
        public void LineTest(string line, string errorCode)
        {
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("* * * * ABC-XYZ", "001")]
        [InlineData("0,100 * * * *", "002")]
        [InlineData("* * * * ABC,XYZ", "003")]
        [InlineData("0-100 * * * *", "004")]
        [InlineData("2-1 * * * *", "005")]
        public void BaseTest(string line, string errorCode)
        {
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "006")]
        [InlineData("0", "007")]
        [InlineData("61", "007")]
        public void MinuteTest(string minute, string errorCode)
        {
            string line = $"{minute} 0 0 0 0";
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "008")]
        [InlineData("24", "009")]
        public void HourTest(string hour, string errorCode)
        {
            string line = $"0 {hour} 0 0 0";
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "010")]
        [InlineData("0", "011")]
        [InlineData("32", "011")]
        public void DayOfMonthTest(string day, string errorCode)
        {
            string line = $"0 0 {day} 0 0";
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "012")]
        [InlineData("0", "013")]
        [InlineData("13", "013")]
        public void MonthTest(string month, string errorCode)
        {
            string line = $"0 0 0 {month} 0";
            GetOutput(line, errorCode);
        }

        [Theory]
        [InlineData("abc", "014")]
        public void DayOfWeekTest(string day, string errorCode)
        {
            string line = $"0 0 0 0 {day}";
            GetOutput(line, errorCode);
        }
    }
}
