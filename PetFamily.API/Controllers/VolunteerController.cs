﻿using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PetFamily.Application.Features.Volunteer.CreatePet;
using PetFamily.Application.Features.Volunteer.CreateVolunteer;
using PetFamily.Application.Features.Volunteer.DeletePhoto;
using PetFamily.Application.Features.Volunteer.UploadPhoto;
using PetFamily.Infrastructure.Queries.Volunteers.GetPhoto;

namespace PetFamily.API.Controllers;

[Route("[controller]")]
public class VolunteerController : ApplicationController
{
    [HttpPost]
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
    public async Task<IActionResult> Create(
        [FromServices] CreatePetHandler sercvice,
        [FromBody] CreatePetRequest request,
        CancellationToken ct)
    {
        var idResult = await sercvice.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
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

    // [HttpGet("photo")]
    // public async Task<IActionResult> GetPhoto(
    //     string photo,
    //     [FromServices] IMinioClient client)
    // {
    //     var presignedGetObjectArgs = new PresignedGetObjectArgs()
    //         .WithBucket("images")
    //         .WithObject(photo)
    //         .WithExpiry(60 * 60 * 24);
    //
    //     var url = await client.PresignedGetObjectAsync(presignedGetObjectArgs);
    //
    //     return Ok(url);
    // }
    
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