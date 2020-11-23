using System;
using System.Collections.Generic;
using System.Text;

namespace _05.classes
{
    public class ValuableItem
    {
        public ValuableItemType Type { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public ValuableItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public ValuableItem(string name, int quantity, ValuableItemType type) : this(name, quantity)
        {
            Type = type;
        }

        public static ValuableItemType DetermineType(string name)
        {
            string lower = name.ToLower();

            if (lower.Length == 3)
                return ValuableItemType.Cash;

            if (lower == "gold")
                return ValuableItemType.Gold;

            if (lower.Length >= 4 && lower.EndsWith("gem"))
                return ValuableItemType.Gem;

            return ValuableItemType.Unidentified;
        }
    }
}
