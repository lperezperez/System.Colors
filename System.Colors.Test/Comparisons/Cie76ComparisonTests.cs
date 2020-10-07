namespace System.Colors.Comparisons
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FluentAssertions;
    using Xunit;
    [ExcludeFromCodeCoverage]
    public sealed class Cie76ComparisonTests
    {
        #region Constants
        private const double Precision = .00005;
        #endregion
        #region Fields
        private readonly Cie76Comparison cie76Comparison;
        #endregion
        #region Constructors
        public Cie76ComparisonTests() => this.cie76Comparison = new Cie76Comparison();
        #endregion
        #region Methods
        public static IEnumerable<object[]> GetColors() { yield return new object[] { Color.Red, Color.Blue, 176.3327 }; }
        public static IEnumerable<object[]> GetColorSpaces()
        {
            yield return new object[] { new CieLab { L = 50, a = 67, b = 88 }, new CieLab { L = 50, a = 15, b = 22 }, 84.0238 };
            yield return new object[] { new CieLab { L = 88.17, a = 67, b = 88 }, new CieLab { L = 87.16, a = 65, b = 66 }, 22.1138 };
        }
        [Theory, MemberData(nameof(Cie76ComparisonTests.GetColors))]
        public void ColorDistanceTest(Color left, Color right, double expected) => this.cie76Comparison.Distance(left, right).Should().BeApproximately(expected, Cie76ComparisonTests.Precision);
        [Theory, MemberData(nameof(Cie76ComparisonTests.GetColorSpaces))]
        public void ColorSpaceDistanceTest(IColorSpace left, IColorSpace right, double expected) => this.cie76Comparison.Distance(left, right).Should().BeApproximately(expected, Cie76ComparisonTests.Precision);
        #endregion
    }
}