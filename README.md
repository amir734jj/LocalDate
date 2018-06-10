# LocalDate

Date only library, similar to C# native `DateTime` but only `Date` with no time. This library uses Julian Day number for date calulcations.

## Exmaples:
```csharp
// June 1, 2018
var date = new LocalDate(2018, 6, 1);

// "2018-06-01"
var str = date.ToString("yyyy-MM-dd")

// Parse LocalDate from string
var clone = LocalDateFactory.ParseLocalDate(str);

// June 11, 2018
date = date.AddDays(10);

// April 11, 2019
date = date.AddMonth(10);

// June 11, 2029
date = date.AddYears(10);

// Add two LocalDates together
data = date + date;

// Or Subtract them
date = date - date
```
---------
### High level design:
`LocalDate` extends `LocalDateStruct` which only has three `int` properties, hence if at anytime extra methods are not needs, you can up-cast `LocalDate` to  `LocalDateStruct`.

```csharp
public interface 
{
    int Year { get; }

    int Month { get; }

    int Day { get; }
}

// LocalDate extends ILocalDate
public interface ILocalDate: ILocalDateStruct
{
   ...
}
```
