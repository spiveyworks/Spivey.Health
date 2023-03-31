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

namespace Spivey.Health.Tests
{
    [TestClass]
    public class AggregateByMonthTests
    {
        [TestMethod]
        public void AggregateByMonth_Max_Day_Sum_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 30);
            DateTime endDate = new DateTime(2023, 4, 1);
            string labelX = "Label X";
            string labelY = "Label Y";
            string typeX = "Type X";
            string typeY = "Type Y";
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
            var result = ScatterPlotDataGenerator<double>.AggregateByMonth(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Sum, AggregateOperator.Max);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(2, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 1), dataSet.Values[0].Date);
            Assert.AreEqual(9, dataSet.Values[0].X);
            Assert.AreEqual(90, dataSet.Values[0].Y);

            Assert.AreEqual(new DateTime(2023, 4, 1), dataSet.Values[1].Date);
            Assert.AreEqual(5, dataSet.Values[1].X);
            Assert.AreEqual(50, dataSet.Values[1].Y);
        }

        [TestMethod]
        public void AggregateByMonth_Min_Day_Sum_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 30);
            DateTime endDate = new DateTime(2023, 4, 1);
            string labelX = "Label X";
            string labelY = "Label Y";
            string typeX = "Type X";
            string typeY = "Type Y";
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
            var result = ScatterPlotDataGenerator<double>.AggregateByMonth(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Sum, AggregateOperator.Min);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(2, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 1), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);

            Assert.AreEqual(new DateTime(2023, 4, 1), dataSet.Values[1].Date);
            Assert.AreEqual(5, dataSet.Values[1].X);
            Assert.AreEqual(50, dataSet.Values[1].Y);
        }

        [TestMethod]
        public void AggregateByMonth_Sum_Day_Sum_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 30);
            DateTime endDate = new DateTime(2023, 4, 1);
            string labelX = "Label X";
            string labelY = "Label Y";
            string typeX = "Type X";
            string typeY = "Type Y";
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
            var result = ScatterPlotDataGenerator<double>.AggregateByMonth(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, dayAggregateOperator: AggregateOperator.Sum, monthAggregateOperator: AggregateOperator.Sum);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(2, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 1), dataSet.Values[0].Date);
            Assert.AreEqual(10, dataSet.Values[0].X);
            Assert.AreEqual(100, dataSet.Values[0].Y);

            Assert.AreEqual(new DateTime(2023, 4, 1), dataSet.Values[1].Date);
            Assert.AreEqual(5, dataSet.Values[1].X);
            Assert.AreEqual(50, dataSet.Values[1].Y);
        }

        [TestMethod]
        public void AggregateByMonth_Average_Day_Sum_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 30);
            DateTime endDate = new DateTime(2023, 4, 1);
            string labelX = "Label X";
            string labelY = "Label Y";
            string typeX = "Type X";
            string typeY = "Type Y";
            var dataListX = new DataList<double>
            {
                Values = new DataValue<double>[]
                {
                    new DataValue<double> { Date = startDate, Value = 1 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 2 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 3 },
                    new DataValue<double> { Date = startDate.AddDays(1), Value = 4 },
                    new DataValue<double> { Date = endDate, Value = 6 },
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
                    new DataValue<double> { Date = endDate, Value = 51 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double>.AggregateByMonth(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, dayAggregateOperator: AggregateOperator.Sum, monthAggregateOperator: AggregateOperator.Average);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(2, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 1), dataSet.Values[0].Date);
            Assert.AreEqual(5, dataSet.Values[0].X);
            Assert.AreEqual(50, dataSet.Values[0].Y);

            Assert.AreEqual(new DateTime(2023, 4, 1), dataSet.Values[1].Date);
            Assert.AreEqual(6, dataSet.Values[1].X);
            Assert.AreEqual(51, dataSet.Values[1].Y);
        }
    }
}
