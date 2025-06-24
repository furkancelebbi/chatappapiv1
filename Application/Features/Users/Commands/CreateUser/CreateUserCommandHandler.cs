using Application.DTOs;
using Application.Security;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                throw new Exception("Bu email adresi zaten kullanılıyor.");
            }


            PasswordHasher.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


            var user = new AppUser
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };


            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();


            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

    }

}
