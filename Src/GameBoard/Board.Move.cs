using ConsoleGame;

namespace ConsoleGame
{
    public partial class Board
    {
        public Cell CurrentCell { get; set; }
        public void GoToCell(int index)
        {
            if (CurrentCell != null)
                CurrentCell.Visited = true;
            CurrentCell = Cells[index];
        }
        public void GoToStartingCell()
        {
            GoToCell(_rnd.Next(0, Cells.Length));
        }
        public void Move(string direction)
        {
            try
            {
                var dir = direction.Substring(0, 1).ToUpper() + direction.Substring(1).ToLower();
                Enum.TryParse(dir, out Directions newDirection);


                var nextCellIndex = CurrentCell.Neighbors[newDirection];

                if (nextCellIndex == -1 || newDirection == Directions.None)
                    Console.WriteLine(Text.Language.GoError);

                else
                    GoToCell(nextCellIndex);
            }
            catch (Exception)
            {
                Console.WriteLine(Text.Language.ActionError);

            }
        }
    }
}