using Core;
using NaughtyStrings;
using System.Diagnostics;
namespace CalendarTests
{
    public class CalendarTests
    {
        [Fact]
        public void TestGetMonthStringByOrdinal()
        {
            Calendar calendar = new Calendar();
            var month = calendar.GetMonthByOrdinal(1);
            Assert.Equal("January", month);

            month = calendar.GetMonthByOrdinal(2);
            Assert.Equal("February", month);

            month = calendar.GetMonthByOrdinal(3);
            Assert.Equal("March", month);

            month = calendar.GetMonthByOrdinal(4);
            Assert.Equal("April", month);

            month = calendar.GetMonthByOrdinal(5);
            Assert.Equal("May", month);

            month = calendar.GetMonthByOrdinal(6);
            Assert.Equal("June", month);

            month = calendar.GetMonthByOrdinal(7);
            Assert.Equal("July", month);

            month = calendar.GetMonthByOrdinal(8);
            Assert.Equal("August", month);

            month = calendar.GetMonthByOrdinal(9);
            Assert.Equal("September", month);

            month = calendar.GetMonthByOrdinal(10);
            Assert.Equal("October", month);

            month = calendar.GetMonthByOrdinal(11);
            Assert.Equal("November", month);

            month = calendar.GetMonthByOrdinal(12);
            Assert.Equal("December", month);

        }

        [Fact]
        public void TestGuards_GetMonthStringByOrdinal()
        {
            Calendar calendar = new Calendar();
            var month = calendar.GetMonthByOrdinal(0);
            Assert.Equal(string.Empty, month);

            month = calendar.GetMonthByOrdinal(13);
            Assert.Equal(string.Empty, month);
        }

        [Fact]
        public void TestGetOrdinalByMonthString()
        {
            Calendar calendar = new Calendar();
            var ordinal = calendar.GetOrdinalByMonthString("January");
            Assert.Equal(1, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("February");
            Assert.Equal(2, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("March");
            Assert.Equal(3, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("April");
            Assert.Equal(4, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("May");
            Assert.Equal(5, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("June");
            Assert.Equal(6, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("July");
            Assert.Equal(7, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("August");
            Assert.Equal(8, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("September");
            Assert.Equal(9, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("October");
            Assert.Equal(10, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("November");
            Assert.Equal(11, ordinal);

            ordinal = calendar.GetOrdinalByMonthString("December");
            Assert.Equal(12, ordinal);
        }

        [Fact]
        public void TestInvalidMonthName()
        {
            Calendar calendar = new Calendar();
            int ordinal = calendar.GetOrdinalByMonthString("Thirteenber");
            Assert.Equal(0, ordinal);
        }

        [Fact]
        public void TestInvalidMonthName_NaughtStrings()
        {
            Calendar calendar = new Calendar();

            foreach (var naughtyString in TheNaughtyStrings.All)
            {
                int ordinal = calendar.GetOrdinalByMonthString(naughtyString);
                Assert.Equal(0, ordinal);
            }
        }

        [Fact]
        public void TestGetLengthOfMonthByString_NoYearValue()
        {
            Calendar calendar = new Calendar();
            var pred = calendar.GetLengthOfMonthByString("September");
            Assert.Equal(30, pred);

            // Cannot Calculate February without a year
            pred = calendar.GetLengthOfMonthByString("February");
            Assert.Equal(0, pred);
        }

        [Fact]
        public void TestGetLengthOfMonthByString_Leap()
        {
            Calendar calendar = new Calendar()
            {
                Year = 2024
            };

            var pred = calendar.GetLengthOfMonthByString("September");
            Assert.Equal(30, pred);

            pred = calendar.GetLengthOfMonthByString("February");
            Assert.Equal(29, pred);
        }

        [Fact]
        public void TestGetLengthOfMonthByString_NonLeap()
        {
            Calendar calendar = new Calendar()
            {
                Year = 2025
            };

            var pred = calendar.GetLengthOfMonthByString("September");
            Assert.Equal(30, pred);

            pred = calendar.GetLengthOfMonthByString("February");
            Assert.Equal(28, pred);
        }

        [Fact]
        public void TestIsLeap()
        {
            Calendar calendar = new Calendar()
            {
                Year = 2024
            };

            bool val = calendar.GetIsLeapYear();
            Assert.True(val);
        }
    }
}