namespace PetFamily.Domain.Entities
{
    public class Vaccination
    {
        public Vaccination() { }
        
        public Vaccination(string name, DateTime applied)
        {
            Name = name;
            Applied = applied;
        }

        public Guid Id { get; private set;}

        public string Name { get; private set;}
        
        public DateTime Applied { get; private set;}
    }
}