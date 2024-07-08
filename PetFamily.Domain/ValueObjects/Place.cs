namespace PetFamily.Domain.ValueObjects
{
    public record Place
    {
        public static readonly Place InHospital = new(nameof(InHospital).ToUpper());
        public static readonly Place AtHome = new(nameof(AtHome).ToUpper());

        private static readonly Place[] _all = [InHospital, AtHome];
        public string Value { get; }

        private Place(string value)
        {
            Value = value;
        }

        public static Place Create(string input)
        {
            if (input.IsEmpty())
                throw new ArgumentNullException();

            var place = input.Trim().ToUpper();

            if (_all.Any(p => p.Value == input) == false)
            {
                throw new ArgumentException();
            }

            return new(place);
        }
    }
}