﻿using Microsoft.AspNetCore.Identity;

namespace FinalCaseForPapara.Entity.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PointsBalance { get; set; }
    }
}
