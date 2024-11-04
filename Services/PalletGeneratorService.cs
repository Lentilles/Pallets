using Pallets.Interfaces;
using Pallets.Models;
using Pallets.Repositories;

namespace Pallets.Generator
{
    public class PalletGeneratorService : IGenerator<Pallet>
    {
        public Size MinSize = Size.DefaultMinSize;
        public Size MaxSize = Size.DefaultMaxSize;

        private readonly IPalletRepository _palletRepository;
        public PalletGeneratorService(IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
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
