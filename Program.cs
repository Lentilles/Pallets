using Pallets.Generator;
using Pallets.Models;
using Pallets.Repositories;
using Pallets.Services;
using Pallets.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        var menuVariant = BaseMenu.ShowMenu();
        var palletRepository = new NonDbPalletRepository();

        switch (menuVariant)
        {
            case 1:
                {
                    var palletCount = GenerationMenu.AskGenerationCount();
                    var pallets = palletRepository.Pallets as List<Pallet>;

                    PalletGeneratorService palletGenerator = new PalletGeneratorService(palletRepository);
                    pallets.AddRange(palletGenerator.Generate(palletCount));

                    var maxBoxCount = GenerationMenu.AskGenerationCount();

                    BoxGeneratorService boxGenerator = new BoxGeneratorService();
                    Random random = new Random();

                    foreach(var pallet in pallets)
                    {
                        var loadResult = pallet.AddBoxRange(boxGenerator.Generate(random.Next(maxBoxCount)));
                        GenerationMenu.AddingBoxesOnPalletResult(loadResult);
                    }

                    break;
                }
            case 2:
                {
                    var palletService = new PalletService(palletRepository);

                    var groupedPallets = palletService.GetAllPalletsGroupedByShelfLife();

                    PalletMenu.ShowGroupedAndOrderedPallets(groupedPallets);

                    break;
                }
            case 3:
                {
                    

                    break;
                }

        }
    }
}