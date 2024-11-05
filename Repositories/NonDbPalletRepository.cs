using Pallets.Models;

namespace Pallets.Repositories
{
    public interface IPalletRepository
    {
        public IEnumerable<Pallet> Pallets { get; set; }
        public IEnumerable<IGrouping<DateOnly?, Pallet>> GetAllPalletsGroupedByShelfLife();
        public IEnumerable<Pallet> GetPalletsWithLongestShelfLife(int count);
    }

    public class NonDbPalletRepository : IPalletRepository
    {
        public IEnumerable<Pallet> Pallets { get; set; } = new List<Pallet>();
        public IEnumerable<IGrouping<DateOnly?, Pallet>> GetAllPalletsGroupedByShelfLife()
        {
            return from pallet in Pallets
                     group pallet by pallet.ShelfLife;
        }

        public IEnumerable<Pallet> GetPalletsWithLongestShelfLife(int count)
        {
            return Pallets.Where(pallet=>pallet.ShelfLife != null).OrderByDescending(pallet => pallet.ShelfLife).Take(count);
        }
    }
}
