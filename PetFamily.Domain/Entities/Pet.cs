﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities;

public class Pet
{
    private Pet() { }
    
    private Pet(
        string nickname,
        string description,
        // DateTimeOffset birthDate,
        string breed,
        string color,
        Address address,
        Place place,
        bool castration,
        string peopleAttitude,
        string animalAttitude,
        bool onlyOneInFamily,
        string health,
        int? height,
        Weight weight,
        bool vaccine,
        PhoneNumber contactPhoneNumber,
        PhoneNumber volunteerPhoneNumber,
        bool onTreatment,
        DateTimeOffset createdDate
)
    {
        Nickname = nickname;
        Description = description;
        // BirthDate = birthDate;
        Breed = breed;
        Color = color;
        Address = address;
        Place = place;
        Castration = castration;
        PeopleAttitude = peopleAttitude;
        AnimalAttitude = animalAttitude;
        OnlyOneInFamily = onlyOneInFamily;
        Health = health;
        Height = height;
        Weight = weight;
        Vaccine = vaccine;
        ContactPhoneNumber = contactPhoneNumber;
        VolunteerPhoneNumber = volunteerPhoneNumber;
        OnTreatment = onTreatment;
        CreatedDate = createdDate;
    }

    public Guid Id { get; private set; }
    public string Nickname { get; private set; }
    public string Description { get; private set; }
    public string PeopleAttitude { get; private set; }
    public string AnimalAttitude { get; private set; }
    public string Breed { get; private set; }
    public string Color { get; private set; }
    public string Health { get; private set; }
    public Address Address { get; private set; }
    public Place Place { get; private set; }
    public Weight Weight { get; private set; }
    public PhoneNumber ContactPhoneNumber { get; private set; }
    public PhoneNumber VolunteerPhoneNumber { get; private set; }
    public bool Castration { get; private set; }
    public bool OnlyOneInFamily { get; private set; }
    public bool Vaccine { get; private set; }
    public bool OnTreatment { get; private set; }
    public int? Height { get; private set; }
    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }
    public IReadOnlyList<Vaccination> Vaccinations => _vaccinations;
    public List<Vaccination> _vaccinations = [];
    public IReadOnlyList<Photo> Photos => _photos;
    private readonly List<Photo> _photos = [];

    public static Result<Pet, Error> Create(
        string nickname,
        string description,
        // DateTimeOffset birthDate,
        string breed,
        string color,
        Address address,
        Place place,
        bool castration,
        string peopleAttitude,
        string animalAttitude,
        bool onlyOneInFamily,
        string health,
        int? height,
        Weight weight,
        bool vaccine,   
        PhoneNumber contactPhoneNumber,
        PhoneNumber volunteerPhoneNumber,
        bool onTreatment)
    {
        breed = breed.Trim();
        color = color.Trim();
        peopleAttitude = peopleAttitude.Trim();
        animalAttitude = animalAttitude.Trim();

        if (nickname.IsEmpty() || nickname.Length > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (description.IsEmpty() || description.Length > Constraints.LONG_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        // if (birthDate > DateTimeOffset.UtcNow)
        //     return Errors.General.ValueIsInvalid(nameof(birthDate.Year));

        if (breed.IsEmpty() || breed.Length > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (color.IsEmpty() || color.Length > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (peopleAttitude.IsEmpty() || peopleAttitude.Length > Constraints.LONG_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (animalAttitude.IsEmpty() || animalAttitude.Length > Constraints.LONG_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (health.IsEmpty() || health.Length > Constraints.LONG_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        if (height <= 0)
            return Errors.General.ValueIsInvalid(nameof(height));

        // var photosList = photos.ToList();
        // if (photosList.Count is > PHOTO_COUNT_LIMIT or < PHOTO_COUNT_MIN)
        //     return Errors.Pets.PhotoCountLimit();

        return new Pet(
            nickname,
            description,
            // birthDate,
            breed,
            color,
            address,
            place,
            castration,
            peopleAttitude,
            animalAttitude,
            onlyOneInFamily,
            health,
            height,
            weight,
            vaccine,
            contactPhoneNumber,
            volunteerPhoneNumber,
            onTreatment,
            DateTimeOffset.UtcNow);
    }
}