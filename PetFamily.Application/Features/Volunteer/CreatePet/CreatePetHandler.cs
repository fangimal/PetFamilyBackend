using CSharpFunctionalExtensions;
using PetFamily.Application.Features.Pets;
using PetFamily.Domain.Common;
using PetFamily.Domain.Entities;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Application.Features.Volunteer.CreatePet ;

public class CreatePetHandler
{
    private readonly IPetsRepository _petsRepository;
    private readonly IVolunteersRepository _volunteersRepository;

    public CreatePetHandler(IPetsRepository petsRepository, IVolunteersRepository volunteersRepository)
    {
        _petsRepository = petsRepository;
        _volunteersRepository = volunteersRepository;
    }
    public async Task<Result<Guid, Error>> Handle(CreatePetRequest request, CancellationToken ct)
    {
        //получить волонтёра
        var volunteer = await _volunteersRepository.GetById(request.VolunteerId, ct);
        if (volunteer.IsFailure)
        {
            return volunteer.Error;
        }
        //создать питомца
        
        var address = Address.Create(request.City, request.Street, request.Building, request.Index).Value;
        var place = Place.Create(request.Place).Value;
        var weight = Weight.Create(request.Weight).Value;
        var contactPhoneNumber = PhoneNumber.Create(request.ContactPhoneNumber).Value;
        var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber).Value;

        var pet = Pet.Create(
            request.Nickname,
            request.Color,
            address,
            place,
            weight,
            false,
            "fsdfsdf",
            contactPhoneNumber,
            volunteerPhoneNumber,
            true);

        if(pet.IsFailure)
            return pet.Error;
        
        //добавить питомца волонтеру
        volunteer.Value.PublishPet(pet.Value);
        
        return await _volunteersRepository.Save(volunteer.Value, ct);
    }
}