using System;
using zuul_core;
using Zuul_Item_Behavior;

namespace Zuul_Items
{
    class Map : Item, IPickable
    {
        public Map(string name, string description) : base()
        {
            Name = name;
            Description = description;
            IsPickable = true;
        }
        override public int Id { get; set; }
        override public string Name { get; set; }
        override public string Description { get; set; }

        public Boolean IsPickable { get; set; }

    }
}