namespace System.Colors.Comparisons
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FluentAssertions;
    using Xunit;
    [ExcludeFromCodeCoverage]
    public sealed class Cie94ComparisonTests
    {
        #region Constants
        private const double Precision = .0000005;
        #endregion
        #region Fields
        private readonly Cie94Comparison cie94Comparison;
        #endregion
        #region Constructors
        public Cie94ComparisonTests() => this.cie94Comparison = new Cie94Comparison();
        #endregion
        #region Methods
        public static IEnumerable<object[]> GetColors()
        {
            // GraphicArts pinks
            yield return new object[] { Color.Red, Color.Blue, 70.575975, 71.001792 };
        }
        public static IEnumerable<object[]> GetColorSpaces()
        {
            // GraphicArts pinks
            yield return new object[] { new CieLab { L = 70.1, a = 53, b = -3.2 }, new CieLab { L = 67.4, a = 47.7, b = -5.34 }, 3.408967, 2.466346 };
        }
        [Theory, MemberData(nameof(Cie94ComparisonTests.GetColors))]
        public void ColorDistanceTest(Color left, Color right, double expectedGraphicsArts, double expectedTextiles)
        {
            this.cie94Comparison.ApplicationType = Cie94Comparison.Application.GraphicArts;
            this.cie94Comparison.Distance(left.To<CieLab>(), right.To<CieLab>()).Should().BeApproximately(expectedGraphicsArts, Cie94ComparisonTests.Precision);
            if (this.cie94Comparison.ApplicationType == Cie94Comparison.Application.GraphicArts)
                this.cie94Comparison.ApplicationType = Cie94Comparison.Application.Textiles;
            this.cie94Comparison.Distance(left, right).Should().BeApproximately(expectedTextiles, Cie94ComparisonTests.Precision);
        }
        [Theory, MemberData(nameof(Cie94ComparisonTests.GetColorSpaces))]
        public void ColorSpaceDistanceTest(IColorSpace left, IColorSpace right, double expectedGraphicsArts, double expectedTextiles)
        {
            this.cie94Comparison.ApplicationType = Cie94Comparison.Application.GraphicArts;
            this.cie94Comparison.Distance(left.To<CieLab>(), right.To<CieLab>()).Should().BeApproximately(expectedGraphicsArts, Cie94ComparisonTests.Precision);
            if (this.cie94Comparison.ApplicationType == Cie94Comparison.Application.GraphicArts)
                this.cie94Comparison.ApplicationType = Cie94Comparison.Application.Textiles;
            this.cie94Comparison.Distance(left, right).Should().BeApproximately(expectedTextiles, Cie94ComparisonTests.Precision);
        }
        #endregion
    }
}