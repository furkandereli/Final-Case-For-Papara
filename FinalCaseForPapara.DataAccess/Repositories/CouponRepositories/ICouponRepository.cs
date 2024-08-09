using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.Repositories.CouponRepositories
{
    public interface ICouponRepository : IGenericRepository<Coupon>
    {
        Task<Coupon?> GetCouponByCodeAsync(string code);
    }
}
