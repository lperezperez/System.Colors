namespace System.Colors
{
    using System.Drawing;
    /// <summary>Represents a <see href="https://en.wikipedia.org/wiki/CIELAB_color_space#Hunter_Lab">Hunter Lab</see> color.</summary>
    public sealed class HunterLab : CieLab
    {
        #region Methods
        /// <inheritdoc/>
        public override void FromColor(Color color)
        {
            var cieXyz = color.To<CieXyz>();
            this.L = 10 * Math.Sqrt(cieXyz.Y);
            this.a = cieXyz.Y != 0 ? 17.5 * ((1.02 * cieXyz.X - cieXyz.Y) / Math.Sqrt(cieXyz.Y)) : 0;
            this.b = cieXyz.Y != 0 ? 7 * ((cieXyz.Y - .847 * cieXyz.Z) / Math.Sqrt(cieXyz.Y)) : 0;
        }
        /// <inheritdoc/>
        public override Color ToColor()
        {
            var x = this.a / 17.5 * (this.L / 10);
            var y = Math.Pow(this.L / 10, 2);
            var z = this.b / 7 * this.L / 10;
            var cieXyz = new CieXyz { X = (x + y) / 1.02, Y = y, Z = -(z - y) / .847 };
            return cieXyz.ToColor();
        }
        #endregion
    }
}