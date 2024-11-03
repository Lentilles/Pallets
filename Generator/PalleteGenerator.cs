using Pallets.Interfaces;
using Pallets.Models;

namespace Pallets.Generator
{
    public class PalletGenerator : IGenerator<Pallet>
    {
        public readonly Size MinSize;
        public readonly Size MaxSize;


        public PalletGenerator(Size minSize, Size maxSize)
        {
            MinSize = minSize;
            MaxSize = maxSize;
        }

        public IEnumerable<Pallet> Generate(int count)
        {
            Random random = new Random();

            for(int i = 0; i < count; i++)
            {
                yield return new Pallet()
                {
                    Id = Guid.NewGuid(),
                    Size = new Size()
                    {
                        Width = random.Next(MinSize.Width, MaxSize.Width),
                        Height = random.Next(MinSize.Height, MaxSize.Height),
                        Depth = random.Next(MinSize.Depth, MaxSize.Depth)
                    }
                }; 
            }
        }
    }
}
