using Pallets.Models;
using System.Text;

namespace Pallets.Views
{
    public static class GenerationMenu
    {
        private const string AskGenerationCountText = "Введите количество для генерации: ";
        private const string AskGenerationCountErrorText = "Введите целое число.";

        private const string GenerationSuccess = "Генерация прошла успешно.";
        private const string GenerationFailure = "Ошибка генерации";

        private const string AddingBoxesOnPalletInfoText = "Информация о добавлении коробок на палет с ID: ";
        private const string AddingBoxesOnPalletSuccessText = "На палет успешно было загружено коробок: ";
        private const string AddingBoxesOnPalletFailureText = "Количество коробок которое не поместилось на палет: ";

        public static int AskGenerationCount()
        {
            int count = 0;
            Console.WriteLine(AskGenerationCountText);

            while (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine(AskGenerationCountErrorText);
            }

            return count;
        }


        public static void AddingBoxesOnPalletResult(ILoadPalletResult result)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(AddingBoxesOnPalletInfoText)
                .AppendLine(result.PalletId.ToString())
                .Append(AddingBoxesOnPalletSuccessText)
                .AppendLine(result.LoadedCount.ToString())
                .Append(AddingBoxesOnPalletFailureText)
                .AppendLine(result.SkipedCount.ToString());

            Console.WriteLine(builder);
        }
    }
}
