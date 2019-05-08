using System;
using Zuul_Item_Behavior;
using Zuul_Items;

namespace Zuul_Items
{
    // A compass to know where we are
    class Compass : Item, IPickable, IInteractable
    {
        public Compass(char side, int id) : base()
        {
            Id = id;
            Name = "Compass";
            Description = "A Compass";
            Side = side;
            IsPickable = true;
            IsInteractable = true;
            IsOpen = true;
        }

        // The side where player is looking (UP side on the compass)
        public char Side { get; set; }
        public Boolean IsOpen { get; set; }

        // ! implementing Item
        override public int Id { get; set; }
        override public string Name { get; set; }
        override public string Description { get; set; }

        // ! Pickable implementation
        public Boolean IsPickable { get; set; }

        // ! Interactable Implementation
        public Boolean IsInteractable { get; set; }
        public (int status, string message) interact()
        {
            this.IsOpen = !this.IsOpen;
            return (0, "Compass opened");
        }



        public string updateCompass(char side)
        {
            Side = side;
            return getCompass();
        }

        // TODO: Draw a compass to show when player turns around
        public string getCompass()
        {
            return $"you are facing {Side}";
        }
    }
}