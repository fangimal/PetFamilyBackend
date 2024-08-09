﻿using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Common;
using PetFamily.Domain.Entities;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Application.Features.Volunteer.CreateVolunteer;

public class CreateVolunteerService
{
    private readonly IVolunteerRepository _volunteerRepository;

    public CreateVolunteerService(IVolunteerRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
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
        
        await _volunteerRepository.Add(volunteer, ct);
        return await _volunteerRepository.Save(volunteer, ct);
    }
}