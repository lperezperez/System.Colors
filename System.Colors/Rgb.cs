namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/RGB_color_model">RGB</see> color.</summary>
    public class Rgb : ColorSpace
    {
        #region Properties
        /// <summary>Gets or sets the blue amount of this <see cref="Rgb"/> instance.</summary>
        public byte B { get; set; }
        /// <summary>Gets or sets the green amount of this <see cref="Rgb"/> instance.</summary>
        public byte G { get; set; }
        /// <summary>Gets or sets the red amount of this <see cref="Rgb"/> instance.</summary>
        public byte R { get; set; }
        #endregion
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;
        }
        /// <inheritdoc/>
        public override Color ToColor() => Color.FromArgb(this.R, this.G, this.B);
        /// <inheritdoc/>
        public override string ToString() => $"{nameof(this.R)}: {this.R}, {nameof(this.G)}: {this.G}, {nameof(this.B)}: {this.B}";
        #endregion
    }
}