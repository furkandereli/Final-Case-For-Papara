using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.Repositories.OrderRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetActiveOrdersAsync(int userId, bool isAdmin);
        Task<List<Order>> GetPastOrdersAsync(int userId, bool isAdmin);
    }
}
