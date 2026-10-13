using System.Globalization;
using System.Text.Json.Serialization;

namespace WestCoastEdu;

public class Students
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Identity {get; set;}
    public string Number {get; set;}
    public string HomeAdress {get; set;}
    public string City {get; set;}
    public string PostAdress {get; set;}

    [JsonConstructor]
    public Students()
    {
        
    }

    public Students(string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress)
    {
        FirstName = firstName;
        LastName = lastName;
        Identity = identity;
        Number = number;
        HomeAdress = homeAdress;
        City = city;
        PostAdress = postAdress;
    }
    
    public override string ToString()
    {
        return $"Student: {LastName}, {FirstName}. \nContacts: {Number}. \nAdress: {HomeAdress}, {PostAdress}, {City}. \nSocial Security Number: {Identity}";
    }



}