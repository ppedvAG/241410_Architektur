using System.Data;

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }

        public bool IsWeekend(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Sunday ||
                   dt.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
