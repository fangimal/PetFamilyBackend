using PetFamily.Domain.Common;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
    }
}