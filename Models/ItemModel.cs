namespace WebAPI.Models
{
    public class ItemModel
    {
        public string MallAuthKey { get; set; }

        public long CharacterId { get; set; }

        public short ItemVNum { get; set; }

        public short Amount { get; set; }

        public byte Rare { get; set; }

        public byte Upgrade { get; set; }

        public byte Level { get; set; }

        public string VerificationToken { get; set; }
    }
}
