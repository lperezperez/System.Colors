namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CMYK_color_model">CMYK</see> color.</summary>
    /// ef
    public sealed class Cmyk : ColorSpace
    {
        #region Properties
        /// <summary>Gets or sets the cyan amount value.</summary>
        public double C { get; set; }
        /// <summary>Gets or sets the black amount value.</summary>
        public double K { get; set; }
        /// <summary>Gets or sets the magenta amount value.</summary>
        public double M { get; set; }
        /// <summary>Gets or sets the yellow amount value.</summary>
        public double Y { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cmy = new Cmy();
            cmy.FromColor(color);
            var k = 1.0;
            if (cmy.C < k) k = cmy.C;
            if (cmy.M < k) k = cmy.M;
            if (cmy.Y < k) k = cmy.Y;
            this.K = k;
            if (k.BasicallyEqualTo(1))
            {
                this.C = 0;
                this.M = 0;
                this.Y = 0;
            }
            else
            {
                this.C = (cmy.C - k) / (1 - k);
                this.M = (cmy.M - k) / (1 - k);
                this.Y = (cmy.Y - k) / (1 - k);
            }
        }
        /// <inheritdoc/>
        public override Color ToColor() => new Cmy { C = this.C * (1 - this.K) + this.K, M = this.M * (1 - this.K) + this.K, Y = this.Y * (1 - this.K) + this.K }.ToColor();
        /// <inheritdoc/>
        public override string ToString() => $"{nameof(this.C)}: {this.C}, {nameof(this.M)}: {this.M}, {nameof(this.Y)}: {this.Y}, {nameof(this.K)}: {this.K}";
        #endregion
    }
}