using System.Globalization;

namespace WestCoastEdu;

public class Students(string firstName, string lastName, int identity, int number, string homeAdress, string city, int postAdress)
{

    
    public override string ToString()
    {
        return $"Student: {lastName}, {firstName}. Contacts: {number}. Adress: {homeAdress}, {postAdress}, {city}. Social Security Number: {identity}";
    }



}