using System.Text.Json.Serialization;

namespace Api;


public record SickReport(
    string FirstName,
    string LastName,
    DateTime BirthDate,
    DateTime SickSince,
    string CitizenServiceNumber,
    Gender Gender);

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male,
    Female
}