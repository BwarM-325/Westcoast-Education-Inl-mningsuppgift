using System.Globalization;

namespace StudentBank;

public class Students(string firstName, string lastName, int identity, int number, string homeAdress, string city, int postAdress)
{
    public int id { get; } = identity;
    private int number { get; } = number;
    private string homeAdress { get; } = homeAdress;
    private string city { get; } = city;
    private int postalAdress { get; } = postAdress;
    
    public override string ToString()
    {
        return $"Student: {lastName}, {firstName}";
    }

}