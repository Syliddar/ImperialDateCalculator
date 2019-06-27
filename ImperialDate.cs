using System;

namespace ImperialDateConversion
{
    public static class ImperialDate
    {
        public static string ToImperialDate(DateTime date, CheckNumber checkNumber = 0)
        {

            return (int) checkNumber + GetYearFraction(date) + GetYear(date) + ".M" + GetMillenium(date).ToString().PadLeft(2,'0');
        }

        private static string GetYearFraction(DateTime sourceDate)
        {
            DateTime yearStart = new DateTime(sourceDate.Year, 1, 1, 0, 0, 0);
            DateTime yearEnd = new DateTime(sourceDate.Year, 12, 31, 23, 59, 59);
            TimeSpan progress = sourceDate - yearStart;
            var totalFraction = yearEnd.Ticks / progress.Ticks;            
            return totalFraction.ToString().Remove(3);
        }

        private static string GetYear(DateTime sourceDate)
        {
            var year = sourceDate.Year.ToString();
            return year.Substring(1);
        }

        private static int GetMillenium(DateTime sourceDate)
        {
            var year = sourceDate.Year / 1000;
            return year + 1;
        }
    }

    public enum CheckNumber
    {
        Terra = 0,
        SolSystem = 1,
        Direct = 2,
        Indirect = 3,
        Corroborated = 4,
        SubCorroborated = 5,
        NonReferenced1 = 6,
        NonReferenced10 = 7,
        Nonreferenced10Plus = 8,
        Approximation = 9
    }
}
