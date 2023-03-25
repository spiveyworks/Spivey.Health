namespace Spivey.Health.Tests
{
    [TestClass]
    public class AggregateByDayTests
    {
        [TestMethod]
        public void AggregateByDay_Min_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 20);
            DateTime endDate = new DateTime(2023, 3, 22);
            string labelX = "Label X";
            string labelY = "Label Y";
            var dataListX = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 1 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 2 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 3 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 4 },
                    new DataValue<double> { Date = endDate, Value = 5 },
                }
            };
            var dataListY = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 10 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 20 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 30 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 40 },
                    new DataValue<double> { Date = endDate, Value = 50 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, dataListX, labelY, dataListY, AggregateOperator.Min);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(2, dataSet.Values[1].X);
            Assert.AreEqual(20, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(5, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Max_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 20);
            DateTime endDate = new DateTime(2023, 3, 22);
            string labelX = "Label X";
            string labelY = "Label Y";
            var dataListX = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 1 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 2 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 3 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 4 },
                    new DataValue<double> { Date = endDate, Value = 5 },
                }
            };
            var dataListY = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 10 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 20 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 30 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 40 },
                    new DataValue<double> { Date = endDate, Value = 50 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, dataListX, labelY, dataListY, AggregateOperator.Max);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(4, dataSet.Values[1].X);
            Assert.AreEqual(40, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(5, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Sum_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 20);
            DateTime endDate = new DateTime(2023, 3, 22);
            string labelX = "Label X";
            string labelY = "Label Y";
            var dataListX = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 1 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 2 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 3 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 4 },
                    new DataValue<double> { Date = endDate, Value = 5 },
                }
            };
            var dataListY = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 10 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 20 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 30 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 40 },
                    new DataValue<double> { Date = endDate, Value = 50 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, dataListX, labelY, dataListY, AggregateOperator.Sum);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(9, dataSet.Values[1].X);
            Assert.AreEqual(90, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(5, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Average_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 20);
            DateTime endDate = new DateTime(2023, 3, 22);
            string labelX = "Label X";
            string labelY = "Label Y";
            var dataListX = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 1 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 2 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 3 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 4 },
                    new DataValue<double> { Date = endDate, Value = 5 },
                }
            };
            var dataListY = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 10 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 20 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 30 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 40 },
                    new DataValue<double> { Date = endDate, Value = 50 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, dataListX, labelY, dataListY, AggregateOperator.Average);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(3, dataSet.Values[1].X);
            Assert.AreEqual(30, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(5, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }
    }
}
