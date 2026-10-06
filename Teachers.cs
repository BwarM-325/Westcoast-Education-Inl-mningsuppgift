using System.Globalization;

namespace WestCoastEdu;

public class Teachers(string firstName, string lastName, int identity, int number, string homeAdress, string city, int postAdress, string subject, string course)
{
    public override string ToString()
    {
        return $"Teacher: {lastName}, {firstName}. Contacts: {number}. Adress: {homeAdress}, {postAdress}, {city}. Social Security Number: {identity}. Subject(s): {subject}. Course: {course}";
    }
}