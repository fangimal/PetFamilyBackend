using FluentValidation;

namespace PetFamily.Application.Pets.GetPets;

public record GetPetsRequest(
    string? Nickname,
    string? Breed,
    string? Color,
    int Page = 1, 
    int Size = 10);
    
public class GetPetsValidator: AbstractValidator<GetPetsRequest>
{
    public GetPetsValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).GreaterThan(0);
    }
}