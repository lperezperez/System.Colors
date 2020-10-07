namespace System.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FluentAssertions;
    using Xunit;
    [ExcludeFromCodeCoverage]
    public sealed class ConversionTests
    {
        #region Methods
        [Fact]
        public void BlueTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 32.302586667249486, a = 79.19666178930935, b = -107.86368104495168 };
            Color.Blue.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 32.302586667249486, C = 133.81586201619493, h = 306.2872015643272 };
            Color.Blue.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 32.302586667249486, u = -9.39986768735168, v = -130.35840748816472 };
            Color.Blue.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.15001662234042554, y = 0.060006648936170214, Y1 = 7.22 };
            Color.Blue.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 18.05, Y = 7.22, Z = 95.05 };
            Color.Blue.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 1, M = 1, Y = 0 };
            Color.Blue.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 1, M = 1, Y = 0, K = 0 };
            Color.Blue.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 240, S = 1, L = 0.5 };
            Color.Blue.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 240, S = 1, V = 1 };
            Color.Blue.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 26.870057685088806, a = 72.8850314708034, b = -190.92309216912813 };
            Color.Blue.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 0, G = 0, B = 255 };
            Color.Blue.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void CyanTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 91.11652110946342, a = -48.079618466228716, b = -14.138127754846131 };
            Color.Cyan.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 91.11652110946342, C = 50.11523090109904, h = 196.38631951007193 };
            Color.Cyan.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 91.11652110946342, u = -70.4724364962956, v = -15.216979595532692 };
            Color.Cyan.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.2246576486305945, y = 0.3287408149632598, Y1 = 78.74 };
            Color.Cyan.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 53.81, Y = 78.74, Z = 106.97 };
            Color.Cyan.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 1, M = 0, Y = 0 };
            Color.Cyan.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 1, M = 0, Y = 0, K = 0 };
            Color.Cyan.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 180, S = 1, L = 0.5 };
            Color.Cyan.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 180, S = 1, V = 1 };
            Color.Cyan.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 88.73556220591607, a = -47.04331494866765, b = -9.358720217187438 };
            Color.Cyan.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 0, G = 255, B = 255 };
            Color.Cyan.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void GreenTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 46.22881784262658, a = -51.69964732808236, b = 49.89795230983843 };
            Color.Green.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 46.22881784262658, C = 71.85164701357238, h = 136.01595610184012 };
            Color.Green.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 46.22881784262658, u = -43.77488691364997, v = 56.58999318863665 };
            Color.Green.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.3, y = 0.6, Y1 = 15.438342968146074 };
            Color.Green.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 7.719171484073037, Y = 15.438342968146074, Z = 2.573057161357679 };
            Color.Green.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 1, M = 0.4980392156862745, Y = 1 };
            Color.Green.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 1, M = 0, Y = 1, K = 0.4980392156862745 };
            Color.Green.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 120, S = 1, L = 0.25098039215686274 };
            Color.Green.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 120, S = 1, V = 0.5019607843137255 };
            Color.Green.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 39.29165683468448, a = -33.69259573574193, b = 23.621489228065062 };
            Color.Green.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 0, G = 128, B = 0 };
            Color.Green.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void MagentaTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 60.319933664076004, a = 98.25421868616114, b = -60.84298422386232 };
            Color.Magenta.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 60.319933664076004, C = 115.5671242996603, h = 328.232534153722 };
            Color.Magenta.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 60.319933664076004, u = 84.0748601055241, v = -108.71158324878692 };
            Color.Magenta.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.32092016238159676, y = 0.15415426251691475, Y1 = 28.48 };
            Color.Magenta.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 59.290000000000006, Y = 28.48, Z = 96.98 };
            Color.Magenta.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 0, M = 1, Y = 0 };
            Color.Magenta.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 0, M = 1, Y = 0, K = 0 };
            Color.Magenta.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 300, S = 1, L = 0.5 };
            Color.Magenta.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 300, S = 1, V = 1 };
            Color.Magenta.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 53.36665625650533, a = 104.92066381463533, b = -70.3874753168952 };
            Color.Magenta.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 255, G = 0, B = 255 };
            Color.Magenta.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void OrangeTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 74.93219484533535, a = 23.936049070113096, b = 78.95630717524574 };
            Color.Orange.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 74.93219484533535, C = 82.50474463834564, h = 73.1350246656041 };
            Color.Orange.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 74.93219484533535, u = 74.85081165927029, v = 73.99834319292597 };
            Color.Orange.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.5005024777110524, y = 0.4407949382859346, Y1 = 48.17026703630964 };
            Color.Orange.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 54.69513351815482, Y = 48.17026703630964, Z = 6.415044506051606 };
            Color.Orange.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 0, M = 0.3529411764705882, Y = 1 };
            Color.Orange.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 0, M = 0.3529411764705882, Y = 1, K = 0 };
            Color.Orange.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 38.8235294117647, S = 1, L = 0.5 };
            Color.Orange.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 38.82353210449219, S = 1, V = 1 };
            Color.Orange.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 69.40480317406687, a = 19.2102641411226, b = 43.103222932208766 };
            Color.Orange.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 255, G = 165, B = 0 };
            Color.Orange.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void RedTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 53.23288178584245, a = 80.10930952982204, b = 67.22006831026425 };
            Color.Red.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 53.23288178584245, C = 104.57551843993618, h = 40.00015790646365 };
            Color.Red.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 53.23288178584245, u = 175.05303573649485, v = 37.750505032665004 };
            Color.Red.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.6400744994567747, y = 0.3299705106316933, Y1 = 21.26 };
            Color.Red.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 41.24, Y = 21.26, Z = 1.9300000000000002 };
            Color.Red.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 0, M = 1, Y = 1 };
            Color.Red.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 0, M = 1, Y = 1, K = 0 };
            Color.Red.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 0, S = 1, L = 0.5 };
            Color.Red.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 0, S = 1, V = 1 };
            Color.Red.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 46.10856753359401, a = 78.96233161759665, b = 29.794252423892623 };
            Color.Red.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 255, G = 0, B = 0 };
            Color.Red.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void VioletTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 69.69362286537107, a = 56.36844996271595, b = -36.823650913525505 };
            Color.Violet.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 69.69362286537107, C = 67.33040485397663, h = 326.8447379184296 };
            Color.Violet.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 69.69362286537107, u = 51.851693067658644, v = -67.05114389292648 };
            Color.Violet.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.31790415819545653, y = 0.2184306570349918, Y1 = 40.31545298667633 };
            Color.Violet.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 58.6751434893349, Y = 40.31545298667633, Z = 85.57806038710456 };
            Color.Violet.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 0.06666666666666665, M = 0.4901960784313726, Y = 0.06666666666666665 };
            Color.Violet.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 0, M = 0.45378151260504207, Y = 0, K = 0.06666666666666665 };
            Color.Violet.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 300, S = 0.7605633802816901, L = 0.7215686274509804 };
            Color.Violet.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 300, S = 0.45378151260504207, V = 0.9333333333333333 };
            Color.Violet.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 63.49445092815302, a = 53.83633987237564, b = -35.46516992220551 };
            Color.Violet.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 238, G = 130, B = 238 };
            Color.Violet.To<Rgb>().Should().Be(colorSpace);
        }
        [Fact]
        public void YellowTest()
        {
            IColorSpace colorSpace;
            colorSpace = new CieLab { L = 97.13824698129729, a = -21.555908334832285, b = 94.48248544644461 };
            Color.Yellow.To<CieLab>().Should().Be(colorSpace);
            colorSpace = new CieLch { L = 97.13824698129729, C = 96.91025353530611, h = 102.85189620924648 };
            Color.Yellow.To<CieLch>().Should().Be(colorSpace);
            colorSpace = new CieLuv { L = 97.13824698129729, u = 7.702962282477956, v = 106.78912110756598 };
            Color.Yellow.To<CieLuv>().Should().Be(colorSpace);
            colorSpace = new CieXyy { x = 0.41932146163480916, y = 0.5052551326036051, Y1 = 92.78 };
            Color.Yellow.To<CieXyy>().Should().Be(colorSpace);
            colorSpace = new CieXyz { X = 77, Y = 92.78, Z = 13.85 };
            Color.Yellow.To<CieXyz>().Should().Be(colorSpace);
            colorSpace = new Cmy { C = 0, M = 0, Y = 1 };
            Color.Yellow.To<Cmy>().Should().Be(colorSpace);
            colorSpace = new Cmyk { C = 0, M = 0, Y = 1, K = 0 };
            Color.Yellow.To<Cmyk>().Should().Be(colorSpace);
            colorSpace = new Hsl { H = 60, S = 1, L = 0.5 };
            Color.Yellow.To<Hsl>().Should().Be(colorSpace);
            colorSpace = new Hsv { H = 60, S = 1, V = 1 };
            Color.Yellow.To<Hsv>().Should().Be(colorSpace);
            colorSpace = new HunterLab { L = 96.32237538599222, a = -25.871454996970524, b = 58.90047330399479 };
            Color.Yellow.To<HunterLab>().Should().Be(colorSpace);
            colorSpace = new Rgb { R = 255, G = 255, B = 0 };
            Color.Yellow.To<Rgb>().Should().Be(colorSpace);
        }
        #endregion
    }
}