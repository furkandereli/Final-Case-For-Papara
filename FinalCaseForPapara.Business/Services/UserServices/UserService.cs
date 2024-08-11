using AutoMapper;
using FinalCaseForPapara.Business.Response;
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

        public async Task<ApiResponse<string>> AddAdminUserAsync(RegisterDto registerDto)
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
                return new ApiResponse<string>($"Admin user creation failed: {errors}", false);
            }

            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Admin user created successfully !", true);
        }

        public async Task<ApiResponse<string>> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            
            if(user != null)
            {
                await _unitOfWork.UserRepository.DeleteAsync(user);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<string>("User deleted successfully !", true);
            }

            return new ApiResponse<string>("User not found !", false);
        }

        public async Task<ApiResponse<List<UserDto>>> GetAllUserAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var results = _mapper.Map<List<UserDto>>(users);

            foreach(var result in results)
            {
                var user = await _userManager.FindByIdAsync(Convert.ToString(result.Id));
                if(user != null )
                    result.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            }

            return new ApiResponse<List<UserDto>>(results, "Users displayed successfully !");
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if(user ==  null)
                return new ApiResponse<UserDto>("User not found.", false);
                
            var result = _mapper.Map<UserDto>(user);
            result.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            return new ApiResponse<UserDto>(result, "User displayed successfully !");
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(loginDto.Email);

            if (user != null && await _unitOfWork.UserRepository.CheckPasswordAsync(user, loginDto.Password))
                return await _jwtService.GenerateJwtToken(user);

            throw new Exception("Invalid credentials");
        }

        public async Task<ApiResponse<string>> RegisterAsync(RegisterDto registerDto)
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
                return new ApiResponse<string>($"User registration failed: {errors}", false);
            }
            
            await _userManager.AddToRoleAsync(user, "User");
            await _unitOfWork.CompleteAsync();

            return new ApiResponse<string>("Registration successfully !", true);
        }

        public async Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(updateUserDto.Id);
            
            if(user != null)
            {
                _mapper.Map(updateUserDto, user);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<string>("User updated successfully !", true);
            }

            return new ApiResponse<string>("User not found !", false);
        }
    }
}
