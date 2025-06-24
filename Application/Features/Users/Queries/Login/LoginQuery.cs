using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Queries.Login
{
    public record LoginQuery(

        string Email,
        string Password) : IRequest<LoginResponseDto>;



}
