using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Pallets.Views
{
    public static class PalletMenu
    {
        private const string LongestShelfLifeHeader = "Паллеты с самым большим сроком годности, отсортированные по объему";

        public static void ShowGroupedAndOrderedPallets(IEnumerable<IGrouping<DateOnly?, Pallet>> groups)
        {
            foreach(var group in groups)
            {
                Console.WriteLine(group.Key.ToString());
                foreach(var pallet in group)
                {
                    Console.WriteLine($"{pallet.Id} \t {pallet.Weight}");
                }
            }
        }

        public static void ShowPalletsWithLongestShelfLife(IEnumerable<Pallet> pallets)
        {
            Console.WriteLine(LongestShelfLifeHeader);
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"{pallet.Id} \t | \t {pallet.ShelfLife} \t | \t {pallet.Volume}");
            }
        }
    }
}
