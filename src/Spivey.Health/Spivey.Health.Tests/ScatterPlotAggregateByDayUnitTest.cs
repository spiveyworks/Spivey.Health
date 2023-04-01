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
    public class AggregateByDayTests
    {
        #region Double Aggregate Tests

        [TestMethod]
        public void AggregateByDay_Min_AggregatesCorrectly()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 3, 20);
            DateTime endDate = new DateTime(2023, 3, 22);
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
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Min);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

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
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Max);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

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
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Sum);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

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
            var result = ScatterPlotDataGenerator<double>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Average);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

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

        #endregion Double Aggregate Tests

        #region Nullable Double Aggregate Tests

        [TestMethod]
        public void AggregateByDay_Min_AggregatesNullableCorrectly()
        {
            // Arrange
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
                    new DataValue<double?> { Date = startDate.AddDays(1), Value = null },
                    new DataValue<double?> { Date = startDate.AddDays(1), Value = 30 },
                    new DataValue<double?> { Date = endDate, Value = 50 },
                }
            };

            // Act
            var result = ScatterPlotDataGenerator<double?>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Min);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(2, dataSet.Values[1].X);
            Assert.AreEqual(30, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(null, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Max_AggregatesNullableCorrectly()
        {
            // Arrange
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

            // Act
            var result = ScatterPlotDataGenerator<double?>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Max);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(4, dataSet.Values[1].X);
            Assert.AreEqual(40, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(null, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Sum_AggregatesNullableCorrectly()
        {
            // Arrange
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

            // Act
            var result = ScatterPlotDataGenerator<double?>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Sum);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(9, dataSet.Values[1].X);
            Assert.AreEqual(90, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(0, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        [TestMethod]
        public void AggregateByDay_Average_AggregatesNullableCorrectly()
        {
            // Arrange
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

            // Act
            var result = ScatterPlotDataGenerator<double?>.AggregateByDay(startDate, endDate, labelX, typeX, dataListX, labelY, typeY, dataListY, AggregateOperator.Average);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Labels.Length);
            Assert.AreEqual(labelX, result.Labels[0]);
            Assert.AreEqual(labelY, result.Labels[1]);
            Assert.AreEqual(1, result.DataSets.Length);
            Assert.AreEqual(typeX, result.DataSets[0].TypeX);
            Assert.AreEqual(typeY, result.DataSets[0].TypeY);

            var dataSet = result.DataSets[0];
            Assert.AreEqual(3, dataSet.Values.Count());

            Assert.AreEqual(new DateTime(2023, 3, 20), dataSet.Values[0].Date);
            Assert.AreEqual(1, dataSet.Values[0].X);
            Assert.AreEqual(10, dataSet.Values[0].Y);
            Assert.AreEqual(new DateTime(2023, 3, 21), dataSet.Values[1].Date);
            Assert.AreEqual(3, dataSet.Values[1].X);
            Assert.AreEqual(30, dataSet.Values[1].Y);
            Assert.AreEqual(new DateTime(2023, 3, 22), dataSet.Values[2].Date);
            Assert.AreEqual(null, dataSet.Values[2].X);
            Assert.AreEqual(50, dataSet.Values[2].Y);
        }

        #endregion Nullable Double Aggregate Tests
    }
}
