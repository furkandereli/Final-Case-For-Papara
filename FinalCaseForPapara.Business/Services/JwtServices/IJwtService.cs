using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Services.JwtServices
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
