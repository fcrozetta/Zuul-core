using System;
using System.Collections.Generic;

namespace zuul_core
{
    class Player
    {
        public (int x, int y) Position { get; set; }
        // Side where the player is looking
        private char facingSide;
        public char FacingSide
        {
            get { return facingSide; }
            set
            {
                char tmp = value.ToString().ToUpperInvariant().Trim().ToCharArray()[0];
                if (new List<char>() { 'N', 'S', 'E', 'W', 'U', 'D' }.Contains(tmp))
                {
                    facingSide = tmp;
                }
            }
        }
        // Inventory
        public Bag Bag { get; set; }

        public Player()
        {
            FacingSide = 'N';
            Bag = new Bag();
            Position = (0, 0);
        }

        public void turn(char side)
        {
            FacingSide = side;
        }


    }
}