using Microsoft.AspNetCore.Mvc;
using PMS.Application.DTOs;
using PMS.Application.UseCases.RegisterPatient;

namespace PMS.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController : ControllerBase
{
    private readonly RegisterPatientHandler _handler;

    public PatientsController(RegisterPatientHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterPatientRequest request)
    {
        if (request == null)
            return BadRequest("Request body is null");

        await _handler.Handle(request);
        return Ok(new { message = "Patient registered successfully" });

    }

}
