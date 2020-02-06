namespace WebAPI.Models
{
    public class NosmallItemModel
    {
        public long ProductId { get; set; }

        public short VNum { get; set; }

        public int Amount { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }

        public byte Upgrade { get; set; }

        public byte Rare { get; set; }

        public int Number_p { get; set; }

        public int CategoriesId { get; set; }

        public int SecondCategoriesId { get; set; }

        public bool ChooseAmount { get; set; }

        public int Level { get; set; }
    }
}
