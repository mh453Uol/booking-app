using System;

namespace BarberBooking.Utilities
{
    public static class DateTimeUtil
    {
        public static DateTime RoundUp(this DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
    }

}