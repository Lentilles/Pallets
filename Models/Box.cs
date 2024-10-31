using Pallets.Interfaces;

namespace Pallets.Models
{
    public class Box : IVolumeable
    {
        public Guid Id { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }
        public DateOnly ShelfLife { get { return ShelfLife; } private set { ShelfLife = value; } }

        public static Box CreateBoxByProductionDate(int width, int height, int depth, int weight, DateOnly productionDate)
        {
            return new Box
            {
                Width = width,
                Height = height,
                Depth = depth,
                Weight = weight,
                ShelfLife = productionDate.AddDays(100)
            };
        }

        public static Box CreateBoxByShelfLife(int width, int height, int depth, int weight, DateOnly shelfLife)
        {
            return new Box
            {
                Width = width,
                Height = height,
                Depth = depth,
                Weight = weight,
                ShelfLife = shelfLife
            };
        }

        public long GetVolume()
        {
            try
            {
                return (long)(Width * Height * Depth);
            }
            catch
            {
                Console.WriteLine("Введены некорректные размеры");
            }

            return 0;
        }
    }
}