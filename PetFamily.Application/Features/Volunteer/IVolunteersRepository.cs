using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;

namespace PetFamily.Application.Features.Volunteer;

public interface IVolunteersRepository
{
    Task Add(Domain.Entities.Volunteer volunteer, CancellationToken ct);
    Task<Result<Domain.Entities.Volunteer, Error>> GetById(Guid id, CancellationToken ct);
    Task<Result<int, Error>> Save(CancellationToken ct);
}