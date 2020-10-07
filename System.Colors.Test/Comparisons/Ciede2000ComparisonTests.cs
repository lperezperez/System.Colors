namespace System.Colors.Comparisons
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using FluentAssertions;
    using Xunit;
    [ExcludeFromCodeCoverage]
    public sealed class Ciede2000ComparisonTests
    {
        #region Constants
        private const double Precision = .00005;
        #endregion
        #region Fields
        private readonly Ciede2000Comparison ciede2000Comparison;
        #endregion
        #region Constructors
        public Ciede2000ComparisonTests() => this.ciede2000Comparison = new Ciede2000Comparison();
        #endregion
        #region Methods
        public static IEnumerable<object[]> GetCieLabs()
        {
            using var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), Path.ChangeExtension(nameof(Ciede2000ComparisonTests), "data")));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == string.Empty || line.StartsWith("//"))
                    continue;
                var fields = line.Split('\t');
                yield return new object[] { new CieLab { L = double.Parse(fields[0], CultureInfo.InvariantCulture), a = double.Parse(fields[1], CultureInfo.InvariantCulture), b = double.Parse(fields[2], CultureInfo.InvariantCulture) }, new CieLab { L = double.Parse(fields[3], CultureInfo.InvariantCulture), a = double.Parse(fields[4], CultureInfo.InvariantCulture), b = double.Parse(fields[5], CultureInfo.InvariantCulture) }, double.Parse(fields[6], CultureInfo.InvariantCulture) };
            }
        }
        public static IEnumerable<object[]> GetColors() { yield return new object[] { Color.Red, Color.Blue, 52.8787 }; }
        [Theory, MemberData(nameof(Ciede2000ComparisonTests.GetColors))]
        public void ColorDistanceTest(Color left, Color right, double expected) => this.ciede2000Comparison.Distance(left, right).Should().BeApproximately(expected, Ciede2000ComparisonTests.Precision);
        [Theory, MemberData(nameof(Ciede2000ComparisonTests.GetCieLabs))]
        public void ColorSpaceDistanceTest(IColorSpace left, IColorSpace right, double expected) => this.ciede2000Comparison.Distance(left, right).Should().BeApproximately(expected, Ciede2000ComparisonTests.Precision);
        #endregion
    }
}