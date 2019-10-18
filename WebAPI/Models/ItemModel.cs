namespace WebAPI.Models
{
    public class ItemModel
    {
        public string MallAuthKey { get; set; }

        public long CharacterId { get; set; }

        public short ItemVNum { get; set; }

        public ushort Amount { get; set; }

        public byte Rare { get; set; }

        public byte Upgrade { get; set; }

        public byte Level { get; set; }
    }
}
