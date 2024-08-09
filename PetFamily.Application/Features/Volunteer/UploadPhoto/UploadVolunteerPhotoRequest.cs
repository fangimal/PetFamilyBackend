using Microsoft.AspNetCore.Http;

namespace PetFamily.Application.Features.Volunteer.UploadPhoto;

public record UploadVolunteerPhotoRequest(Guid VolunteerId, IFormFile File);