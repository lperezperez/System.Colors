namespace System.Colors.Comparisons
{
    using System.Drawing;
    /// <summary>
    ///     Represents the <see href="http://en.wikipedia.org/wiki/Color_difference#CMC_l:c_(1984)">CMC l:c</see> formula to compare distances between <see cref="IColorSpace"/> instances.
    /// </summary>
    public sealed class CmcComparison : IColorSpaceComparison
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="CmcComparison"/> <see lang="class"/></summary>
        public CmcComparison()
        {
            this.Chroma = 1;
            this.Lightness = 2;
        }
        #endregion
        #region Properties
        /// <summary>Gets or sets the chroma amount.</summary>
        /// <remarks>The commonly used value is 1.</remarks>
        public double Chroma { get; set; }
        /// <summary>Gets or sets the lightness amount.</summary>
        /// <remarks>The commonly used value is 2.</remarks>
        public double Lightness { get; set; }
        #endregion
        #region Methods
        private static double DistanceDivided(double dividend, double divisor) => Math.Pow(dividend / divisor, 2);
        private static double SqrtPow2(CieLab cieLab)
        {
            var c1 = Math.Sqrt(Math.Pow(cieLab.a, 2) + Math.Pow(cieLab.b, 2));
            return c1;
        }
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CMC_l:c_(1984)">CMC l:c</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="IColorSpace"/> to compare.</param>
        /// <param name="right">An <see cref="IColorSpace"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(IColorSpace left, IColorSpace right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CMC_l:c_(1984)">CMC l:c</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="CieLab"/> to compare.</param>
        /// <param name="right">An <see cref="CieLab"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(CieLab left, CieLab right)
        {
            var deltaL = left.L - right.L;
            var h = Math.Atan2(left.b, left.a);
            var c1 = CmcComparison.SqrtPow2(left);
            var c2 = CmcComparison.SqrtPow2(right);
            var deltaC = c1 - c2;
            var deltaH = Math.Sqrt(Math.Pow(left.a - right.a, 2) + Math.Pow(left.b - right.b, 2) - Math.Pow(deltaC, 2));
            var c1Pow4 = Math.Pow(c1, 4);
            var t = 164 <= h && h <= 345 ? .56 + Math.Abs(.2 * Math.Cos(h + 168.0)) : .36 + Math.Abs(.4 * Math.Cos(h + 35.0));
            var f = Math.Sqrt(c1Pow4 / (c1Pow4 + 1900.0));
            var sL = left.L < 16 ? .511 : .040975 * left.L / (1.0 + .01765 * left.L);
            var sC = .0638 * c1 / (1 + .0131 * c1) + .638;
            var sH = sC * (f * t + 1 - f);
            var differences = CmcComparison.DistanceDivided(deltaL, this.Lightness * sL) + CmcComparison.DistanceDivided(deltaC, this.Chroma * sC) + CmcComparison.DistanceDivided(deltaH, sH);
            return Math.Sqrt(differences);
        }
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CMC_l:c_(1984)">CMC l:c</see> formula.
        /// </summary>
        /// <param name="left">A <see cref="Color"/> to compare.</param>
        /// <param name="right">A <see cref="Color"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(Color left, Color right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        #endregion
    }
}