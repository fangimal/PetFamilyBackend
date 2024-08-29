namespace PetFamily.Application.Features.Volunteer.DeletePhoto
{
    public record DeleteVolunteerPhotoRequest(Guid VolunteerId, string Path);
}