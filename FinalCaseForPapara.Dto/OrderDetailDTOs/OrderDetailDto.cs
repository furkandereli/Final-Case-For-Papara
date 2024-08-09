﻿namespace FinalCaseForPapara.Dto.OrderDetailDTOs
{
    public class OrderDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PointsEarned { get; set; }
    }
}
