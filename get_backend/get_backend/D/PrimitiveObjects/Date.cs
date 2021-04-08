
/*
 * Date is used to store time related data
 */

using System;
using get_backend.D.AbstractObjects;

namespace get_backend.D.PrimitiveObjects
{
    internal class Date : AMuteable<DateTime>
    {
        private Date(int Y) => Year = Y;
        private Date(int Y, int M) : this(Y) => Month = M;
        private Date(int Y, int M, int D) : this(Y, M) => Day = D;

        internal Date() => Year = Month = Day = byte.MinValue;
        internal Date(Date d) : this(d.Year, d.Month, d.Day) { }
        internal Date(DateTime d) : this(d.Year, d.Month, d.Day) { }

        internal int Year { get; set; }
        internal int Month { get; set; }
        internal int Day { get; set; }

        internal override DateTime Clone => new DateTime(Year, Month, Day);
        internal override void Change(DateTime a)
        {
            Year = a.Year;
            Month = a.Month;
            Day = a.Day;
        }

        internal string ToString(string DDMMYYY) => Clone.ToString(DDMMYYY);
    }
}
