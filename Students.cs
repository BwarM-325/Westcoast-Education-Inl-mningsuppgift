using System.Globalization;

namespace WestCoastEdu;

public class Students(string firstName, string lastName, string identity, string number, string homeAdress, string city, string postAdress)
{

    
    public override string ToString()
    {
        return $"Student: {lastName}, {firstName}. \nContacts: {number}. \nAdress: {homeAdress}, {postAdress}, {city}. \nSocial Security Number: {identity}";
    }



}