namespace Hangfire_EmailNotification.Controllers;

using Hangfire_EmailNotification.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserRegistrationController : ControllerBase
{
    private readonly IUserRegistrationService _userService;

    public UserRegistrationController(IUserRegistrationService userRegistrationService)
    {
        _userService = userRegistrationService;
    }

    [HttpPost("User Registration")]
    public async Task<IActionResult> UserRegistration( UserRegistrationViewModel userRegistrationViewModel)
    {
        if (userRegistrationViewModel == null)
        {
            return BadRequest("User  registration data is required.");
        }

        await _userService.AddUser (userRegistrationViewModel);
        return Ok("User  registered successfully.");
    }
}