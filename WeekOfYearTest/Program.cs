using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WeekOfYearTest
{
    internal class Program
    {
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private static void Main(string[] args)
        {
            var weeks = new Dictionary<DateTime, int>();
            var lines = File.ReadLines("weeks.txt");
            foreach (var line in lines)
            {
                var splitted = line.Split(':');
                var date = DateTime.ParseExact(splitted[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var resultWeeks = int.Parse(splitted[1]);
                weeks.Add(date, resultWeeks);
            }

            if (weeks.Count > 0)
            {
                Console.WriteLine($"Loaded {weeks.Count} dates");
                var invalid = 0;
                foreach (var key in weeks.Keys)
                {
                    var expected = weeks[key];
                    var current = GetIso8601WeekOfYear(key);
                    if (expected != current)
                    {
                        Console.WriteLine($"Invalid result for {key}. Expected: {expected}, current: {current}");
                        invalid++;
                    }
                }

                Console.WriteLine($"Found {invalid} invalid dates");
                Console.WriteLine("Done");
            }

            Console.ReadKey();
        }
    }
}