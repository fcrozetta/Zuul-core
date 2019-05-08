using System;
using System.Collections.Generic;
using zuul_core;
using Zuul_Item_Behavior;

namespace Zuul_Stage
{
    /// <summary>
    /// Doors work like portasl. A one-way item. 
    /// To let the player go back to the previous room, add another door, on the destination room.
    /// </summary>
    class Door : Item, IUsable
    {
        public Door(string name, string description)
        {
            Name = name;
            Description = description;
            Destination = (0, 0);
        }
        override public int Id { get; set; }
        override public string Name { get; set; }
        override public string Description { get; set; }
        public (int x, int y) Destination { get; set; }

        public Boolean IsUsable { get; set; }
        public int UsableWith { get; set; }
        public (int status, string message) use(Player player, List<Item> items)
        {
            player.Position = Destination;
            return (0, "player moved");
        }
    }
}