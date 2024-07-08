namespace PetFamily.API.Contracts;

public record CreatePetRequest(
    string Name,
    string Breed,
    float Weight,
    int Height,
    bool Vaccine,
    DateOnly BirthDate,
    string Photo,
    string Description,
    string Adress);