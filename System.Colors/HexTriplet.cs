namespace System.Colors
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    /// <summary>Represents an <see href="https://en.wikipedia.org/wiki/Web_colors#Hex_triplet">Hex triplet</see> color.</summary>
    public sealed class HexTriplet : Rgb
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="HexTriplet"/> <see langword="class"/>.</summary>
        /// <param name="hexadecimal">The hexadecimal color code.</param>
        public HexTriplet(string hexadecimal)
        {
            if (string.IsNullOrEmpty(hexadecimal))
                throw new ArgumentNullException(nameof(hexadecimal));
            if (!hexadecimal.StartsWith("#"))
                hexadecimal = '#' + hexadecimal;
            var index = 1;
            if (hexadecimal.Length == 4)
                hexadecimal = $"#{hexadecimal[index]}{hexadecimal[index]}{hexadecimal[++index]}{hexadecimal[index]}{hexadecimal[++index]}{hexadecimal[index]}";
            var match = Regex.Match(hexadecimal, @"#*([0-9a-fA-F)]{2})([0-9a-fA-F)]{2})([0-9a-fA-F)]{2})");
            if (match.Groups.Count != 4)
                throw new ArgumentException("The value has an invalid format.", nameof(hexadecimal));
            index = 1;
            this.R = byte.Parse(match.Groups[index].Value, NumberStyles.HexNumber);
            this.G = byte.Parse(match.Groups[++index].Value, NumberStyles.HexNumber);
            this.B = byte.Parse(match.Groups[++index].Value, NumberStyles.HexNumber);
        }
        /// <summary>Initializes a new instance of the <see cref="HexTriplet"/> <see langword="class"/>.</summary>
        public HexTriplet() { }
        #endregion
        #region Methods
        /// <summary>Defines an explicit conversion from or to <paramref name="hexTriplet"/>.</summary>
        /// <param name="hexTriplet">A hex triplet value.</param>
        public static explicit operator HexTriplet(string hexTriplet) => new HexTriplet(hexTriplet);
        /// <summary>Defines an implicit conversion from or to <paramref name="hexTriplet"/>.</summary>
        /// <param name="hexTriplet">A hex triplet value.</param>
        public static explicit operator string(HexTriplet hexTriplet) => hexTriplet.ToString();
        /// <inheritdoc/>
        public override string ToString() => $"#{this.R:X2}{this.G:X2}{this.B:X2}";
        #endregion
    }
}