namespace System.Colors.Comparisons
{
    using System.Drawing;
    /// <summary>
    ///     Represents the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE94">CIE94</see> formula to compare distances between <see cref="IColorSpace"/> instances.
    /// </summary>
    public sealed class Cie94Comparison : IColorSpaceComparison
    {
        #region Fields
        private Application application;
        #endregion
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="Cie94Comparison"/> <see langword="class"/>.</summary>
        public Cie94Comparison()
            : this(Application.GraphicArts) { }
        /// <summary>Initializes a new instance of the <see cref="Cie94Comparison"/> <see langword="class"/>.</summary>
        /// <param name="application">Contains the constants used for this <see cref="Cie94Comparison"/> instance.</param>
        public Cie94Comparison(Application application) => this.ApplicationType = application;
        #endregion
        #region Enums
        /// <summary>Defines the application purposes used in the <see cref="Cie94Comparison"/>.</summary>
        public enum Application
        {
            /// <summary>Comparison based on graphics arts purposes.</summary>
            GraphicArts,
            /// <summary>Comparison based on textile industries purposes.</summary>
            Textiles
        }
        #endregion
        #region Properties
        /// <summary>Gets or sets the <see cref="Application"/>.</summary>
        public Application ApplicationType
        {
            get => this.application;
            set
            {
                switch (value)
                {
                    case Application.GraphicArts:
                        this.Kl = 1.0;
                        this.K1 = .045;
                        this.K2 = .015;
                        break;
                    case Application.Textiles:
                        this.Kl = 2.0;
                        this.K1 = .048;
                        this.K2 = .014;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                this.application = value;
            }
        }
        private double K1 { get; set; }
        private double K2 { get; set; }
        private double Kl { get; set; }
        #endregion
        #region Methods
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE94">CIE94</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="CieLab"/> to compare.</param>
        /// <param name="right">An <see cref="CieLab"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(CieLab left, CieLab right)
        {
            var deltaL = left.L - right.L;
            var c1 = Math.Sqrt(Math.Pow(left.a, 2) + Math.Pow(left.b, 2));
            var c2 = Math.Sqrt(Math.Pow(right.a, 2) + Math.Pow(right.b, 2));
            var deltaA = left.a - right.a;
            var deltaB = left.b - right.b;
            var deltaC = c1 - c2;
            var deltaH = Math.Pow(deltaA, 2) + Math.Pow(deltaB, 2) - Math.Pow(deltaC, 2);
            deltaH = deltaH < 0 ? 0 : Math.Sqrt(deltaH);
            const double Sl = 1.0;
            const double Kc = 1.0;
            const double Kh = 1.0;
            var sc = 1.0 + this.K1 * c1;
            var sh = 1.0 + this.K2 * c1;
            var result = Math.Pow(deltaL / (this.Kl * Sl), 2) + Math.Pow(deltaC / (Kc * sc), 2) + Math.Pow(deltaH / (Kh * sh), 2);
            return result < 0 ? 0 : Math.Sqrt(result);
        }
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE94">CIE94</see> formula.
        /// </summary>
        /// <param name="left">An <see cref="IColorSpace"/> to compare.</param>
        /// <param name="right">An <see cref="IColorSpace"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(IColorSpace left, IColorSpace right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        /// <summary>
        ///     Gets the distance between <paramref name="left"/> and <paramref name="right"/> based on the <see href="http://en.wikipedia.org/wiki/Color_difference#CIE94">CIE94</see> formula.
        /// </summary>
        /// <param name="left">A <see cref="Color"/> to compare.</param>
        /// <param name="right">A <see cref="Color"/> to compare.</param>
        /// <returns>Score based on similarity, the lower the score the closer that <paramref name="left"/> and <paramref name="right"/> are.</returns>
        public double Distance(Color left, Color right) => this.Distance(left.To<CieLab>(), right.To<CieLab>());
        #endregion
    }
}