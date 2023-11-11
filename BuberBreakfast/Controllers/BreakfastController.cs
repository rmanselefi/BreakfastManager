using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using BuberBreakfast.ServiceErrors;
namespace BuberBreakfast.Controllers;

[ApiController]
[Route("api/breakfast")]
public class BreakfastController : ControllerBase
{

    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.name,
            request.description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        // save to db
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModificationDate,
            breakfast.Savory,
            breakfast.Sweet
        );

        return Ok(response);
    }

    [HttpGet("/{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> breakfast = _breakfastService.GetBreakfast(id);
        if(breakfast.IsError) return NotFound();
        return Ok(breakfast);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        _breakfastService.Update(breakfast);
        var response = new BreakfastResponse(id,
        request.Name,
        request.Description,
        request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);
        return Ok(response);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _breakfastService.Delete(id);
        return Ok(id);
    }
}
