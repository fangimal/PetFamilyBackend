namespace PetFamily.Domain.ValueObjects;

public static class StringExtension
{
    public static bool IsEmpty(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}