# NetCore-xUnit-CronJob-Simulator

Simulating a Cronjob with .Net Core and xUnit.

## Instructions

The solution contains a console application and a unit test project.  
After running the app, type a cron string composed by 5 fields: minute, hour, day of month, month and day of week. Press _ENTER_ to receive the correspondent values in numbers for each field.

- minute: 1 to 60.
- hour: 0 to 23.
- day of month: 1 to 31.
- month: 1 to 12.
- day of week: 0 to 6.

### Tips

**Day of week** is the only field in which you must enter characters instead of numbers. Its options are: _SUN, MON, TUE, WED, THU, FRI and SAT_.
**?** and **\*** will display all the fields' values.
**-** is a range between two values. For example, _2-5_ will display: _2 3 4 5_.
**,** can be used between multiple entries from any field to bring their respective values to output. For example: _SUN,WED,FRI_ would display: _0 3 5_.

## Topics

- [Running the app](#running-the-app)
- [Testing the app](#testing-the-app)

### Net Core

### xUnit
