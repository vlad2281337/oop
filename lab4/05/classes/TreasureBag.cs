using System;
using System.Collections.Generic;
using System.Text;

namespace _05.classes
{
    public class TreasureBag
    {
        private readonly List<ValuableItem> items;

        public int Capacity { get; }

        public int CashAmount { get; private set; }

        public int GemAmount { get; private set; }

        public int GoldAmount { get; private set; }

        public TreasureBag(int capacity)
        {
            Capacity = capacity;
            items = new List<ValuableItem>();
        }

        public bool TryPutItem(string name, int quantity)
        {
            if (CashAmount + GemAmount + GoldAmount + quantity > Capacity)
                return false;

            var type = ValuableItem.DetermineType(name);

            switch (type)
            {
                case ValuableItemType.Cash:
                    {
                        if (CashAmount + quantity > GemAmount)
                            return false;
                        CashAmount += quantity;
                        break;
                    }
                case ValuableItemType.Gem:
                    {
                        if (GemAmount + quantity > GoldAmount)
                            return false;
                        GemAmount += quantity;
                        break;
                    }
                case ValuableItemType.Gold:
                    {
                        GoldAmount += quantity;
                        break;
                    }
                case ValuableItemType.Unidentified: return false;
            }

            var existingItem = items.Find(i => i.Name.ToLower() == name.ToLower());

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var item = new ValuableItem(name, quantity, type);
                items.Add(item);
            }

            return true;
        }

        public IEnumerable<ValuableItem> GetItems() => items;
    }
}
