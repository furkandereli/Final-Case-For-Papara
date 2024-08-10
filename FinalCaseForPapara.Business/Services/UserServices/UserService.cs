using AutoMapper;
using FinalCaseForPapara.Business.Services.JwtServices;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.UserDTOs;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalCaseForPapara.Business.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork,
            IJwtService jwtService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> AddAdminUserAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PointsBalance = 0
            };

            var result = await _unitOfWork.UserRepository.AddAdminUserAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Admin user creation failed: {errors}");
            }

            await _unitOfWork.CompleteAsync();

            return "Admin user created successfully!";
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            
            if(user != null)
            {
                await _unitOfWork.UserRepository.DeleteAsync(user);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<List<UserDto>> GetAllUserAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var results = _mapper.Map<List<UserDto>>(users);

            foreach(var result in results)
            {
                var user = await _userManager.FindByIdAsync(Convert.ToString(result.Id));
                if(user != null )
                    result.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            }

            return results;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserDto>(user);

            if(user !=  null)
                result.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            
            return result;
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
                PointsBalance = 0
            };

            var result = await _unitOfWork.UserRepository.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed : {errors}");
            }
            
            await _userManager.AddToRoleAsync(user, "User");
            await _unitOfWork.CompleteAsync();

            return "Registration successfully !";
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(updateUserDto.Id);
            
            if(user != null)
            {
                _mapper.Map(updateUserDto, user);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
