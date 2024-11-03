using Pallets.Generator;
using Pallets.Models;
using Pallets.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Pallet> pallets = new List<Pallet>();


        var menuVariant = BaseMenu.ShowMenu();

        switch (menuVariant)
        {
            case 1:
                {
                    var palletCount = GenerationMenu.AskGenerationCount();

                    PalletGenerator palletGenerator = new PalletGenerator(Size.DefaultMinSize, Size.DefaultMaxSize);
                    pallets.AddRange(palletGenerator.Generate(palletCount));

                    var maxBoxCount = GenerationMenu.AskGenerationCount();

                    BoxGenerator boxGenerator = new BoxGenerator(Size.DefaultMinSize, Size.DefaultMaxSize, 366);
                    Random random = new Random();

                    foreach(var pallet in pallets)
                    {
                        if (pallet.TryAddBoxRange(boxGenerator.Generate(random.Next(maxBoxCount))))
                        {
                            
                        }
                    }


                    break;
                }
            case 2:
                {
                    

                    break;
                }
            case 3:
                {
                    

                    break;
                }

        }
    }
}