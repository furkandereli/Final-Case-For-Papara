using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.UserDTOs;

namespace FinalCaseForPapara.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<ApiResponse<List<UserDto>>> GetAllUserAsync();
        Task<ApiResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ApiResponse<string>> DeleteUserAsync(int id);
        Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDto updateUserDto);

        Task<ApiResponse<string>> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<ApiResponse<string>> AddAdminUserAsync(RegisterDto registerDto);
    }
}
