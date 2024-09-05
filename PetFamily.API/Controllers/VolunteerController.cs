using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Features.Volunteers.CreatePet;
using PetFamily.Application.Features.Volunteers.CreateVolunteer;
using PetFamily.Application.Features.Volunteers.DeletePhoto;
using PetFamily.Application.Features.Volunteers.UploadPhoto;
using PetFamily.Infrastructure.Queries.Volunteers.GetVolunteerById;
using PetFamily.Infrastructure.Queries.Volunteers.GetVolunteers;

namespace PetFamily.API.Controllers;

public class VolunteerController : ApplicationController
{
    // [HttpGet("do")]
    // public IActionResult Do()
    // {
    //     _logger.LogInformation("Log info");
    //     return Ok();
    // }
    
    [HttpPost]
    //[HasPermission(Permissions.Volunteers.Create)]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken ct)
    {
        var idResult = await handler.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    [HttpPost("pet")]
    //[HasPermission(Permissions.Pets.Create)]
    public async Task<IActionResult> Create(
        [FromServices] CreatePetHandler handler,
        [FromBody] CreatePetRequest request,
        CancellationToken ct)
    {
        var idResult = await handler.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    [HttpGet]
    public async Task<ActionResult<GetVolunteersResponse>> GetVolunteers(
        [FromServices] GetVolunteersQuery query)
    {
        var response = await query.Handle();

        return Ok(response);
    }
    
    [HttpPost("photo")]
    public async Task<IActionResult> UploadPhoto(
        [FromServices] UploadVolunteerPhotoHandler handler,
        [FromForm] UploadVolunteerPhotoRequest request,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet("photo")]
    public async Task<IActionResult> GetPhotos(
        [FromServices] GetVolunteerByIdQuery handler,
        [FromQuery] GetVolunteerPhotoRequest request,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpDelete("photo")]
    public async Task<IActionResult> DeletePhoto(
        [FromServices] DeleteVolunteerPhotoHandler handler,
        [FromQuery] DeleteVolunteerPhotoRequest request,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}