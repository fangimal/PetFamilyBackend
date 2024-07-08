using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFamily.API.Contracts;
using PetFamily.Infrastructure;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly PetFamilyDbContext _dbContext;
    
    public PetController(PetFamilyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePetRequest request, CancellationToken ct)
    {

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pets = await _dbContext.Pets.ToListAsync();
        return Ok(pets);
    }
}