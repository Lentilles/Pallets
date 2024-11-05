using Pallets.Models;
using System.Text;

namespace Pallets.Views
{
    public static class BaseMenu
    {
        private const string ChoseText = "Выберите пункт меню:";
        private const string GenerateDataText = "1. Сгенерировать паллеты и коробки";
        private const string ShowGroupedText = "2. Сгруппировать паллеты по сроку годности, " +
            "отсортировать по возрастанию срока годности, " +
            "в каждой группе отсортировать паллеты по весу";
        private const string ShowPalletsText = "3. 3 паллеты, которые содержат коробки с наибольшим сроком годности, " +
            "отсортированные по возрастанию объема.";
        private const string ExitText = "0. Выход";

        private const string ParseErrorText = "Выберите пункт меню (1-3)";

        public static MenuOption ShowMenu()
        {
            StringBuilder choseOptions = new StringBuilder();

            choseOptions.AppendLine(ChoseText)
                .AppendLine(GenerateDataText)
                .AppendLine(ShowGroupedText)
                .AppendLine(ShowPalletsText)
                .AppendLine(ExitText);

            Console.WriteLine(choseOptions);

            var input = Console.ReadLine();
            var chose = 0;

            while (!int.TryParse(input, out chose))
            {
                Console.WriteLine(ParseErrorText);
            }

            return (MenuOption)chose;
        }
    }
}
