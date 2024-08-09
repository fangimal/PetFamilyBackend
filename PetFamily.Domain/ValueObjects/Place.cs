﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;

namespace PetFamily.Domain.ValueObjects;

public record Place
{
    public static readonly Place InHospital = new(nameof(InHospital).ToUpper());
    public static readonly Place AtHome = new(nameof(AtHome).ToUpper());

    private static readonly Place[] _all = [InHospital, AtHome];

    public string Value { get; }

    private Place(string value)
    {
        Value = value;
    }

    public static Result<Place, Error> Create(string input)
    {
        if (input.IsEmpty() || input.Length > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength();

        var place = input.Trim().ToUpper();

        if (_all.Any(p => p.Value == place) == false)
        {
            return Errors.General.ValueIsInvalid(nameof(place));
        }

        return new Place(place);
    }
}