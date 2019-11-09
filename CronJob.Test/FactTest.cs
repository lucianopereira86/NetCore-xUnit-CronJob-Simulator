using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace CronJob.Test
{
    public class FactTest
    {
        private readonly App.CronJob cronJob;
        private readonly ITestOutputHelper output;

        public FactTest(ITestOutputHelper o)
        {
            cronJob = new App.CronJob();
            output = o;
        }

        private void GetOutput(string line)
        {
            var texts = cronJob.CheckLine(line);
            string text = string.Join('\n', texts);
            output.WriteLine(text);
        }

        [Fact]
        public void AllValuesTest()
        {
            string line = "* * ? * ?";
            GetOutput(line);
        }

        [Fact]
        public void MinValuesTest()
        {
            string line = "1 0 1 1 SUN";
            GetOutput(line);
        }

        [Fact]
        public void MaxValuesTest()
        {
            string line = "60 23 31 12 SAT";
            GetOutput(line);
        }

        [Fact]
        public void RangeValuesTest()
        {
            string line = "1-45 5-15 2-29 6,7,8,9 SUN-FRI";
            GetOutput(line);
        }
    }
}
