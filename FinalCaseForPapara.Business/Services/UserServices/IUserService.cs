using FinalCaseForPapara.Dto.UserDTOs;

namespace FinalCaseForPapara.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUserAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);

        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<string> AddAdminUserAsync(RegisterDto registerDto);
    }
}
