namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CMY_color_model">CMY</see> color.</summary>
    public sealed class Cmy : ColorSpace
    {
        #region Properties
        /// <summary>Gets or sets the cyan amount value.</summary>
        public double C { get; set; }
        /// <summary>Gets or sets the magenta amount value.</summary>
        public double M { get; set; }
        /// <summary>Gets or sets the yellow amount value.</summary>
        public double Y { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            this.C = 1 - color.R / (double)byte.MaxValue;
            this.M = 1 - color.G / (double)byte.MaxValue;
            this.Y = 1 - color.B / (double)byte.MaxValue;
        }
        /// <inheritdoc/>
        public override Color ToColor() => Color.FromArgb((byte)((1 - this.C) * byte.MaxValue), (byte)((1 - this.M) * byte.MaxValue), (byte)((1 - this.Y) * byte.MaxValue));
        #endregion
    }
}