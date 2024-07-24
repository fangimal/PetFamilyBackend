namespace PetFamily.Domain.Common;

public static class StringExtension
{
    public static bool IsEmpty(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}