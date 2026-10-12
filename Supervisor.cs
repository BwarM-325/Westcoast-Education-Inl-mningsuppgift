using System.Globalization;

namespace WestCoastEdu;

public class Supervisors(string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress, string subject, string course, string hiredDate)
{
    public override string ToString()
    {
        DateTime dateStart;
        if (string.IsNullOrEmpty(hiredDate) || !DateTime.TryParse(hiredDate, out dateStart))
        {
            dateStart = DateTime.Now;
        }

        string Date = dateStart.ToString("yy/MM/dd");


        return $"Teacher: {lastName}, {firstName}. \nContacts: {number}. \nAdress: {homeAdress}, {postAdress}, {city}. \nSocial Security Number: {identity}. \nSubject(s): {subject}. \nCourse in charge of: {course}. \nDate hired: {Date} ";
    }
}