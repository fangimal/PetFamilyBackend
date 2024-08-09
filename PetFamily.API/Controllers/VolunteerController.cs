﻿using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Features.Volunteer.CreatePet;
using PetFamily.Application.Features.Volunteer.CreateVolunteer;

namespace PetFamily.API.Controllers;

[Route("[controller]")]
public class VolunteerController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerService service,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken ct)
    {
        var idResult = await service.Handle(request, ct);
            
        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    } 
    
    [HttpPost("pet")]
    public async Task<IActionResult> Create(
        [FromServices] CreatePetService sercvice,
        [FromBody] CreatePetRequest request,
        CancellationToken ct)
    {
        var idResult = await sercvice.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }
}