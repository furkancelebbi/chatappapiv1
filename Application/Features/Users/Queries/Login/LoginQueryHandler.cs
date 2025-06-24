using Application.DTOs;
using Application.Interfaces;
using Application.Security;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {

        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
        if (user is null)
        {
            throw new Exception("Kullanıcı bulunamadı veya şifre hatalı."); // Güvenlik için genel bir mesaj
        }


        var isPasswordValid = PasswordHasher.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordValid)
        {
            throw new Exception("Kullanıcı bulunamadı veya şifre hatalı.");
        }


        var token = _tokenService.CreateToken(user);


        var userDto = _mapper.Map<UserDto>(user);

        return new LoginResponseDto
        {
            User = userDto,
            Token = token
        };
    }
}