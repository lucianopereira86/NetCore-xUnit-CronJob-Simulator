# NetCore-xUnit-CronJob-Simulator

Simulating a Cronjob with .Net Core and xUnit.

## Technologies

- [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/?rr=https%3A%2F%2Fwww.google.com%2F)
- [.Net Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [xUnit](https://xunit.net/)

## Topics

- [Instructions](#instructions)
- [Running the app](#running-the-app)
- [Testing the app](#testing-the-app)

## Instructions

The solution contains a console application and a unit test project.  
After running the app, it will be required for the user to enter a cron string composed by 5 fields separated by empty spaces: minute, hour, day of month, month and day of week. The output will display values as numbers for each field:

- minute: 1 to 60.
- hour: 0 to 23.
- day of month: 1 to 31.
- month: 1 to 12.
- day of week: 0 to 6.

### Tips

**Day of week** is the only field in which you must enter characters instead of numbers. Its options are: _SUN, MON, TUE, WED, THU, FRI and SAT_.  
The characters **"?"** and **"\*"** will display all the fields' values.  
The character **"-"** is a range between two values. For example, _2-5_ will display: _2 3 4 5_.  
The character **","** can be used between multiple entries from any field to bring their respective values to output. For example: _SUN,WED,FRI_ would display: _0 3 5_.

### Running the app

The console application contains this structure:

![app01](/docs/app01.JPG)

Inside **Program.cs**, the **CronJob** class will be instatiated after the user enter the cron string:

![app02](/docs/app02.JPG)

The **Cronjob's CheckLine** method is responsible for checking the user's input. The first validation occurs at the number of required fields. Then each field receives inner validations from the **GetValue** method:

![app03](/docs/app03.JPG)

Each field has its own validation class:

![app04](/docs/app04.JPG)

All of them implements the **BaseValidation** class, whose **GeneralValidation** method is responsible for validating the special characters and treating the output accordingly.

Checking **"?"** and **"\*"**:

![app05](/docs/app05.JPG)

Checking **"-"**:

![app06](/docs/app06.JPG)

Checking **","**:

![app07](/docs/app07.JPG)

If none of them are used, the field's respective callback function will be executed. For example:

![app08](/docs/app08.JPG)

When running the app the positive output will be displayed this way:

![app09](/docs/app09.JPG)

And a negative output will be like this:

![app10](/docs/app10.JPG)

### Testing the app

The xUnit project contains this structure:

![test01](/docs/test01.JPG)

The **TheoryTest.cs** will test multiple entries and expect for specific warnings to return. For example:

![test02](/docs/test02.JPG)

**LineTest** method will wait for the warning containing **"000"** because it will test the number of fields validation.  
The **GetOutput** method is the one responsible for checking the desired output:

![test03](/docs/test03.JPG)

The **FactTest.cs** will test for positive results by sending fixed values and expecting all validations to be flawless:

![test04](/docs/test04.JPG)

The Visual Studio 2019's Test Manager will show the unit tests this way after running successfully:

![test05](/docs/test05.JPG)

You can see the the output of any unit test, both **Fact** or **Theory**:

![test06](/docs/test06.JPG)

This is an example of a **Fact** after a successful execution:

![test07](/docs/test07.JPG)

And this one is a **Theory** example with its desired warning:

![test08](/docs/test08.JPG)
