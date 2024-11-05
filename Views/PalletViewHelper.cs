using Pallets.Models;
using Pallets.Services;

namespace Pallets.Views
{
    public static class PalletViewHelper
    {
        public static IEnumerable<IGrouping<DateOnly?, Pallet>> SortGroupsByShelfLife(IEnumerable<IGrouping<DateOnly?, Pallet>> groupedPallets)
        {
            return groupedPallets.OrderBy(g => g.Key);
        }

        public static IEnumerable<IGrouping<DateOnly?, Pallet>> SortPalletsInGroupByWeight(IEnumerable<IGrouping<DateOnly?, Pallet>> groupedPallets)
        {
            var sortedPalletGroups = new List<Grouping<DateOnly?, Pallet>>();

            foreach (var groupOfPallets in groupedPallets)
            {
                var sortedGroup = from pallet in groupOfPallets
                                  orderby pallet.Weight descending
                                  select pallet;
                sortedPalletGroups.Add(new(groupOfPallets.Key, sortedGroup));
            }
            return sortedPalletGroups;
        }


        public static IEnumerable<Pallet> SortPalletsByVolume(IEnumerable<Pallet> pallets)
        {
            return pallets.OrderBy(pallet => pallet.Volume);
        }
    }
}
