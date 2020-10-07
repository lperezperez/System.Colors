namespace System.Colors.Comparisons
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FluentAssertions;
    using Xunit;
    [ExcludeFromCodeCoverage]
    public sealed class CmcComparisonTest
    {
        #region Constants
        private const double Precision = .0000005;
        #endregion
        #region Fields
        private readonly CmcComparison cmcComparison;
        #endregion
        #region Constructors
        public CmcComparisonTest() => this.cmcComparison = new CmcComparison();
        #endregion
        #region Methods
        public static IEnumerable<object[]> GetColors()
        {
            yield return new object[] { Color.Red, Color.Blue, 2, 95.721138 };
            yield return new object[] { Color.Red, Color.Blue, 1, 97.068662 };
        }
        public static IEnumerable<object[]> GetColorSpaces()
        {
            // Get distance between red and maroon 1 with a lightness value for the threshold of imperceptibility.
            yield return new object[] { new CieLab { L = 24.8290, a = 60.0930, b = 38.1800 }, new CieLab { L = 53.2300, a = 80.1090, b = 67.2200 }, 1, 42.202017 };
            // Get distance between red and maroon 2 with a lightness value for acceptability.
            yield return new object[] { new CieLab { L = 24.8290, a = 60.0930, b = 38.1800 }, new CieLab { L = 53.2300, a = 80.1090, b = 67.2200 }, 2, 23.916523 };
            // Get distance between white and egg shell 1 with a lightness value for the threshold of imperceptibility.
            yield return new object[] { new CieLab { L = 100, a = 0, b = 0 }, new CieLab { L = 89.9490, a = 13.8320, b = 6.8160 }, 1, 25.103175 };
            // Get distance between white and egg shell 2 with a lightness value for acceptability.
            yield return new object[] { new CieLab { L = 100, a = 0, b = 0 }, new CieLab { L = 89.9490, a = 13.8320, b = 6.8160 }, 2, 24.406318 };
        }
        [Theory, MemberData(nameof(CmcComparisonTest.GetColors))]
        public void ColorDistanceTest(Color left, Color right, double lightness, double expected)
        {
            this.cmcComparison.Lightness = lightness;
            this.cmcComparison.Distance(left, right).Should().BeApproximately(expected, CmcComparisonTest.Precision);
        }
        [Theory, MemberData(nameof(CmcComparisonTest.GetColorSpaces))]
        public void ColorSpaceDistanceTest(IColorSpace left, IColorSpace right, double lightness, double expected)
        {
            this.cmcComparison.Lightness = lightness;
            this.cmcComparison.Distance(left, right).Should().BeApproximately(expected, CmcComparisonTest.Precision);
        }
        #endregion
    }
}