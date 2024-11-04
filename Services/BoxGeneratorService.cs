using Pallets.Interfaces;
using Pallets.Models;
using Pallets.Repositories;

namespace Pallets.Generator
{
    public class BoxGeneratorService : IGenerator<Box>
    {
        public Size MinSize = Size.DefaultMinSize;
        public Size MaxSize = Size.DefaultMaxSize;
        public int MaxAddDaysToShelfLife = 366;

        public IEnumerable<Box> Generate(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                var size = new Size()
                {
                    Width = random.Next(MinSize.Width, MaxSize.Width),
                    Height = random.Next(MinSize.Height, MaxSize.Height),
                    Depth = random.Next(MinSize.Depth, MaxSize.Depth)
                };

                var weight = random.Next();
                var shelfLife = DateOnly.FromDateTime(DateTime.Now)
                    .AddDays(random.Next(MaxAddDaysToShelfLife));

                yield return Box.CreateBoxByShelfLife(size, weight, shelfLife);
            }


        }
    }
}
