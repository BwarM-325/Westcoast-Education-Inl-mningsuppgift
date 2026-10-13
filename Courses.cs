using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace WestCoastEdu;

public class Courses
{
    public string Courseid {get; set;} 
    public string Title {get; set;}
    public string Length {get; set;}
    public string Date {get; set;}

    [JsonConstructor]
    public Courses()
    {
        
    }

    public Courses(string courseid, string title, string length, string date)
    {
        Courseid = courseid;
        Title = title;
        Length = length;
        Date = date;
    }
    public override string ToString()
    {
        DateTime dateStart;
        if (string.IsNullOrEmpty(Date) || !DateTime.TryParse(Date, out dateStart))
        {
            dateStart = DateTime.Now;
        }

        int.TryParse(Length, out int lengthWeeks);

        DateTime dateEnd = dateStart.AddDays(lengthWeeks * 7);

        string startDate = dateStart.ToString("yy/MM/dd");
        string endDate = dateEnd.ToString("yy/MM/dd");

        return $"Course number: {Courseid}. \nTitle: {Title}. \n Length: {Length}. \nTime: {startDate} - {endDate}. ";
    }
}