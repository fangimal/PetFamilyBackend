﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;
using PetFamily.Domain.Entities;

namespace PetFamily.Application.Abstractions
{
    public interface IPetsRepository
    {
        Task<Result<Guid, Error>> Add(Pet pet, CancellationToken ct);
    }
}