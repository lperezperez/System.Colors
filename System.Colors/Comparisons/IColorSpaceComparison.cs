namespace System.Colors.Comparisons
{
    using System.Drawing;
    /// <summary>Defines a set of methods for compare <see cref="IColorSpace"/> instances.</summary>
    public interface IColorSpaceComparison
    {
        #region Methods
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on a specific distance metric formula.
        /// </summary>
        /// <param name="left">An <see cref="IColorSpace"/> to compare.</param>
        /// <param name="right">An <see cref="IColorSpace"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        double Distance(IColorSpace left, IColorSpace right);
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on a specific distance metric formula.
        /// </summary>
        /// <param name="left">A <see cref="Color"/> to compare.</param>
        /// <param name="right">A <see cref="Color"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        double Distance(Color left, Color right);
        #endregion
    }
}