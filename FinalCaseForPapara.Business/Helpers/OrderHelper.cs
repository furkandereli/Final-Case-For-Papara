using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.OrderDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Helpers
{
    public class OrderHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> ValidateAndGetProductsAsync(List<OrderItemDto> items)
        {
            var products = new List<Product>();

            foreach (var item in items)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID {item.ProductId} is invalid or does not exist.");
                }

                if (!product.IsActive || product.Stock == false)
                {
                    throw new InvalidOperationException($"Product '{product.Name}' is not available for purchase.");
                }

                products.Add(product);
            }

            return products;
        }

        public async Task<Coupon?> ValidateAndApplyCouponAsync(string? couponCode, string userId)
        {
            if (string.IsNullOrWhiteSpace(couponCode))
            {
                return null;
            }

            var coupon = await _unitOfWork.CouponRepository.GetCouponByCodeAsync(couponCode);
            if (coupon == null || !coupon.IsActive || coupon.ExpiryDate < DateTime.UtcNow || coupon.UsedByUserId.HasValue)
            {
                throw new InvalidOperationException("Coupon is not valid");
            }

            coupon.IsActive = false;
            coupon.UsedByUserId = int.Parse(userId);
            await _unitOfWork.CouponRepository.UpdateAsync(coupon);

            return coupon;
        }

        public decimal CalculateOrderAmount(List<Product> products, List<OrderItemDto> items, decimal pointsBalance, Coupon? coupon)
        {
            var totalAmount = items.Sum(item =>
            {
                var product = products.First(p => p.Id == item.ProductId);
                return product.Price * item.Quantity;
            });

            if (coupon != null)
            {
                totalAmount -= coupon.DiscountAmount;
            }

            totalAmount -= pointsBalance;

            return totalAmount < 0 ? 0 : totalAmount;
        }

        public async Task<Order> CreateOrderAsync(int userId,decimal totalAmount, decimal pointsUsed, decimal? couponAmount, string? couponCode, List<OrderItemDto> items, List<Product> products)
        {
            var order = new Order
            {
                UserId = userId,
                OrderNumber = await GenerateOrderNumber(),
                TotalAmount = totalAmount,
                PointsUsed = pointsUsed > 0 ? pointsUsed : null,
                CouponAmount = couponAmount,
                CouponCode = couponCode,
                OrderDate = DateTime.UtcNow,
                IsActive = true,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in items)
            {
                var product = products.First(p => p.Id == item.ProductId);
                var pointsEarned = CalculatePointsEarned(product, item.Quantity);

                var orderDetail = new OrderDetail
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    TotalPrice = product.Price * item.Quantity,
                    PointsEarned = pointsEarned,
                };
                order.OrderDetails.Add(orderDetail);
            }
            return order;
        }

        public decimal CalculateTotalPointsEarned(List<Product> products, List<OrderItemDto> items)
        {
            decimal totalPoints = 0;

            foreach (var item in items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product != null)
                {
                    var pointsEarned = CalculatePointsEarned(product, item.Quantity);
                    totalPoints += pointsEarned;
                }
            }

            return totalPoints;
        }

        private decimal CalculatePointsEarned(Product product, int quantity)
        {
            var potentialPointsPerItem = (product.Price * product.PointsPercentage / 100);
            var pointsPerItem = potentialPointsPerItem > product.MaxPoints ? product.MaxPoints : potentialPointsPerItem;
            return pointsPerItem * quantity; 
        }

        private async Task<string> GenerateOrderNumber()
        {
            var random = new Random();
            string orderNumber;

            do
            {
                orderNumber = random.Next(100000000, 999999999).ToString();
            }
            while(await _unitOfWork.OrderRepository.AnyAsync(o => o.OrderNumber == orderNumber));

            return orderNumber;
        }
    }
}
