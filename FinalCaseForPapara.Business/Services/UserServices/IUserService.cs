using FinalCaseForPapara.Dto.AuthDTOs;

namespace FinalCaseForPapara.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
