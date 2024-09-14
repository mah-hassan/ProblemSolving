
var date1 = "2002-06-16";
var date2 = "2024-09-15";
var days = new Solution().DaysBetweenDates(date1, date2);
Console.WriteLine(days);

public class Solution
{
    public int DaysBetweenDates(string date1, string date2)
    {
        var d1 = DateOnly.Parse(date1);
        var d2 = DateOnly.Parse(date2);

        // Calculate total days from year 0 for both dates
        var totalDays1 = TotalDaysSince1971Year(d1);
        var totalDays2 = TotalDaysSince1971Year(d2);

        return Math.Abs(totalDays1 - totalDays2);
    }

    public int TotalDaysSince1971Year(DateOnly d)
    {
        int totalDays = 0;

        // Add days for the full years before the given year
        for (int i = 1971; i < d.Year; i++)
        {
            totalDays += IsLeapYear(i) ? 366 : 365;
        }

        // Add days for the current year up to the given date
        totalDays += CalculateDaysInYear(d);

        return totalDays;
    }

    // Calculate the number of days for the given year up to the specific date
    public int CalculateDaysInYear(DateOnly d)
    {
        int[] daysInMonthNonLeap =
        {
            31, 28, 31, 30, 31, 30,
            31, 31, 30, 31, 30, 31
        };
        int[] daysInMonthLeap =
        {
            31, 29, 31, 30, 31, 30,
            31, 31, 30, 31, 30, 31
        };

        int days = 0;
        var isLeap = IsLeapYear(d.Year);

        // Add days for the completed months
        for (int i = 0; i < d.Month - 1; i++)
        {
            days += isLeap ? daysInMonthLeap[i] : daysInMonthNonLeap[i];
        }

        // Add the days of the current month
        days += d.Day;

        return days;
    }

    // Check if the year is a leap year
    public bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
    }
}