#region License
//MIT License

//Copyright (c) 2023 Michael Spivey

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

namespace Spivey.Health
{
    public static class ScatterPlotDataGenerator<T>
    {
        private static Dictionary<AggregateOperator, Func<IEnumerable<double>, double>> Aggregators = new Dictionary<AggregateOperator, Func<IEnumerable<double>, double>>()
            {
                { AggregateOperator.Sum, values => values.Sum() },
                { AggregateOperator.Average, values => values.Average() },
                { AggregateOperator.Min, values => values.Min() },
                { AggregateOperator.Max, values => values.Max() },
            };

        public static ScatterPlotData<T> AggregateByDay(DateTime startDateRange,
                                              DateTime endDateRange,
                                              string labelX,
                                              string typeX,
                                              DataList<double> dataListX,
                                              string labelY,
                                              string typeY,
                                              DataList<double> dataListY,
                                              AggregateOperator aggregateOperator)
        {
            //get the number of days between the start and end date.
            var numberOfDaysBetweenStartAndEnd = endDateRange.Subtract(startDateRange).TotalDays + 1;
            var values = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = Aggregators[aggregateOperator](dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value));
                var valY = Aggregators[aggregateOperator](dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value));

                values.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }
            var dataSet = new ScatterPlotDataSet()
            {
                TypeX = typeX,
                TypeY = typeY,
                Values = values.ToArray()
            };
            return new ScatterPlotData<T>()
            {
                Labels = new string[] { labelX, labelY },
                DataSets = new ScatterPlotDataSet[] { dataSet }
            };
        }

        public static ScatterPlotData<T> AggregateByMonth(DateTime startDateRange,
                                              DateTime endDateRange,
                                              string labelX,
                                              string typeX,
                                              DataList<double> dataListX,
                                              string labelY,
                                              string typeY,
                                              DataList<double> dataListY,
                                              AggregateOperator dayAggregateOperator,
                                              AggregateOperator monthAggregateOperator)
        {
            //get the number of days between the start and end date.
            var numberOfDaysBetweenStartAndEnd = endDateRange.Subtract(startDateRange).TotalDays + 1;
            var numberOfMonthsBetweenStartAndEnd = GetUniqueMonthsBetween(startDateRange, endDateRange);
            var dayValues = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = Aggregators[dayAggregateOperator](dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value));
                var valY = Aggregators[dayAggregateOperator](dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value));

                dayValues.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }

            var monthValues = new List<ScatterPlotDataPoint>();
            for (var m = 0; m < numberOfMonthsBetweenStartAndEnd; m++)
            {
                var monthDate = startDateRange.AddMonths(m);

                //get the values for the month from each data list.
                var valX = Aggregators[monthAggregateOperator](dayValues.Where(i => i.Date.Year == monthDate.Date.Year && i.Date.Month == monthDate.Date.Month)
                                                    .Select(i => i.X.GetValueOrDefault(0)));
                var valY = Aggregators[monthAggregateOperator](dayValues.Where(i => i.Date.Year == monthDate.Date.Year && i.Date.Month == monthDate.Date.Month)
                                                    .Select(i => i.Y.GetValueOrDefault(0)));

                monthValues.Add(new ScatterPlotDataPoint()
                {
                    Date = new DateTime(monthDate.Year, monthDate.Month, 1),
                    X = valX,
                    Y = valY
                });
            }
            var dataSet = new ScatterPlotDataSet()
            {
                TypeX = typeX,
                TypeY = typeY,
                Values = monthValues.ToArray()
            };
            return new ScatterPlotData<T>()
            {
                Labels = new string[] { labelX, labelY },
                DataSets = new ScatterPlotDataSet[] { dataSet }
            };
        }

        public static int GetUniqueMonthsBetween(DateTime startDate, DateTime endDate)
        {
            int monthsApart = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month + 1;

            return monthsApart;
        }
    }
}
