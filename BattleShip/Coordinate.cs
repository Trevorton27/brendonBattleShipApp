namespace BattleShip
{
    class Coordinate
    {

        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
            IsShip = false;
            IsVisible = false;
            IsGuessed = false;
        }

        public int Column { get; }
        public int Row { get; }
        public bool IsShip { get; set; }
        public bool IsVisible { get; set; }
        public bool IsGuessed { get; set; }
    }
}
