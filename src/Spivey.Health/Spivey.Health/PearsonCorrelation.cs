namespace Spivey.Health
{
    public static class PearsonCorrelation
    {
        public static double Calculate(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x and y must be the same length");
            double sumX = 0;
            double sumY = 0;
            double sumX2 = 0;
            double sumY2 = 0;
            double sumXY = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sumX += x[i];
                sumY += y[i];
                sumX2 += x[i] * x[i];
                sumY2 += y[i] * y[i];
                sumXY += x[i] * y[i];
            }
            double n = x.Length;
            double numerator = (n * sumXY) - (sumX * sumY);
            double denominator = Math.Sqrt((n * sumX2 - sumX * sumX) * (n * sumY2 - sumY * sumY));
            return numerator / denominator;
        }
    }
}
