using zuul_core;
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

            var room1_1 = new Room();
            room1_1.NorthSide.ShortDescription = "You should not see this room when enter";
            room1_1.EastSide.ShortDescription = "Great!, now you can [pick map] so you can see where you are!";
            s.Rooms[0, 1] = room1_1;


            // ! Creating Door
            Door d1a = new Door("door", "wooden door");
            d1a.IsUsable = true;
            d1a.Destination = (0, 1);
            s.addItem(d1a, (0, 0), 'E');

            Door d1b = new Door("door", "wooden door");
            d1b.IsUsable = true;
            d1b.Destination = (0, 0);
            s.addItem(d1b, (0, 1), 'W');

            // ! Creating Items
            Item compass = new Compass('N', 0);
            s.addItem(compass, (0, 0), 'N');





            return s;
        }
    }
}