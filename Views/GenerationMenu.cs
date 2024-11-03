using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Views
{
    public static class GenerationMenu
    {
        private const string AskGenerationCountText = "Введите количество для генерации: ";
        private const string AskGenerationCountErrorText = "Введите целое число.";

        private const string GenerationSuccess = "Генерация прошла успешно.";
        private const string GenerationFailure = "Ошибка генерации";
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
    }
}
