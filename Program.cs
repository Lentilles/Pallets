using Pallets.Generator;
using Pallets.Models;
using Pallets.Repositories;
using Pallets.Services;
using Pallets.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        int menuVariant = -1;
        var palletRepository = new NonDbPalletRepository();
        
        while (menuVariant != 0)
        {
            menuVariant = BaseMenu.ShowMenu();
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

                        foreach (var pallet in pallets)
                        {
                            var loadResult = pallet.AddBoxRange(boxGenerator.Generate(random.Next(1, maxBoxCount)));
                            GenerationMenu.AddingBoxesOnPalletResult(loadResult);
                        }

                        palletRepository.Pallets = pallets;
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
}