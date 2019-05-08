using System.Linq;
using System.Collections.Generic;
using System;
using Zuul_Item_Behavior;

namespace zuul_core
{
    // The player inventory
    class Bag
    {
        public Bag()
        {
            Items = new List<Item>();
            IsOpen = false;
        }
        private List<Item> Items { get; set; }
        public Boolean IsOpen { get; set; }

        public string getAllItems()
        {
            string result = "";
            foreach (Item item in Items)
            {
                // formatted for TUI
                result += $" \n  {item.Name}";
            }
            return result;
        }

        public Item getItem(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public Item getItemByName(string name)
        {
            return Items.FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant().Trim());
        }

        public Boolean addItem(Item item)
        {
            if (item is IPickable && (item as IPickable).IsPickable)
            {
                Items.Add(item);
                return true;
            }
            return false;

        }


    }
}