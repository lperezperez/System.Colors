namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents an <see href="https://en.wikipedia.org/wiki/HSL_and_HSV">HSL</see> color.</summary>
    public sealed class Hsl : ColorSpace
    {
        #region Properties
        /// <summary>Gets the hue component of this <see cref="Hsl"/> instance.</summary>
        public double H { get; set; }
        /// <summary>Gets the lightness component of this <see cref="Hsl"/> of this instance.</summary>
        public double L { get; set; }
        /// <summary>Gets the saturation component of this <see cref="Hsl"/> of this instance.</summary>
        public double S { get; set; }
        #endregion
        #region Methods
        /// <summary>
        ///     Processes the specified <paramref name="ls1"/>, <paramref name="ls2"/> and <paramref name="rangedH"/> values to obtain a <see cref="Rgb"/> component value.
        /// </summary>
        /// <param name="ls1">A lightness/saturation calculation.</param>
        /// <param name="ls2">A lightness/saturation calculation.</param>
        /// <param name="rangedH">The ranged H value of an <see cref="Hsl"/>.</param>
        /// <returns></returns>
        private static double ToRgb(double ls1, double ls2, double rangedH)
        {
            if (rangedH < 0.0) rangedH += 1;
            else if (rangedH > 1.0) rangedH -= 1;
            if (rangedH < 1.0 / 6.0)
                return ls1 + (ls2 - ls1) * 6.0 * rangedH;
            if (rangedH < 0.5)
                return ls2;
            if (rangedH < 2.0 / 3.0)
                return ls1 + (ls2 - ls1) * (2.0 / 3.0 - rangedH) * 6.0;
            return ls1;
        }
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            double max = Math.Max(color.R, Math.Max(color.G, color.B));
            double min = Math.Min(color.R, Math.Min(color.G, color.B));
            //saturation
            this.S = (max + min) / 2d <= 127d ? (max - min) / (max + min) : (max - min) / (510d - max - min);
            //lightness
            this.L = (max + min) / 2d / 255d;
            //hue
            if (Math.Abs(max - min) <= float.Epsilon)
            {
                this.H = 0d;
                this.S = 0d;
            }
            else
            {
                var diff = max - min;
                if (Math.Abs(max - color.R) <= float.Epsilon)
                    this.H = 60d * (color.G - color.B) / diff;
                else if (Math.Abs(max - color.G) <= float.Epsilon)
                    this.H = 60d * (color.B - color.R) / diff + 120d;
                else
                    this.H = 60d * (color.R - color.G) / diff + 240d;
                if (this.H < 0d)
                    this.H += 360;
            }
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var rangedH = this.H / 360;
            var l = this.L;
            if (this.L.BasicallyEqualTo(0))
                return new Color();
            double r;
            double g;
            double b;
            if (this.S.BasicallyEqualTo(0))
            {
                r = g = b = l;
            }
            else
            {
                var ls2 = l < 0.5 ? l * (1 + this.S) : l + this.S - l * this.S;
                var ls1 = 2 * l - ls2;
                r = Hsl.ToRgb(ls1, ls2, rangedH + 1 / 3.0);
                g = Hsl.ToRgb(ls1, ls2, rangedH);
                b = Hsl.ToRgb(ls1, ls2, rangedH - 1 / 3.0);
            }
            return Color.FromArgb((byte)(byte.MaxValue * r), (byte)(byte.MaxValue * g), (byte)(byte.MaxValue * b));
        }
        #endregion
    }
}