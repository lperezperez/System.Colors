namespace System.Colors
{
    using System.Colors.Comparisons;
    using System.Drawing;
    /// <summary>Defines the methods of a specific organization of colors.</summary>
    public interface IColorSpace : IComparable, IComparable<IColorSpace>, IEquatable<IColorSpace>, IFormattable
    {
        #region Methods
        /// <summary>Determines the distance between this <see cref="IColorSpace"/> instance and <paramref name="colorSpace"/>.</summary>
        /// <typeparam name="TColorSpaceComparison">An <see cref="IColorSpaceComparison"/> derived <see langword="class"/>.</typeparam>
        /// <param name="colorSpace">An <see cref="IColorSpace"/> instance.</param>
        /// <returns>The distance between this <see cref="IColorSpace"/> instance and <paramref name="colorSpace"/>.</returns>
        double Distance<TColorSpaceComparison>(IColorSpace colorSpace)
            where TColorSpaceComparison : IColorSpaceComparison, new();
        /// <summary>Initializes this <see cref="IColorSpace"/> instance from the specified <paramref name="color"/></summary>
        /// <param name="color">A <see cref="Color"/> instance.</param>
        /// <returns>This <see cref="IColorSpace"/> instance.</returns>
        void FromColor(Color color);
        /// <summary>Converts this <see cref="IColorSpace"/> instance to a <typeparamref name="TColorSpace"/> instance.</summary>
        /// mo
        /// <typeparam name="TColorSpace">An <see cref="IColorSpace"/> derived <see langword="class"/>.</typeparam>
        /// <returns>The <typeparamref name="TColorSpace"/> instance.</returns>
        TColorSpace To<TColorSpace>()
            where TColorSpace : IColorSpace, new();
        /// <summary>Gets a <see cref="Color"/> instance from this <see cref="IColorSpace"/> instance.</summary>
        /// <returns>The <see cref="Color"/> instance.</returns>
        Color ToColor();
        #endregion
    }
}