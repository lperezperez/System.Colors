namespace System.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    /// <summary>
    ///     Represents a <see href="https://en.wikipedia.org/wiki/CIELAB_color_space#Cylindrical_representation%3A_CIELCh_or_CIEHLC">CIELCh</see> color.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of the properties correspond to the names in the CIELCh definition for clarity.")]
    public sealed class CieLch : ColorSpace
    {
        #region Properties
        /// <summary>Gets or sets the <see href="https://en.wikipedia.org/wiki/Colorfulness#Chroma">chroma</see> component.</summary>
        public double C { get; set; }
        /// <summary>Gets or sets the <see href="https://en.wikipedia.org/wiki/Hue">hue</see> component.</summary>
        public double h { get; set; }
        /// <summary>Gets or sets the lightness from black (0) to white (100).</summary>
        public double L { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cieLab = color.To<CieLab>();
            this.h = Math.Atan2(cieLab.b, cieLab.a);
            // convert from radians to degrees
            if (this.h > 0)
                this.h = this.h / Math.PI * 180.0;
            else
                this.h = 360 - Math.Abs(this.h) / Math.PI * 180;
            if (this.h < 0)
                this.h += 360;
            else if (this.h >= 360)
                this.h -= 360;
            this.L = cieLab.L;
            this.C = Math.Sqrt(Math.Pow(cieLab.a, 2) + Math.Pow(cieLab.b, 2));
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var hRadians = this.h * Math.PI / 180.0;
            var lab = new CieLab { L = this.L, a = Math.Cos(hRadians) * this.C, b = Math.Sin(hRadians) * this.C };
            return lab.ToColor();
        }
        /// <inheritdoc/>
        public override string ToString() => $"{nameof(this.L)}: {this.L}, {nameof(this.C)}: {this.C}, {nameof(this.h)}: {this.h}";
        #endregion
    }
}