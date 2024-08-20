using Microsoft.QualityTools.Testing.Fakes;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_2_and_4_result_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Sum_0_and_0_result_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 7)]
        [InlineData(-3, -5, -8)]
        [InlineData(3, -5, -2)]
        [InlineData(-3, 5, 2)]
        public void Sum_with_result(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void Sum_throws_OverflowEx(int a, int b)
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }

        [Theory]
        [InlineData(19, false)]
        [InlineData(20, false)]
        [InlineData(21, false)]
        [InlineData(22, false)]
        [InlineData(23, false)]
        [InlineData(24, true)]
        [InlineData(25, true)]
        public void IsWeekend(int day, bool exp)
        {
            DateTime dt = new DateTime(2024, 8, day);
            Calc calc = new Calc();

            if (exp)
                Assert.True(calc.IsWeekend(dt));
            else
                Assert.False(calc.IsWeekend(dt));
        }

        [Theory]
        [InlineData(23, 12, false)]
        [InlineData(24, 12, true)]
        public void IsFeiertag(int day, int month, bool exp)
        {
            DateTime dt = new DateTime(2024, month, day);
            Calc calc = new Calc();

            Assert.Equal(exp, calc.IsFeiertag(dt));
        }

        [Fact]
        public void IsWeekendOrFeiertagToday()
        {
            Calc calc = new Calc();
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 19);
                Assert.False(calc.IsWeekendOrFeiertagToday());//Mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 20);
                Assert.False(calc.IsWeekendOrFeiertagToday());//Di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 21);
                Assert.False(calc.IsWeekendOrFeiertagToday());//Mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 22);
                Assert.False(calc.IsWeekendOrFeiertagToday());//Do
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 23);
                Assert.False(calc.IsWeekendOrFeiertagToday());//Fr

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 24);
                Assert.True(calc.IsWeekendOrFeiertagToday());//Sa
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 8, 25);
                Assert.True(calc.IsWeekendOrFeiertagToday());//So

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 12, 24);
                Assert.True(calc.IsWeekendOrFeiertagToday());//24.12
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 12, 25);
                Assert.True(calc.IsWeekendOrFeiertagToday());//25.12
            }
        }

    }
}