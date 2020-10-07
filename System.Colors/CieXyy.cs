namespace System.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    /// <summary>
    ///     Represents a <see href="https://en.wikipedia.org/wiki/CIE_1931_color_space#CIE_xy_chromaticity_diagram_and_the_CIE_xyY_color_space">CIE xyY</see> color.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of the properties correspond to the names in the CIE xyY definition for clarity.")]
    public sealed class CieXyy : ColorSpace
    {
        #region Properties
        /// <summary>Gets or sets a chromatic value of this <see cref="CieXyy"/> instance.</summary>
        public double x { get; set; }
        /// <summary>Gets or sets a chromatic value of this <see cref="CieXyy"/> instance.</summary>
        public double y { get; set; }
        /// <summary>Gets or sets a value that represents the luminance of this <see cref="CieXyy"/> instance.</summary>
        /// <remarks>
        ///     The <see langword="property"/> is renamed to allow to generate the documentation in Windows because of its limitations to distinguish lowercase an uppercase in file names.
        /// </remarks>
        public double Y1 { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cieXyz = color.To<CieXyz>();
            this.Y1 = cieXyz.Y;
            var sumCieXyz = cieXyz.X + cieXyz.Y + cieXyz.Z;
            if (sumCieXyz.BasicallyEqualTo(0))
            {
                this.x = 0;
                this.y = 0;
            }
            else
            {
                this.x = cieXyz.X / sumCieXyz;
                this.y = cieXyz.Y / sumCieXyz;
            }
        }
        /// <inheritdoc/>
        public override Color ToColor() => new CieXyz { X = this.x * (this.Y1 / this.y), Y = this.Y1, Z = (1 - this.x - this.y) * (this.Y1 / this.y) }.ToColor();
        /// <inheritdoc/>
        public override string ToString() => $"{nameof(this.x)}: {this.x}, {nameof(this.y)}: {this.y}, Y: {this.Y1}";
        #endregion
    }
}