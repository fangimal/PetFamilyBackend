using PetFamily.Domain.Common;

namespace PetFamily.Domain.Entities
{
    public class Vaccination : Entity
    {
        private Vaccination() { }
        
        public Vaccination(string name, DateTimeOffset applied)
        {
            Name = name;
            Applied = applied;
        }

        public Guid Id { get; private set;}

        public string Name { get; private set;}
        
        public DateTimeOffset Applied { get; private set;}
    }
}