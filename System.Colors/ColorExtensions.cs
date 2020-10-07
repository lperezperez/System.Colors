namespace System.Colors
{
    using System.Drawing;
    /// <summary>Contains a set of methods to help with <see cref="Color"/> <see langword="class"/>.</summary>
    public static class ColorExtensions
    {
        #region Methods
        /// <summary>Converts the specified <paramref name="color"/> to a <typeparamref name="TColorSpace"/> instance.</summary>
        /// <typeparam name="TColorSpace">An <see cref="IColorSpace"/> derived <see langword="class"/>.</typeparam>
        /// <param name="color">A <see cref="Color"/> instance.</param>
        /// <returns>A <typeparamref name="TColorSpace"/> instance.</returns>
        public static TColorSpace To<TColorSpace>(this Color color)
            where TColorSpace : IColorSpace, new()
        {
            var colorSpace = new TColorSpace();
            colorSpace.FromColor(color);
            return colorSpace;
        }
        #endregion
    }
}