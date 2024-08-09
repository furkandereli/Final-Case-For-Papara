using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Repositories.CouponRepositories
{
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(PaparaDbContext context) : base(context) { }

        public async Task<Coupon?> GetCouponByCodeAsync(string code)
        {
            return await _context.Set<Coupon>().FirstOrDefaultAsync(c => c.Code == code);
        }
    }
}
