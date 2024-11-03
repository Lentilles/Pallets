namespace Pallets.Models
{
    public class Box
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public decimal Weight { get; set; }
        public DateOnly ShelfLife { get { return ShelfLife; } private set { ShelfLife = value; } }

        public static Box CreateBoxByProductionDate(Size size, DateOnly productionDate)
        {
            return new Box
            {
                Size = size,
                ShelfLife = productionDate.AddDays(100)
            };
        }

        public static Box CreateBoxByShelfLife(Size size, int weight, DateOnly shelfLife)
        {
            return new Box
            {
                Size = size,
                ShelfLife = shelfLife
            };
        }
    }
}