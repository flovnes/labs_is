using lab4;
using Xunit;

namespace tests
{
    public class Tests
    {
        [Fact]
        public static void TestParseInput()
        {
            string input = "0.01000011000 * 2 ^-101";
            string expectedM_str = "001000011000";
            string expectedO_str = "1101";

            Lab4.ParseInput(input, out string actualM_str, out string actualO_str);

            Assert.Equal(expectedM_str, actualM_str);
            Assert.Equal(expectedO_str, actualO_str);
        }

        [Fact]
        public void TestShiftRight()
        {
            string input = "101010";
            int order = 2;
            string expected = "001010";

            string actual = Lab4.ShiftRight(input, order);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddition()
        {
            string a = "110110001";
            string b = "1011101010";
            string expected = "100100110";

            string actual = Lab4.Addition(a, b);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIntDecimalSigned()
        {
            string input = "01010101";
            int expected = 85;

            int actual = Lab4.intDecimalSigned(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDoubleDecimalSigned()
        {
            string input = "01010101";
            double expected = 0.6640625;

            double actual = Lab4.doubleDecimalSigned(input);

            Assert.Equal(expected, actual, 7);
        }

        [Fact]
        public void TestIntDecimalSupp()
        {
            string input = "11010101";
            int expected = -43;

            int actual = Lab4.intDecimalSupp(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDoubleDecimalSupp()
        {
            string input = "11010101";
            double expected = -0.1679688;

            double actual = Lab4.doubleDecimalSupp(input);

            Assert.Equal(expected, actual, 7);
        }

        [Fact]
        public void TestIntToSupp()
        {
            string input = "11010101";
            string expected = "10101011";

            string actual = Lab4.intToSupp(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFloatToSupp()
        {
            string input = "11010101";
            string expected = "01010110";

            string actual = Lab4.floatToSupp(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToSigned()
        {
            string input = "11010101";
            string expected = "11010101";

            string actual = Lab4.toSigned(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestInvertSign()
        {
            string input = "01010101";
            string expected = "11010101";

            string actual = Lab4.InvertSign(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBitToSign()
        {
            string input = "01010101";
            string expected = "";

            string actual = Lab4.bitToSign(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIntToBinary()
        {
            int input = 85;
            string expected = "1010101";

            string actual = Lab4.intToBinary(input);

            Assert.Equal(expected, actual);
        }
    }
}