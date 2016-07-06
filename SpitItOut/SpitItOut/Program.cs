using System;
using System.IO;

namespace SpitItOut
{
    class Program
    {
        static void Main(string[] args)
        {
            var birth = new DateTime(1974, 9, 2);
            var herBirth = new DateTime(1976, 2, 26);
            var startDate = new DateTime(2015, 8, 27);
            const double period = 1.0;

            using (var sw = new StreamWriter("out.txt"))
            {
                var currentDate = startDate;
                var currentDay = 0.0;
                var periodDate = currentDate;
                var periodDay = 0.0;
                var header = string.Format("{0,10}  {1,8}  {2,6}  {3,6}  {4,8}", "Date", "Days", "JL", "LS", "% Older");
                sw.WriteLine(header);
                sw.WriteLine("-".PadRight(header.Length, '-'));
                while (currentDate.Year < 2020)
                {
                    var dsb = currentDate.Subtract(birth).TotalDays;
                    var dshb = currentDate.Subtract(herBirth).TotalDays;
                    var dsm = currentDate.Subtract(startDate).TotalDays;
                    var poflife = dsm/dsb;
                    var pofhlife = dsm/dshb;
                    var daysOlder = dsb - dshb;
                    var polder = daysOlder/dsb;

                    
                    if (currentDate.Date == DateTime.Today.Date)
                    {
                        //
                        // {0}date, {1}relationship days, {2}your days, {3}percent of yours, {4}her days, {5}percent of hers 
                        //
                        Console.WriteLine(header);
                        Console.WriteLine("-".PadRight(header.Length, '-'));
                        Console.WriteLine("{0,10}  {1,8}  {2,6:P}  {3,6:P}  {4,8:P}", currentDate.ToShortDateString(), currentDay, poflife, pofhlife, polder);
                    }
                    //
                    // file out
                    //
                    if (currentDate.Equals(periodDate))
                    {
                        sw.WriteLine("{0,10}  {1,8}  {2,6:P}  {3,6:P}  {4,8:P}", currentDate.ToShortDateString(), currentDay, poflife, pofhlife, polder);
                        periodDate = periodDate.AddDays(period);
                        periodDay += period;
                    }

                    currentDate = currentDate.AddDays(1);
                    currentDay += 1.0;
                }
            }
            Console.Read();

        }
    }
}
