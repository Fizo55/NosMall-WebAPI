namespace WebAPI.Models
{
    public class AccountModel
    {
        public long AccountId { get; set; }

        public byte Authority { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long ReferrerId { get; set; }

        public string RegistrationIP { get; set; }

        public string VerificationToken { get; set; }

        public bool DailyRewardSent { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int Coins { get; set; }

        public string Image { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public int Response { get; set; }
    }
}
