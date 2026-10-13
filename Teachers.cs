using System.Globalization;
using System.Text.Json.Serialization;

namespace WestCoastEdu;

public class Teachers
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
    
    
    [JsonConstructor]
    public Teachers() {
        
    }

    public Teachers(string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress, string subject, string course)
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
    }
    public override string ToString()
    {
        return $"Teacher: {LastName}, {FirstName}. \nContacts: {Number}. \nAdress: {HomeAdress}, {PostAdress}, {City}. \nSocial Security Number: {Identity}. \nSubject(s): {Subject}. \nCourse in charge of: {Course}";
    }
}