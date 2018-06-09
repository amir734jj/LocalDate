# LocalDate

Date only library, similar to C# native `DateTime` but only `Date` with no time. This library uses Julian Day number for date calulcations.

## Exmaples:
```
// June 1, 2018
var date = new LocalDate(2018, 6, 1);

// June 11, 2018
date = date.AddDays(10);

// April 11, 2019
date = date.AddMonth(10);

// June 11, 2029
date = date.AddYears(10);

```
