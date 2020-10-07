namespace System.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CIELUV">CIELUV</see> color.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of the properties correspond to the names in the CIELUV definition for clarity.")]
    public sealed class CieLuv : ColorSpace
    {
        #region Constants
        private const double Kappa = 24389d / 27;
        #endregion
        #region Properties
        private static double WhiteDenominator => CieLuv.GetDenominator(CieXyz.WhiteReference);
        /// <summary>Gets or sets the lightness from black (0) to white (100).</summary>
        public double L { get; set; }
        /// <summary>A component of a <see href="https://en.wikipedia.org/wiki/White_point">white point</see>.</summary>
        public double u { get; set; }
        /// <summary>A component of a <see href="https://en.wikipedia.org/wiki/White_point">white point</see>.</summary>
        public double v { get; set; }
        #endregion
        #region Methods
        private static double GetDenominator(CieXyz cieXyz) => cieXyz.X + 15.0 * cieXyz.Y + 3.0 * cieXyz.Z;
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cieXyz = new CieXyz();
            cieXyz.FromColor(color);
            var white = CieXyz.WhiteReference;
            var y = cieXyz.Y / CieXyz.WhiteReference.Y;
            this.L = y > CieXyz.T0 ? 116 * Math.Pow(y, 1d / 3) - 16 : CieLuv.Kappa * y;
            var targetDenominator = CieLuv.GetDenominator(cieXyz);
            var referenceDenominator = CieLuv.WhiteDenominator;
            // ReSharper disable CompareOfFloatsByEqualityOperator
            var xTarget = targetDenominator == 0 ? 0 : 4 * cieXyz.X / targetDenominator - 4 * white.X / referenceDenominator;
            var yTarget = targetDenominator == 0 ? 0 : 9 * cieXyz.Y / targetDenominator - 9 * white.Y / referenceDenominator;
            // ReSharper restore CompareOfFloatsByEqualityOperator
            this.u = 13 * this.L * xTarget;
            this.v = 13 * this.L * yTarget;
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var white = CieXyz.WhiteReference;
            const double c = -1.0 / 3.0;
            var a = 1.0 / 3.0 * (52.0 * this.L / (this.u + 13 * this.L * (4.0 * white.X / CieLuv.WhiteDenominator)) - 1.0);
            var y = this.L > CieLuv.Kappa * CieXyz.T0 ? Math.Pow((this.L + 16.0) / 116.0, 3) : this.L / CieLuv.Kappa;
            var b = -5.0 * y;
            var d = y * (39.0 * this.L / (this.v + 13.0 * this.L * (9.0 * white.Y / CieLuv.WhiteDenominator)) - 5.0);
            var x = (d - b) / (a - c);
            var z = x * a + b;
            return new CieXyz { X = 100 * x, Y = 100 * y, Z = 100 * z }.ToColor();
        }
        #endregion
    }
}