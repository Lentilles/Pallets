using Pallets.Interfaces;
using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Generator
{
    public class BoxGenerator : IGenerator<Box>
    {
        public readonly Size MinSize;
        public readonly Size MaxSize;
        public readonly int MaxAddDaysToShelfLife;

        public BoxGenerator(Size minSize, Size maxSize, int maxAddDaysToShelfLife)
        {
            MinSize = minSize;
            MaxSize = maxSize;
            MaxAddDaysToShelfLife = maxAddDaysToShelfLife;
        }

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
