using System.Linq;
using System;
using System.Collections.Generic;
using zuul_core;
using Zuul_Item_Behavior;

namespace Zuul_Stage
{
    class Stage
    {
        public string StageName { get; set; }
        // Stages are squares, so only one size needed
        public int StageSize { get; set; }
        public Room[,] Rooms { get; set; }
        public Player Player { get; set; }

        // used to create items
        private int lastId;
        private List<Item> StageItems { get; set; }

        public Stage(string stageName, int stageSize, Player player)
        {
            StageName = stageName;
            StageSize = stageSize;
            if (player == null)
            {
                Player = new Player();
            }
            else
            {
                Player = player;
            }
            Player.Position = (0, 0);
            Rooms = new Room[StageSize, StageSize];
            Rooms[0, 0] = new Room();

            StageItems = new List<Item>();
            lastId = 0;
        }

        // add the item and return the new ID
        // Does NOT place the item
        public int addItem(Item item)
        {
            lastId++;
            item.Id = lastId;
            StageItems.Add(item);

            return item.Id;
        }

        public int addItem(Item item, (int x, int y) room, char side)
        {
            lastId++;
            item.Id = lastId;
            StageItems.Add(item);
            Rooms[room.x, room.y].getWall(side).Items.Add(item);

            return item.Id;
        }

        public Room getPlayerRoom()
        {
            return Rooms[Player.Position.x, Player.Position.y];
        }

        public string getCurrentWallView()
        {
            Wall wall = getPlayerRoom().getWall(Player.FacingSide);
            string result = wall.ShortDescription;
            if (wall.Items.Count > 0)
            {
                result += "  \n You can see the following:  \n  ";
                result += wall.getItemsNames();
            }

            return result;
        }

        public Boolean playerPick(string sItem)
        {
            Item item = StageItems.FirstOrDefault(x => x.Name.ToLowerInvariant() == sItem.ToLowerInvariant().Trim());
            if (Player.Bag.addItem(item))
            {
                getPlayerRoom().getWall(Player.FacingSide).Items.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public (int status, string message) useItem(string sItem)
        {
            var item = getPlayerRoom().getWall(Player.FacingSide).Items.FirstOrDefault(x => x.Name.ToLowerInvariant() == sItem.ToLowerInvariant().Trim());
            if (item is IUsable && (item as IUsable).IsUsable)
            {
                return (item as IUsable).use(Player, null);
            }
            else
            {
                return (-1, "Can't use it");
            }

        }
    }
}