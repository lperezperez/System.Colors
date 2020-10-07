namespace System.Colors
{
    using System.Colors.Comparisons;
    using System.Drawing;
    using System.Linq;
    /// <summary>Base <see langword="class"/> that represents a specific organization of colors.</summary>
    public abstract class ColorSpace : IColorSpace
    {
        #region Methods
        /// <summary>Returns a value that indicates whether the values of two <see cref="ColorSpace"/> objects are equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///     <see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(ColorSpace left, ColorSpace right) => left?.Equals(right) ?? false;
        /// <summary>Returns a value that indicates whether the values of two <see cref="ColorSpace"/> instances are not equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///     <see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(ColorSpace left, ColorSpace right) => !left?.Equals(right) ?? true;
        /// <inheritdoc/>
        public abstract void FromColor(Color color);
        /// <inheritdoc/>
        public abstract Color ToColor();
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is IColorSpace colorSpace && this.Equals(colorSpace);
        /// <inheritdoc/>
        public override int GetHashCode() => this.ToColor().GetHashCode();
        /// <inheritdoc/>
        public override string ToString()
        {
            var type = this.GetType();
            return $"{string.Join(", ", type.GetProperties().Select(p => $"{p.Name}: {p.GetValue(this, null)}").ToArray())}";
        }
        /// <summary>
        ///     Compares the current <see cref="IColorSpace"/> instance with another <see cref="IColorSpace"/> of the same type and returns an <see cref="int"/> that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">A <see cref="IColorSpace"/> instance to compare with this <see cref="IColorSpace"/> instance.</param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings: <list type="table">
        ///         <listheader>
        ///             <term>Value</term> <description>Description</description>
        ///         </listheader> <item>
        ///             <term>Less than zero</term> <description>This instance precedes <paramref name="other"/> in the sort order.</description>
        ///         </item> <item>
        ///             <term>Zero</term> <description>This instance occurs in the same position in the sort order as <paramref name="other"/>.</description>
        ///         </item> <item>
        ///             <term>Greater than zero</term> <description>This instance follows <paramref name="other"/> in the sort order.</description>
        ///         </item>
        ///     </list>
        /// </returns>
        public int CompareTo(IColorSpace other)
        {
            var left = this.ToColor();
            var right = other.ToColor();
            return (left.R + left.G + left.B).CompareTo(right.R + right.G + right.B);
        }
        /// <summary>
        ///     Compares the current <see cref="IColorSpace"/> instance with another <see cref="object"/> of the same type and returns an <see cref="int"/> that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings: <list type="table">
        ///         <listheader>
        ///             <term>Value</term> <description>Description</description>
        ///         </listheader> <item>
        ///             <term>Less than zero</term> <description>This instance precedes <paramref name="obj"/> in the sort order.</description>
        ///         </item> <item>
        ///             <term>Zero</term> <description>This instance occurs in the same position in the sort order as <paramref name="obj"/>.</description>
        ///         </item> <item>
        ///             <term>Greater than zero</term> <description>This instance follows <paramref name="obj"/> in the sort order.</description>
        ///         </item>
        ///     </list>
        /// </returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance.</exception>
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case IColorSpace other:
                    return this.CompareTo(other);
                default:
                    throw new ArgumentException("Is not the same type as this instance.", nameof(obj));
            }
        }
        /// <summary>Determines the distance between this <see cref="IColorSpace"/> instance and <paramref name="colorSpace"/>.</summary>
        /// <typeparam name="TColorSpaceComparison">An <see cref="IColorSpaceComparison"/> derived <see langword="class"/>.</typeparam>
        /// <param name="colorSpace">An <see cref="IColorSpace"/> instance.</param>
        /// <returns>The distance between this <see cref="IColorSpace"/> instance and <paramref name="colorSpace"/>.</returns>
        public double Distance<TColorSpaceComparison>(IColorSpace colorSpace)
            where TColorSpaceComparison : IColorSpaceComparison, new() => new TColorSpaceComparison().Distance(this, colorSpace);
        /// <summary>Determines whether two <see cref="ColorSpace"/> instances are equal.</summary>
        /// <param name="other">The <see cref="ColorSpace"/> instance to compare with this <see cref="ColorSpace"/> instance.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IColorSpace other)
        {
            var left = this.ToColor();
            if (other == null)
                return false;
            var right = other.ToColor();
            return left.R == right.R && left.G == right.G && left.B == right.B;
        }
        /// <summary>Gets the <typeparamref name="TColorSpace"/> representation of this <see cref="ColorSpace"/> instance.</summary>
        /// <typeparam name="TColorSpace">The <see cref="ColorSpace"/> derived class to convert to.</typeparam>
        /// <returns>The <typeparamref name="TColorSpace"/> representation of this <see cref="ColorSpace"/> instance.</returns>
        public TColorSpace To<TColorSpace>()
            where TColorSpace : IColorSpace, new()
        {
            if (typeof(TColorSpace) == this.GetType())
                return (TColorSpace)this.MemberwiseClone();
            var newColorSpace = new TColorSpace();
            newColorSpace.FromColor(this.ToColor());
            return newColorSpace;
        }
        /// <summary>
        ///     Formats the value of this <see cref="ColorSpace"/> instance using the specified <paramref name="format"/> and <paramref name="formatProvider"/>.
        /// </summary>
        /// <param name="format">
        ///     The format to use. The available values are (not case sensitive): <list type="table">
        ///         <listheader>
        ///             <term>Value</term> <description>Description</description>
        ///         </listheader> <item>
        ///             <term>Lab</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="CieLab"/>.</description>
        ///         </item> <item>
        ///             <term>LCh</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="CieLch"/>.</description>
        ///         </item> <item>
        ///             <term>Luv</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="CieLuv"/>.</description>
        ///         </item> <item>
        ///             <term>xyY</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="CieXyy"/>.</description>
        ///         </item> <item>
        ///             <term>XYZ</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="CieXyz"/>.</description>
        ///         </item> <item>
        ///             <term>CMY</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="Cmy"/>.</description>
        ///         </item> <item>
        ///             <term>CMYK</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="Cmyk"/>.</description>
        ///         </item> <item>
        ///             <term>Hex</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="HexTriplet"/>.</description>
        ///         </item> <item>
        ///             <term>HSL</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="Hsl"/>.</description>
        ///         </item> <item>
        ///             <term>HSV</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="Hsv"/>.</description>
        ///         </item> <item>
        ///             <term>HL</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="HunterLab"/>.</description>
        ///         </item> <item>
        ///             <term>RGB</term> <description>Shows this <see cref="ColorSpace"/> instance as a <see cref="Rgb"/>.</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <param name="formatProvider">The provider to use to format the value.</param>
        /// <returns>The value of the current instance in the specified format.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return format.ToUpper() switch
            {
                "LAB" => this.To<CieLab>().ToString(), "LCH" => this.To<CieLch>().ToString(), "LUV" => this.To<CieLuv>().ToString(), "XYY" => this.To<CieXyy>().ToString(), "XYZ" => this.To<CieXyz>().ToString(), "CMY" => this.To<Cmy>().ToString(), "CMYK" => this.To<Cmyk>().ToString(), "HEX" => this.To<HexTriplet>().ToString(), "HSL" => this.To<Hsl>().ToString(), "HSV" => this.To<Hsv>().ToString(), "HL" => this.To<HunterLab>().ToString(), "RGB" => this.To<Rgb>().ToString(), _ => this.ToString()
            };
        }
        #endregion
    }
}