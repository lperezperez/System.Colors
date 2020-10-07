namespace System.Colors.Comparisons
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    /// <summary>
    ///     Represents the <see href="http://en.wikipedia.org/wiki/Color_difference#CIEDE2000">CIE76</see> formula to compare distances between <see cref="IColorSpace"/> instances.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of some private methods and local variables correspond to their definitions in the CIEDE2000 formula for clarity.")]
    public sealed class Ciede2000Comparison : IColorSpaceComparison
    {
        #region Methods
        private static double A(CieLab cieLab, double g) => (1 + g) * cieLab.a;
        private static double C(CieLab cieLab, double a) => Math.Sqrt(Math.Pow(a, 2) + Math.Pow(cieLab.b, 2));
        private static double Cab(CieLab cieLab) => Math.Sqrt(Math.Pow(cieLab.a, 2) + Math.Pow(cieLab.b, 2));
        private static double DeltaHPrime(double c1, double c2, double h1, double h2)
        {
            var hBar = Math.Abs(h1 - h2);
            if (c1 * c2 == 0)
                return 0;
            if (hBar <= 180d)
                return h2 - h1;
            if (hBar > 180d && h2 <= h1)
                return h2 - h1 + 360.0;
            return h2 - h1 - 360.0;
        }
        private static double H(CieLab cieLab, double a) => (Math.Atan2(cieLab.b, a) * 180d / Math.PI + 360) % 360d;
        private static double HPrimeAverage(double c1, double c2, double h1, double h2)
        {
            var hBar = Math.Abs(h1 - h2);
            if (c1 * c2 == 0)
                return 0;
            if (hBar <= 180d)
                return (h1 + h2) / 2;
            if (hBar > 180d && h1 + h2 < 360d)
                return (h1 + h2 + 360d) / 2;
            return (h1 + h2 - 360d) / 2;
        }
        private static double SL(double lPrimeAverage)
        {
            var result = Math.Pow(lPrimeAverage - 50, 2);
            return 1 + .015d * result / Math.Sqrt(20 + result);
        }
        private static double SqrtPow7(double input)
        {
            input = Math.Pow(input, 7);
            return Math.Sqrt(input / (input + 6103515625));
        }
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIEDE2000">CIEDE2000</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="CieLab"/> to compare.</param>
        /// <param name="right">An <see cref="CieLab"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(CieLab left, CieLab right)
        {
            //Set weighting factors to 1
            const double Kl = 1.0d;
            const double Kc = 1.0d;
            const double Kh = 1.0d;
            var deltaL = right.L - left.L;
            var c1ab = Ciede2000Comparison.Cab(left);
            var c2ab = Ciede2000Comparison.Cab(right);
            var g = 0.5d * (1 - Ciede2000Comparison.SqrtPow7((c1ab + c2ab) / 2));
            var a1 = Ciede2000Comparison.A(left, g);
            var a2 = Ciede2000Comparison.A(right, g);
            var c1 = Ciede2000Comparison.C(left, a1);
            var c2 = Ciede2000Comparison.C(right, a2);
            var deltaC = c2 - c1;
            //Angles in Degree.
            var h1 = Ciede2000Comparison.H(left, a1);
            var h2 = Ciede2000Comparison.H(right, a2);
            //var h_bar = Math.Abs(h1 - h2);
            var deltaH = 2 * Math.Sqrt(c1 * c2) * Math.Sin(Ciede2000Comparison.DeltaHPrime(c1, c2, h1, h2) * Math.PI / 360d);

            // Calculate CIEDE2000
            var cPrimeAverage = (c1 + c2) / 2d;
            var hPrimeAverage = Ciede2000Comparison.HPrimeAverage(c1, c2, h1, h2);
            var sL = Ciede2000Comparison.SL((left.L + right.L) / 2d);
            var sC = 1 + .045d * cPrimeAverage;
            var T = 1 - .17 * Math.Cos(this.DegToRad(hPrimeAverage - 30)) + .24 * Math.Cos(this.DegToRad(hPrimeAverage * 2)) + .32 * Math.Cos(this.DegToRad(hPrimeAverage * 3 + 6)) - .2 * Math.Cos(this.DegToRad(hPrimeAverage * 4 - 63));
            var sH = 1 + .015 * T * cPrimeAverage;
            var rC = 2 * Ciede2000Comparison.SqrtPow7(cPrimeAverage);
            var rT = -Math.Sin(this.DegToRad(2 * (30 * Math.Exp(-Math.Pow((hPrimeAverage - 275) / 25, 2))))) * rC;
            var deltaCResult = deltaC / (sC * Kc);
            var deltaHResult = deltaH / (sH * Kh);
            return Math.Sqrt(Math.Pow(deltaL / (sL * Kl), 2) + Math.Pow(deltaCResult, 2) + Math.Pow(deltaHResult, 2) + rT * deltaCResult * deltaHResult);
        }
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIEDE2000">CIEDE2000</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="IColorSpace"/> to compare.</param>
        /// <param name="right">An <see cref="IColorSpace"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(IColorSpace left, IColorSpace right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIEDE2000">CIEDE2000</see> formula.
        /// </summary>
        /// <param name="left">A <see cref="Color"/> to compare.</param>
        /// <param name="right">A <see cref="Color"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(Color left, Color right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        private double DegToRad(double degrees) => degrees * Math.PI / 180;
        #endregion
    }
}