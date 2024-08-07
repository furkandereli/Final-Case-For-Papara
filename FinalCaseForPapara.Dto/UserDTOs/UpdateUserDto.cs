namespace FinalCaseForPapara.Dto.UserDTOs
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal PointsBalance { get; set; }
    }
}
