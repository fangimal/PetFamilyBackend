﻿namespace PetFamily.Domain.ValueObjects
{
    public record Weight
    {
        public float Kilograms { get; set; }

        public Weight(float kilograms)
        {
            Kilograms = Convert.ToInt32(kilograms);
        }
    }
}