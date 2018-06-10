# LocalDate

Date only library, similar to C# native `DateTime` but only `Date` with no time. This library uses [Julian Day number](https://en.wikipedia.org/wiki/Julian_day) for date calculations. This library is intended to be simple to use solution to lack of Date only type in  C#.

One of the reasons I wrote this library is because there is really one major Date only library out there and that is NodaTime's library `LocalDate` type but I found it very difficult to use for basic Date representations. I am aware of the similarity of this library with NodaTime's `LocalDate` type. But this library is very basic compared to capabilities of NodaTime. 

## Exmaples:
```csharp
LocalDate date, clone;
DateTime dateTime;
String str;

// June 1, 2018
date = new LocalDate(2018, 6, 1);

// "2018-06-01"
str = date.ToString("yyyy-MM-dd")

// Parse LocalDate from string
clone = LocalDateFactory.ParseLocalDate(str);

// Convert the LocalDate to C# DateTime type
dateTime = date.ToDateTime();

// Convert DateTime back to LocalDate (via extension method)
clone = dateTime.ToLocalDate();

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
### Serializer and Deserializers
LocalDate comes with json ([`JSON.NET`](https://github.com/JamesNK/Newtonsoft.Json) library) and bson ([C# `Mongo` driver](https://github.com/mongodb/mongo-csharp-driver)) Serializer/Deserializer out of the box that converts the date to `string` and parse it back from string.

---------
### High-level design:
`LocalDate` extends `LocalDateStruct` which only has three `int` properties, hence if at any time extra methods are not needs, you can up-cast `LocalDate` to  `LocalDateStruct`.

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
