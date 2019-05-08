using System.Collections.Generic;
using zuul_core;
using Zuul_Items;

namespace Zuul_Stage
{
    class Wall
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<Item> Items { get; set; }

        public Wall(string name, string shortDescription)
        {
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = "";
            Items = new List<Item>();
        }

        public string getItemsNames()
        {
            string result = "";
            foreach (Item item in Items)
            {
                result += $"{item.Name} ";
            }
            return result;
        }
    }
}