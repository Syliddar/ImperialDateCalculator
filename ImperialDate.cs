using System;

namespace ImperialDateConversion
{
    public static class ImperialDate
    {
        /*
         * Props to Makr for the Makr Constant.
         * https://www.dakkadakka.com/dakkaforum/posts/list/265553.page         
         */
        static double makrConstant = 0.11407955263862231501532129004257;
        public static string ToImperialDate(this DateTime date, CheckNumber checkNumber = 0)
        {
            string yearFraction = GetYearFraction(date);
            string yearInMillenium = date.Year.ToString().Substring(1);
            string milleniumNumber = GetMillenium(date);
            return $"{(int)checkNumber}{yearFraction}{yearInMillenium}.M{milleniumNumber}";
        }
        private static string GetYearFraction(DateTime sourceDate)
        {
            /* 
             * The Imperium of Man in the Warhammer 40k Universe does not use time/day/month information as we do today. 
             * The "Imperial Date" of an event is determined by splitting a standard earth year into 1,000 equal parts.
             */
            int julianDate = sourceDate.DayOfYear;
            int determinedHour = (julianDate * 24) + sourceDate.Hour;
            double imperialFraction = determinedHour * makrConstant;
            return Math.Round(imperialFraction, 0).ToString();
        }
        private static string GetMillenium(DateTime sourceDate)
        {
            int year = sourceDate.Year / 1000;
            return (year + 1).ToString().PadLeft(2, '0');
        }
    }

    public enum CheckNumber
    {
        /*
         * The "Check Number" of a date is a measurement of how accurate to Earth time the event took place in.
         * The Imperium of Man uses faster-than-light psychic communication across the warp, and all dates are syncronized to Earth time.
         *      0 - An event that took place *on* Earth
         *      1 - Somewhere in the Sol system
         *      2 - In direct communication with Earth
         *      3 - In direct communication with someone that is also in direct communication with Earth
         * ...and so on and so forth. Each additional step away from Earth is an additional step in the Check Number. 
         * The numbers 6-8 are used when not in warp communication with anyone, but when warp communication with a class 0-5 was made within the indicated timeframe.
         */
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
