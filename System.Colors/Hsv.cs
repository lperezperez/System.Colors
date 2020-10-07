namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents an <see href="https://en.wikipedia.org/wiki/HSL_and_HSV">HSV</see> color.</summary>
    public sealed class Hsv : ColorSpace
    {
        #region Properties
        /// <summary>Gets the hue component of this <see cref="Hsv"/> instance.</summary>
        public double H { get; set; }
        /// <summary>Gets the value component of this <see cref="Hsv"/> of this instance.</summary>
        public double V { get; set; }
        /// <summary>Gets the saturation component of this <see cref="Hsv"/> of this instance.</summary>
        public double S { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            this.H = Color.FromArgb(color.R, color.G, color.B).GetHue();
            this.S = 1d - 1d * Math.Min(color.R, Math.Min(color.G, color.B)) / Math.Max(color.R, Math.Max(color.G, color.B));
            this.V = Math.Max(color.R, Math.Max(color.G, color.B)) / (double)byte.MaxValue;
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var f = this.H / 60.0 - Math.Floor(this.H / 60.0);
            var v = this.V * byte.MaxValue;
            var p = v * (1 - this.S);
            var q = v * (1 - f * this.S);
            var t = (byte)(v * (1 - (1 - f) * this.S));
            return (Convert.ToInt32(Math.Floor(this.H / 60.0)) % 6) switch
            {
                0 => Color.FromArgb((byte)v, t, (byte)p), 1 => Color.FromArgb((byte)q, (byte)v, (byte)p), 2 => Color.FromArgb((byte)p, (byte)v, t), 3 => Color.FromArgb((byte)p, (byte)q, (byte)v), 4 => Color.FromArgb(t, (byte)p, (byte)v), _ => Color.FromArgb((byte)v, (byte)p, (byte)q)
            };
        }
        #endregion
    }
}