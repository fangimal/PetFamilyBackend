﻿namespace PetFamily.Application.Features.Volunteer.CreatePet;

public record CreatePetRequest(
    Guid VolunteerId,
    string Nickname,
    string Description,
    DateTimeOffset BirthDate,
    string Breed,
    string Color,
    string City,
    string Street,
    string Building,
    string Index,
    string Place,
    bool Castration,
    string PeopleAttitude,
    string AnimalAttitude,
    bool OnlyOneInFamily,
    string Health,
    int Height,
    float Weight,
    string ContactPhoneNumber,
    string VolunteerPhoneNumber,
    bool OnTreatment);