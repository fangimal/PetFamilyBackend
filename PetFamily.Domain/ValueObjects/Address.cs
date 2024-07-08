namespace PetFamily.Domain.ValueObjects
{
    public record Address
    {
        public Address(string city, string street, string building, string index)
        {
            City = city;
            Street = street;
            Building = building;
            Index = index;
        }

        public string City { get; }
        public string Street { get; }
        public string Building { get; }
        public string Index { get; }
    }
}