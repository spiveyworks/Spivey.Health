namespace Spivey.Health
{
    public static class ScatterPlotDataGenerator<T>
    {
        //write a unit test for this method.
        public static ScatterPlotData<T> AggregateByDay(DateTime startDateRange,
                                              DateTime endDateRange,
                                              string labelX,
                                              DataList<double> dataListX,
                                              string labelY,
                                              DataList<double> dataListY,
                                              AggregateOperator aggregateOperator)
        {
            //get the number of days between the start and end date.
            var numberOfDaysBetweenStartAndEnd = endDateRange.Subtract(startDateRange).TotalDays + 1;
            var dataSet = new ScatterPlotDataSet()
            {
                Values = AggregateByDayStrategy(aggregateOperator, dataListX, dataListY, startDateRange, (int)numberOfDaysBetweenStartAndEnd)
            };
            return new ScatterPlotData<T>()
            {
                Labels = new string[] {labelX, labelY },
                DataSets = new ScatterPlotDataSet[] { dataSet }
            };
        }

        private static ScatterPlotDataPoint[] AggregateByDayStrategy(AggregateOperator aggregateOperator, DataList<double> dataListX, DataList<double> dataListY, DateTime startDateRange, int numberOfDaysBetweenStartAndEnd)
        {
            if (aggregateOperator == AggregateOperator.Average)
            {
                return AggregateByDayAverage(dataListX, dataListY, startDateRange, numberOfDaysBetweenStartAndEnd);
            }
            if (aggregateOperator == AggregateOperator.Sum)
            {
                return AggregateByDaySum(dataListX, dataListY, startDateRange, numberOfDaysBetweenStartAndEnd);
            }
            if (aggregateOperator == AggregateOperator.Min)
            {
                return AggregateByDayMin(dataListX, dataListY, startDateRange, numberOfDaysBetweenStartAndEnd);
            }
            if (aggregateOperator == AggregateOperator.Max)
            {
                return AggregateByDayMax(dataListX, dataListY, startDateRange, numberOfDaysBetweenStartAndEnd);
            }
            return new ScatterPlotDataPoint[0];
        }

        private static ScatterPlotDataPoint[] AggregateByDayMin(DataList<double> dataListX, DataList<double> dataListY, DateTime startDateRange, int numberOfDaysBetweenStartAndEnd)
        {
            var values = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Min();
                var valY = dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Min();

                values.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }
            return values.ToArray();
        }

        private static ScatterPlotDataPoint[] AggregateByDayMax(DataList<double> dataListX, DataList<double> dataListY, DateTime startDateRange, int numberOfDaysBetweenStartAndEnd)
        {
            var values = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Max();
                var valY = dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Max();

                values.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }
            return values.ToArray();
        }

        private static ScatterPlotDataPoint[] AggregateByDayAverage(DataList<double> dataListX, DataList<double> dataListY, DateTime startDateRange, int numberOfDaysBetweenStartAndEnd)
        {
            var values = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Average();
                var valY = dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Average();

                values.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }
            return values.ToArray();
        }

        private static ScatterPlotDataPoint[] AggregateByDaySum(DataList<double> dataListX, DataList<double> dataListY, DateTime startDateRange, int numberOfDaysBetweenStartAndEnd)
        {
            var values = new List<ScatterPlotDataPoint>();

            //loop through each day from start to end.
            for (var a = 0; a < numberOfDaysBetweenStartAndEnd; a++)
            {
                var date = startDateRange.AddDays(a);

                //get the values for the day from each data list.
                var valX = dataListX.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Sum();
                var valY = dataListY.Values.Where(i => i.Date == date.Date)
                                                    .Select(i => i.Value)
                                                    .Sum();

                values.Add(new ScatterPlotDataPoint()
                {
                    Date = date,
                    X = valX,
                    Y = valY
                });
            }
            return values.ToArray();
        }
    }
}
