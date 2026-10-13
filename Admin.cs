using System.Globalization;
using System.Text.Json.Serialization;

namespace WestCoastEdu;

public class Admins
{
    public string FirstName {get; set;} 
    public string LastName {get; set;}
    public string Identity {get; set;}
    public string Number {get; set;}
    public string HomeAdress {get; set;}
    public string City {get; set;}
    public string PostAdress {get; set;}
    public string Subject {get; set;}
    public string Course {get; set;}
    public string HiredDate {get; set;}

    [JsonConstructor]
    public Admins()
    {
        
    }


    public Admins (string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress, string subject, string course, string hiredDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Identity = identity;
        Number = number;
        HomeAdress = homeAdress;
        City = city;
        PostAdress = postAdress;
        Subject = subject;
        Course = course;
        HiredDate = hiredDate;
    }

    public override string ToString()
    {
        DateTime dateStart;
        if (string.IsNullOrEmpty(HiredDate) || !DateTime.TryParse(HiredDate, out dateStart))
        {
            dateStart = DateTime.Now;
        }

        string Date = dateStart.ToString("yy/MM/dd");


        return $"Administrator: {LastName}, {FirstName}. \nContacts: {Number}. \nAdress: {HomeAdress}, {PostAdress}, {City}. \nSocial Security Number: {Identity}. \nSubject(s): {Subject}. \nCourse in charge of: {Course}. \nDate hired: {Date} ";
    }
}