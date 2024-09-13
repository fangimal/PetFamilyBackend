using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Dtos;

namespace PetFamily.API.Controllers;

public class PetsController : ApplicationController
{
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        List<PetDto> petDtos =
        [
            new(
                Guid.NewGuid(),
                "Кот",
                "Описание",
                "Город",
                "Улица",
                "Строение",
                "Номер квартиры", 
                "Номер телефона",
                DateTimeOffset.UtcNow,
                []
                ),
            new(
                Guid.NewGuid(),
                "Кот",
                "Описание",
                "Город",
                "Улица",
                "Строение",
                "Номер квартиры", 
                "Номер телефона",
                DateTimeOffset.UtcNow,
                []
            ),
            new(
                Guid.NewGuid(),
                "Кот",
                "Описание",
                "Город",
                "Улица",
                "Строение",
                "Номер квартиры", 
                "Номер телефона",
                DateTimeOffset.UtcNow,
                []
            ),
            new(
                Guid.NewGuid(),
                "Кот",
                "Описание",
                "Город",
                "Улица",
                "Строение",
                "Номер квартиры", 
                "Номер телефона",
                DateTimeOffset.UtcNow,
                []
            ),
            new(
                Guid.NewGuid(),
                "Кот",
                "Описание",
                "Город",
                "Улица",
                "Строение",
                "Номер квартиры", 
                "Номер телефона",
                DateTimeOffset.UtcNow,
                []
            )
        ];
        return Ok(petDtos);
    }
}