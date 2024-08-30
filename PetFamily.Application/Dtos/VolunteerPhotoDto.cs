namespace PetFamily.Application.Dtos;

public class VolunteerPhotoDto
{
    public Guid Id { get; init; }
    public string Path { get; init; } = string.Empty;
    public bool IsMain { get; init; }
}