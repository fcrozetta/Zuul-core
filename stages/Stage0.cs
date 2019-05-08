using zuul_core;
using Zuul_Items;

namespace Zuul_Stage
{
    class Stage0 : IStageBuilder
    {
        public Stage create()
        {
            Stage s = new Stage("stage 0", 2, null);
            // ! Creating rooms
            s.Rooms[0, 0].NorthSide.ShortDescription = "This is a test Stage.  \n [pick compass] to equip a compass, and help you navigate.  \n [look east] to keep learning how it works.";
            s.Rooms[0, 0].EastSide.ShortDescription = "Here you should have a door to use...but not yet";
            s.Rooms[0, 0].WestSide.ShortDescription = "The entrance. I came here from there.  \n The sun makes everythong so bright outside...";
            s.Rooms[0, 0].UpSide.ShortDescription = "The ceiling.  \n There is an old fan rotating slowly.";

            var room0_1 = new Room();
            room0_1.NorthSide.ShortDescription = "You should not see this room when enter";
            room0_1.EastSide.ShortDescription = "Great!, now you can [pick map] so you can see where you are!";
            s.Rooms[0, 1] = room0_1;

            var room1_1 = new Room();
            room1_1.NorthSide.ShortDescription = "The wall seem reinforced... Interesting";
            room1_1.SouthSide.ShortDescription = "A white boring wall...  \n At least i can see through the window.";
            room1_1.EastSide.ShortDescription = "This wall is not even painted... Terrible";
            room1_1.WestSide.ShortDescription = "There is a green arrow painted on the wall.  \n Points to the door";
            s.Rooms[1, 1] = room1_1;

            var room1_0 = new Room();
            room1_0.NorthSide.ShortDescription = "This is the end of the tutorial.  \n Use this door to go to the start.";
            room1_0.SouthSide.ShortDescription = "There is nothing but a plain white wall";
            s.Rooms[1, 0] = room1_0;


            // ! Creating Door
            var d1a = new Door("door", "wooden door");
            d1a.IsUsable = true;
            d1a.Destination = (0, 1);
            s.addItem(d1a, (0, 0), 'E');

            var d1b = new Door("door", "wooden door");
            d1b.IsUsable = true;
            d1b.Destination = (0, 0);
            s.addItem(d1b, (0, 1), 'W');

            var d2a = new Door("door", "steel door")
            {
                IsUsable = true,
                Destination = (1, 1)
            };
            var d2b = new Door("door", "steel door")
            {
                IsUsable = true,
                Destination = (0, 1)
            };
            s.addItem(d2a, (0, 1), 'S');
            s.addItem(d2b, (1, 1), 'N');

            // 
            var d3a = new Door("door", "Large door")
            {
                IsUsable = true,
                Destination = (1, 0)
            };

            var d3b = new Door("door", "Large door")
            {
                IsUsable = true,
                Destination = (1, 1)
            };
            s.addItem(d3a, (1, 1), 'W');
            s.addItem(d3b, (1, 0), 'E');

            var d4a = new Door("secret_door", "people on the other side don't know this door exist")
            {
                IsUsable = true,
                Destination = (0, 0)
            };
            s.addItem(d4a, (1, 0), 'N');




            // ! Creating Items
            Item compass = new Compass('N', 0);
            s.addItem(compass, (0, 0), 'N');

            string mapDesign = "Simple design of the map";
            mapDesign += "  \n +---+---+";
            mapDesign += "  \n |   |   |";
            mapDesign += "  \n +---+---+";
            mapDesign += "  \n |   |   |";
            mapDesign += "  \n +---+---+";
            Item map = new Map("map", mapDesign);
            s.addItem(map, (0, 1), 'E');





            return s;
        }
    }
}