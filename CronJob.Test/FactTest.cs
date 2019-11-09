using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CronJob.Test
{
    public class FactTest
    {
        private readonly App.CronJob cronJob;
        public FactTest()
        {
            cronJob = new App.CronJob();
        }

        [Fact]
        public void AllValuesTest()
        {
            string line = "* * ? * ?";
            cronJob.CheckLine(line);
        }

        [Fact]
        public void MinValuesTest()
        {
            string line = "1 0 1 1 SUN";
            cronJob.CheckLine(line);
        }

        [Fact]
        public void MaxValuesTest()
        {
            string line = "60 23 31 12 SAT";
            cronJob.CheckLine(line);
        }

        [Fact]
        public void RangeValuesTest()
        {
            string line = "* 5-15 ? * MON,WED,FRI";
            cronJob.CheckLine(line);
        }
    }
}
