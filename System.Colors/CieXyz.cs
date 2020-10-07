namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CIE_1931_color_space">CIE 1931</see> color.</summary>
    public sealed class CieXyz : ColorSpace
    {
        #region Constants
        internal const double T0 = 216d / 24389;
        #endregion
        #region Fields
        internal static CieXyz WhiteReference = new CieXyz { X = 95.047, Y = 100, Z = 108.883 };
        #endregion
        #region Properties
        /// <summary>Gets or sets a mix of response curves chosen to be nonnegative.</summary>
        public double X { get; set; }
        /// <summary>Gets or sets the color luminance.</summary>
        public double Y { get; set; }
        /// <summary>Gets or sets a quasi-equal to blue, or the S cone response.</summary>
        public double Z { get; set; }
        #endregion
        #region Methods
        /// <summary>Converts the specified <paramref name="value"/> to a pre-processed <see cref="CieXyz"/> component value.</summary>
        /// <param name="value">The value of a component of a <see cref="Rgb"/> instance.</param>
        /// <returns>A pre-processed <see cref="CieXyz"/> component value.</returns>
        private static double FromRgb(byte value)
        {
            var d = value / (double)byte.MaxValue;
            return (d > 0.04045 ? Math.Pow((d + 0.055) / 1.055, 2.4) : d / 12.92) * 100;
        }
        /// <summary>Converts the specified <paramref name="value"/> to a <see cref="Rgb"/> component value.</summary>
        /// <param name="value">A pre-processed <see cref="CieXyz"/> component value.</param>
        /// <returns>A <see cref="Rgb"/> component value.</returns>
        private static byte ToRgb(double value) => Math.Min(byte.MaxValue, Math.Max(byte.MinValue, (byte)((value > 0.0031308 ? 1.055 * Math.Pow(value, 1 / 2.4) - 0.055 : 12.92 * value) * 255)));
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var r = CieXyz.FromRgb(color.R);
            var g = CieXyz.FromRgb(color.G);
            var b = CieXyz.FromRgb(color.B);

            // Illuminant D65
            this.X = r * 0.4124 + g * 0.3576 + b * 0.1805;
            this.Y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            this.Z = r * 0.0193 + g * 0.1192 + b * 0.9505;
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            // Illuminant D65
            var x = this.X / 100;
            var y = this.Y / 100;
            var z = this.Z / 100;
            return Color.FromArgb(CieXyz.ToRgb(x * 3.2406 + y * -1.5372 + z * -0.4986), CieXyz.ToRgb(x * -0.9689 + y * 1.8758 + z * 0.0415), CieXyz.ToRgb(x * 0.0557 + y * -0.2040 + z * 1.0570));
        }
        #endregion
    }
}