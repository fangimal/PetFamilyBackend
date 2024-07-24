using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.ValueObjects
{
    public record PhoneNumber
    {
        private const string russionPhoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
        public string Number { get; }
        
        private PhoneNumber(string number)
        {
            Number = number;
        }

        public static Result<PhoneNumber, Error> Create(string input)
        {
            input = input.Trim();
            
            if (input.Length < 1)
                return Errors.General.InvalidLength("phone number");

            if (Regex.IsMatch(input, russionPhoneRegex) == false)
                return Errors.General.ValueIsInvalid();
            
            return new PhoneNumber(input);
        }
    }
}