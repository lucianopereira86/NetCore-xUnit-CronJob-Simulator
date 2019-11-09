using System;

namespace CronJob.App
{
   public class Program
    {
        static void Main(string[] args)
        {
            StartCronJob();
        }

        private static void StartCronJob()
        {
            CronJob cronJob = new CronJob();
            Console.WriteLine($"\nWrite a cron string:");
            string line = Console.ReadLine();
            cronJob.CheckLine(line);
            StartCronJob();
        }
    }
}
