using ConsoleGame;

namespace ConsoleGame
{
    public partial class Board
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">coulumn of Cell</param>
        /// <param name="r">row of Cell</param>
        /// <returns></returns>
        private int CalculateCellIndex(int c, int r)
        {
            return Math.Clamp(c, -1, Width) + Math.Clamp(r, -1, Height) * Width;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void CreateCells(int width, int height)
        {
            Width = Math.Clamp(width, 2, 10);
            Height = Math.Clamp(height, 2, 10);
            Cells = new Cell[Size];
            for (int i = 0; i < Size; i++)
            {
                var tmpCell = new Cell();
                var c = i % Width;
                var r = i / Width;
                tmpCell.Name = String.Format(Text.Language.DefaultCellName, i, c, r);
                if (c < Width - 1)
                    tmpCell.Neighbors[Directions.Right] = CalculateCellIndex(c + 1, r);
                if (c > 0)
                    tmpCell.Neighbors[Directions.Left] = CalculateCellIndex(c - 1, r);
                if (r < Height - 1)
                    tmpCell.Neighbors[Directions.Up] = CalculateCellIndex(c, r + 1);
                if (r > 0)
                    tmpCell.Neighbors[Directions.Down] = CalculateCellIndex(c, r - 1);

                Cells[i] = tmpCell;

            }

        }
        public bool TryParseBoardSize(string BoardSize, out int width, out int height)
        {
            width = 0; height = 0;
            if (BoardSize.Contains(","))
            {
                string[] parts = BoardSize.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out width) && int.TryParse(parts[1], out height))
                    return true;
            }

            Console.WriteLine(Text.Language.BoardSizeError);
            return false;
        }
        /// <summary>
        /// set Gold and Trap Cells on Board with random function
        /// </summary>
        public void SetCellFortunes()
        {
            var goldIndex = _rnd.Next(0, this.Size - 1);
            Cells[goldIndex].Fortune = CellFortune.Gold;

            var trapIndex = _rnd.Next(0, this.Size - 1);
            while (trapIndex == goldIndex)
            {
                trapIndex = _rnd.Next(0, this.Size - 1);
            }
            Cells[trapIndex].Fortune = CellFortune.Trap;

        }
    }
}