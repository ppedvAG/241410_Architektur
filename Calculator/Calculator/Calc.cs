using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Calculator.Tests")]

namespace Calculator
{
    public class Calc
    {
        internal int Sum(int a, int b)
        {
            return checked(a + b);
        }

        public bool IsWeekend(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Sunday ||
                    dt.DayOfWeek == DayOfWeek.Saturday;
        }

        public bool IsFeiertag(DateTime dt)
        {
            if (dt.Day == 24 && dt.Month == 12)
                return true;

            if (dt.Day == 25 && dt.Month == 12)
                return true;

            if (dt.Day == 26 && dt.Month == 12)
                return true;

            return false;
        }

        public bool IsWeekendOrFeiertagToday()
        {
            var now = DateTime.Now;

            return IsWeekend(now) || IsFeiertag(now);
        }
    }
}
