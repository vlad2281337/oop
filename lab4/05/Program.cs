using System;
using System.Linq;
using _05.classes;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var bag = new TreasureBag(capacity);
            var content = Console.ReadLine().Split(' ');

            Console.WriteLine();

            for (int i = 0; i < content.Length - 1; i += 2)
            {
                string name = content[i];
                int quantity = int.Parse(content[i + 1]);

                bag.TryPutItem(name, quantity);
            }

            PrintValuables(bag);

            Console.ReadKey();
        }

        static void PrintValuables(TreasureBag bag)
        {
            PrintType(bag, ValuableItemType.Gold, bag.GoldAmount);
            PrintType(bag, ValuableItemType.Gem, bag.GemAmount);
            PrintType(bag, ValuableItemType.Cash, bag.CashAmount);
        }

        static void PrintType(TreasureBag bag, ValuableItemType type, int amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"<{type}> ${amount}");

                var itemsOfType = bag.GetItems()
                                        .Where(i => i.Type == type)
                                        .OrderByDescending(i => i.Name)
                                        .ThenBy(i => i.Quantity);

                foreach (var item in itemsOfType)
                    Console.WriteLine($"##{item.Name} - {item.Quantity}");
            }
        }
    }
}
