namespace System.Colors.Comparisons
{
    using System.Drawing;
    /// <summary>
    ///     Represents the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE76">CIE76</see> formula to compare distances between <see cref="IColorSpace"/> instances.
    /// </summary>
    public sealed class Cie76Comparison : IColorSpaceComparison
    {
        #region Methods
        /// <summary>Gets the distance between <paramref name="left"/> and <paramref name="right"/></summary>
        /// <param name="left">A <see cref="CieLab"/> component.</param>
        /// <param name="right">A <see cref="CieLab"/> component.</param>
        /// <returns>The distance between <paramref name="left"/> and <paramref name="right"/>.</returns>
        private static double Distance(double left, double right) => Math.Pow(left - right, 2);
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE76">CIE76</see> formula.
        /// </summary>
        /// <param name="left">A <see cref="CieLab"/> to compare.</param>
        /// <param name="right">A <see cref="CieLab"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(CieLab left, CieLab right) => Math.Sqrt(Cie76Comparison.Distance(left.L, right.L) + Cie76Comparison.Distance(left.a, right.a) + Cie76Comparison.Distance(left.b, right.b));
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE76">CIE76</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="IColorSpace"/> to compare.</param>
        /// <param name="right">An <see cref="IColorSpace"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(IColorSpace left, IColorSpace right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE76">CIE76</see> formula.
        /// </summary>
        /// <param name="left">A <see cref="Color"/> to compare.</param>
        /// <param name="right">A <see cref="Color"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(Color left, Color right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        #endregion
    }
}