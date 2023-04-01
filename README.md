# Spivey.Health
A c# package to efficiently store health data imported from different sources, so that you can analyze it. For example, heart, nutrition and other measurements from Apple Health export files.

## Related Packages
<<<<<<< Updated upstream
* [AppleHealthFileReader](https://github.com/spiveyworks/AppleHealthFileReader) can be used to read an Apple Health export zip file that contains all of your health data in XML format. That data can then be transformed into normalized Spivey.Health DataLists.
=======
* [AppleHealthFileReader](https://github.com/spiveyworks/AppleHealthFileReader) can be used to read an Apple Health export zip file that contains all of your health data in XML format. That data can then be transformed into normalized Spivey.Health DataLists.

## Usage

### Produce Scatter Plot and Aggregate Minimum by Day
```csharp
DateTime startDate = new DateTime(2023, 3, 20);
DateTime endDate = new DateTime(2023, 3, 22);
string labelX = "Label X";
string labelY = "Label Y";
string typeX = "Type X";
string typeY = "Type Y";
var dataListX = new DataList<double?>
{
    Values = new DataValue<double?>[]
    {
        new DataValue<double?> { Date = startDate, Value = 1 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 2 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 3 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 4 },
    }
};
var dataListY = new DataList<double?>
{
    Values = new DataValue<double?>[]
    {
        new DataValue<double?> { Date = startDate, Value = 10 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 20 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 30 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 40 },
        new DataValue<double?> { Date = endDate, Value = 50 },
    }
};

var result = ScatterPlotDataGenerator<double?>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Min);
```

Result

| Date       | X    | Y  |
|------------|------|----|
| 3/20/2023  | 1    | 10 |
| 3/21/2023  | 2    | 20 |
| 3/22/2023  | null | 50 |

### Produce Scatter Plot and Aggregate Sum by Day and Average by Month
```csharp
DateTime startDate = new DateTime(2023, 3, 30);
DateTime endDate = new DateTime(2023, 4, 1);
string labelX = "Label X";
string labelY = "Label Y";
string typeX = "Type X";
string typeY = "Type Y";
var dataListX = new DataList<double?>
{
    Values = new DataValue<double?>[]
    {
        new DataValue<double?> { Date = startDate, Value = 1 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 2 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 3 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 4 },
        new DataValue<double?> { Date = endDate, Value = 6 },
    }
};
var dataListY = new DataList<double?>
{
    Values = new DataValue<double?>[]
    {
        new DataValue<double?> { Date = startDate, Value = 10 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 20 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 30 },
        new DataValue<double?> { Date = startDate.AddDays(1), Value = 40 },
        new DataValue<double?> { Date = endDate, Value = 51 },
    }
};

var result = ScatterPlotDataGenerator<double?>.AggregateByMonth(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, dayAggregateOperator: AggregateOperator.Sum, monthAggregateOperator: AggregateOperator.Average);
```

Result

| Date       | X | Y  |
|------------|---|----|
| 3/1/2023   | 5 | 50 |
| 4/1/2023   | 6 | 51 |
>>>>>>> Stashed changes
