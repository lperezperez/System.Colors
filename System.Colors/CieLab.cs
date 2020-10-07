namespace System.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CIELAB_color_space">CIELAB</see> color.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of the properties correspond to the names in the CIELAB definition for clarity.")]
    public class CieLab : ColorSpace
    {
        #region Constants
        private const double A = 7.787;
        private const double B = 16d / 116;
        #endregion
        #region Properties
        /// <summary>Gets or sets the value from green (−) to red (+).</summary>
        public double a { get; set; }
        /// <summary>Gets or sets the value from blue (−) to yellow (+).</summary>
        public double b { get; set; }
        /// <summary>Gets or sets the lightness from black (0) to white (100).</summary>
        public double L { get; set; }
        #endregion
        #region Methods
        /// <summary>Pivots the specified <paramref name="value"/>.</summary>
        /// <param name="value">The value of a component of a <see cref="CieXyz"/> instance.</param>
        /// <returns>A pivoted <see cref="CieXyz"/> component value.</returns>
        private static double PivotXyz(double value) => value > CieXyz.T0 ? Math.Pow(value, 1d / 3) : CieLab.A * value + CieLab.B;
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cieXyz = new CieXyz();
            cieXyz.FromColor(color);
            var y = CieLab.PivotXyz(cieXyz.Y / CieXyz.WhiteReference.Y);
            this.L = Math.Max(0, 116 * y - 16);
            this.a = 500 * (CieLab.PivotXyz(cieXyz.X / CieXyz.WhiteReference.X) - y);
            this.b = 200 * (y - CieLab.PivotXyz(cieXyz.Z / CieXyz.WhiteReference.Z));
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var y = (this.L + 16) / 116;
            var x = this.a / 500 + y;
            var z = y - this.b / 200;
            y = Math.Pow(y, 3) > CieXyz.T0 ? Math.Pow(y, 3) : (y - CieLab.B) / CieLab.A;
            x = Math.Pow(x, 3) > CieXyz.T0 ? Math.Pow(x, 3) : (x - CieLab.B) / CieLab.A;
            z = Math.Pow(z, 3) > CieXyz.T0 ? Math.Pow(z, 3) : (z - CieLab.B) / CieLab.A;
            var cieXyz = new CieXyz { X = CieXyz.WhiteReference.X * x, Y = CieXyz.WhiteReference.Y * y, Z = CieXyz.WhiteReference.Z * z };
            return cieXyz.ToColor();
        }
        /// <inheritdoc/>
        public override string ToString() => $"L: {this.L}, a: {this.a}, b: {this.b}";
        #endregion
    }
}