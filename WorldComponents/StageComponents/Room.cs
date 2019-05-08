namespace Zuul_Stage
{
    class Room
    {
        public Wall NorthSide { get; set; }
        public Wall SouthSide { get; set; }
        public Wall EastSide { get; set; }
        public Wall WestSide { get; set; }
        public Wall UpSide { get; set; }
        public Wall DownSide { get; set; }

        public Room()
        {
            NorthSide = new Wall("North wall", "a white wall");
            SouthSide = new Wall("South wall", "a white wall");
            EastSide = new Wall("East wall", "a white wall");
            WestSide = new Wall("West wall", "a white wall");
            UpSide = new Wall("Up wall", "a white wall");
            DownSide = new Wall("Down wall", "a white wall");
        }

        public Wall getWall(char side)
        {
            switch (side)
            {
                case 'N':
                    return NorthSide;
                case 'S':
                    return SouthSide;
                case 'E':
                    return EastSide;

                case 'W':
                    return WestSide;

                case 'U':
                    return UpSide;

                case 'D':
                    return DownSide;

                default:
                    return NorthSide;
            }
        }
    }
}