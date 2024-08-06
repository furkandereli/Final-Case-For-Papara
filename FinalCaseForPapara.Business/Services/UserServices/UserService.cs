using FinalCaseForPapara.Business.Services.JwtServices;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.AuthDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(loginDto.Email);

            if(user != null && await _unitOfWork.UserRepository.CheckPasswordAsync(user, loginDto.Password))
                return await _jwtService.GenerateJwtToken(user);

            throw new Exception("Invalid credentials");
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                WalletBalance = 0,
                PointsBalance = 0
            };

            var result = await _unitOfWork.UserRepository.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed : {errors}");
            }

            await _unitOfWork.UserRepository.AddToRoleAsync(user, "User");
            await _unitOfWork.CompleteAsync();

            return "Registration successfully !";
        }
    }
}
