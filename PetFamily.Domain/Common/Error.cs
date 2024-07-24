using System.Text.Json;

namespace PetFamily.Domain.Common;

public class Error
{
    public string Code { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Serialize() => JsonSerializer.Serialize(this);

    public static Error? Deserialize(string json) => JsonSerializer.Deserialize<Error>(json)!;
}

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id '{id}'";
            return new Error("record.not.found", $"record not found {forId}");
        }

        public static Error ValueIsRequired(string? name)
        {
            var label = name ?? "Value";
            return new("value.is.invalid", $"{label} is invalid");
        }

        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "Value";
            return new("value.is.invalid", $"{label} is invalid");
        }

        public static Error InvalidLength(string? name = null)
        {
            var label = name == null ? " " : " " + name + " ";
            return new Error("invalid.string.lenght", $"Invalid{label}lenght");
        }
    }

    public static class Place
    {
        public static Error ValueIsInvalid() => new("place.is.invalid", "Place is invalid");
    }
}