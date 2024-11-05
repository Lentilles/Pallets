using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Views
{
    public static class PalletMenu
    {
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
    }
}
