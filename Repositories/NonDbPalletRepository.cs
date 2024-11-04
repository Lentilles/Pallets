using Pallets.Models;

namespace Pallets.Repositories
{
    public interface IPalletRepository
    {
        public IEnumerable<Pallet> Pallets { get; set; }
        public IEnumerable<IGrouping<DateOnly, Pallet>> GetAllPalletsGroupedByShelfLife();
    }

    public class NonDbPalletRepository : IPalletRepository
    {
        public IEnumerable<Pallet> Pallets { get; set; } = new List<Pallet>();
        public IEnumerable<IGrouping<DateOnly, Pallet>> GetAllPalletsGroupedByShelfLife()
        {
            var grouped = from pallet in Pallets
                          group pallet by pallet.ShelfLife;

            return from g in grouped
                   from pallet in g
                   orderby pallet.Weight
                   orderby g.Key
                   select g;
        }


    }
}
