namespace System.Colors
{
    /// <summary>Contains a set of methods to help in this project.</summary>
    internal static class Extensions
    {
        #region Methods
        /// <summary>
        ///     Returns a value indicating whether the diference between <paramref name="left"/> and <paramref name="right"/> are less or equal to the specified <paramref name="precision"/>.
        /// </summary>
        /// <param name="left">A <see cref="double"/> value to compare.</param>
        /// <param name="right">A <see cref="double"/> value to compare.</param>
        /// <param name="precision">The precision of the comparison.</param>
        /// <returns></returns>
        internal static bool BasicallyEqualTo(this double left, double right, double precision = .0001) => Math.Abs(left - right) <= precision;
        #endregion
    }
}