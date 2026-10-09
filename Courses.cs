using System.Globalization;

namespace WestCoastEdu;

public class Courses(string courseid, string title, string length, string date)
{
    public override string ToString()
    {
        return $"Course number: {courseid}. \nTitle: {title}. \n Length: {length}. \nTime: {date}. ";
    }
}