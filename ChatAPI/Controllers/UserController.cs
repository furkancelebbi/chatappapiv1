using Application.DTOs;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChatAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(CreateUserCommand command)
    {
        var userDto = await _mediator.Send(command);
        return Ok(userDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("me")]
    [Authorize]
    public ActionResult<string> GetCurrentUser()
    {

        var userEmail = User.FindFirstValue(ClaimTypes.Email) ?? User.FindFirstValue(JwtRegisteredClaimNames.Email);

        if (string.IsNullOrEmpty(userEmail))
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound("Token içinde kullanıcı kimliğine dair bir bilgi bulunamadı.");
            }
            return Ok($"Merhaba, ID'si {userId} olan kullanıcı! Bu korumalı bir alandır ve sen başarıyla eriştin.");
        }

        return Ok($"Merhaba, {userEmail}! Bu korumalı bir alandır ve sen başarıyla eriştin.");
    }
}