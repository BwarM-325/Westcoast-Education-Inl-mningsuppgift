using System.Globalization;

namespace WestCoastEdu;

public class Teachers(string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress, string subject, string course)
{
    public override string ToString()
    {
        return $"Teacher: {lastName}, {firstName}. \nContacts: {number}. \nAdress: {homeAdress}, {postAdress}, {city}. \nSocial Security Number: {identity}. \nSubject(s): {subject}. \nCourse in charge of: {course}";
    }
}