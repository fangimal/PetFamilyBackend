namespace PetFamily.Domain.Entities
{
    public class Photo
    {
        public Photo() { }
        
        public Photo(string path)
        {
            Path = path;
        }

        public Guid Id { get; private set; }

        public string Path { get; private set; }   
        
        public bool IsMain { get; private set; }
    }
}