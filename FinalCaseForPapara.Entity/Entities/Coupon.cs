﻿using System.ComponentModel.DataAnnotations;

namespace FinalCaseForPapara.Entity.Entities
{
    public class Coupon
    {
        public int Id { get; set; }

        [StringLength(10, ErrorMessage = "Coupon code must be 10 characters or less !")]
        public string Code { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int? UsedByUserId { get; set; }
    }
}
