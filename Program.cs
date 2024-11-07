using Pallets.Generator;
using Pallets.Models;
using Pallets.Repositories;
using Pallets.Services;
using Pallets.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        MenuOption menuVariant = MenuOption.Generate;
        var palletRepository = new NonDbPalletRepository();
        var palletService = new PalletService(palletRepository);


        while (menuVariant != MenuOption.Exit)
        {
            menuVariant = BaseMenu.ShowMenu();
            switch (menuVariant)
            {
                case MenuOption.Generate:
                    {
                        GenerationMenu.ShowPalletGenerationMessage();
                        var palletCount = GenerationMenu.AskGenerationCount();
                        var pallets = palletRepository.Pallets as List<Pallet>;

                        PalletGeneratorService palletGenerator = new PalletGeneratorService(palletRepository);
                        pallets.AddRange(palletGenerator.Generate(palletCount));

                        GenerationMenu.ShowMaxBoxCountGenerationMessage();
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
                case MenuOption.ShowGroupedPallets:
                    {
                        var groupedPallets = palletService.GetAllPalletsGroupedByShelfLife();

                        groupedPallets = PalletViewHelper.SortPalletsInGroupByWeight(groupedPallets);
                        groupedPallets = PalletViewHelper.SortGroupsByShelfLife(groupedPallets);

                        PalletMenu.ShowGroupedAndOrderedPallets(groupedPallets);

                        break;
                    }
                case MenuOption.ShowPalletsWithLongestShelfLife:
                    {
                        var pallets = palletService.GetPalletsWithLongestShelfLife(3);
                        pallets = PalletViewHelper.SortPalletsByVolume(pallets);

                        PalletMenu.ShowPalletsWithLongestShelfLife(pallets);

                        break;
                    }
                default: { return; }
            }
        }
    }
}