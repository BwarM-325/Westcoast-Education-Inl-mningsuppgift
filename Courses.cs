using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace WestCoastEdu;

public class Courses(string courseid, string title, string length, string date)
{
    public override string ToString()
    {
        DateTime dateStart;
        if (string.IsNullOrEmpty(date) || !DateTime.TryParse(date, out dateStart))
        {
            dateStart = DateTime.Now;
        }

        int.TryParse(length, out int lengthWeeks);

        DateTime dateEnd = dateStart.AddDays(lengthWeeks * 7);

        string startDate = dateStart.ToString("yy/MM/dd");
        string endDate = dateEnd.ToString("yy/MM/dd");

        return $"Course number: {courseid}. \nTitle: {title}. \n Length: {length}. \nTime: {startDate} - {endDate}. ";
    }
}