#region License
//MIT License

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
    public class PearsonCorrelationUnitTest
    {
        [TestMethod]
        public void Calculate_Correctly()
        {
            var x = new double[] { 3, 4, 5, 8, 1, 0 };
            var y = new double[] { 1, 1.1, 1.2, 1.4, 0.9, 0.8 };
            var r = PearsonCorrelation.Calculate(x, y);

            Assert.AreEqual(0.99620622877904863, r);
        }

        [TestMethod]
        public void Calculate_Not_Same_Length_Error()
        {
            var x = new double[] { 3, 4, 5, 8, 1, 0 };
            var y = new double[] { 1 };
            var r = PearsonCorrelation.Calculate(x, y);

            Assert.AreEqual(0.99620622877904863, r);
        }
    }
}
