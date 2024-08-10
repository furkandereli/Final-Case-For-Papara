using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Repositories.OrderRepositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(PaparaDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetActiveOrdersAsync(int userId, bool isAdmin)
        {
            IQueryable<Order> query = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);

            if(!isAdmin)
                query = query.Where(o => o.UserId == userId && o.IsActive);

            else
                query = query.Where(o => o.IsActive);

            return await query.ToListAsync();
        }

        public async Task<List<Order>> GetPastOrdersAsync(int userId, bool isAdmin)
        {
            IQueryable<Order> query = _context.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);

            if (!isAdmin)
                query = query.Where(o => o.UserId == userId && !o.IsActive && o.OrderDate < DateTime.Now);
            else
                query = query.Where(o => !o.IsActive && o.OrderDate < DateTime.Now);

            return await query.ToListAsync();
        }
    }
}
