using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;
using PetFamily.Domain.Entities;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Application.Features.Volunteer.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }
    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken ct)
    {
        var socialMedia = request.SocialMedias
            .Select(s =>
            {
                var social = Social.Create(s.Social).Value;
                return new SocialMedia(s.Link, social);
            });
        var volunteer = new Domain.Entities.Volunteer(
            request.Name,
            request.Description,
            request.YearsExperience,
            request.NumberOfPetsFoundHome,
            request.DonationInfo,
            request.FromShelter,
            socialMedia);
        
        await _volunteersRepository.Add(volunteer, ct);
        return await _volunteersRepository.Save(volunteer, ct);
    }
}