namespace WebAPI.Models
{
    public class LaunchEventModel
    {
        public OpenNos.Domain.EventType EventName { get; set; }

        public string VerificationToken { get; set; }
    }
}