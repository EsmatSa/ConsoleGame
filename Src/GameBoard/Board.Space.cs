using ConsoleGame;

namespace ConsoleGame
{
    public partial class Board
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">coulumn of space</param>
        /// <param name="r">row of space</param>
        /// <returns></returns>
        private int CalculateSpaceIndex(int c, int r)
        {
            return Math.Clamp(c, -1, Width) + Math.Clamp(r, -1, Height) * Width;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void CreateSpaces(int width, int height)
        {
            Width = Math.Clamp(width, 2, 10);
            Height = Math.Clamp(height, 2, 10);
            Spaces = new Space[Size];
            for (int i = 0; i < Size; i++)
            {
                var tmpSpace = new Space();
                var c = i % Width;
                var r = i / Width;
                tmpSpace.Name = String.Format(Text.Language.DefaultSpaceName, i, c, r);
                if (c < Width - 1)
                    tmpSpace.Neighbors[Directions.East] = CalculateSpaceIndex(c + 1, r);
                if (c > 0)
                    tmpSpace.Neighbors[Directions.West] = CalculateSpaceIndex(c - 1, r);
                if (r < Height - 1)
                    tmpSpace.Neighbors[Directions.North] = CalculateSpaceIndex(c, r + 1);
                if (r > 0)
                    tmpSpace.Neighbors[Directions.South] = CalculateSpaceIndex(c, r - 1);

                Spaces[i] = tmpSpace;

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
        /// set Gold and Trap Spaces on Board with random function
        /// </summary>
        public void SetSpaceFortunes()
        {
            var goldIndex = _rnd.Next(0, this.Size - 1);
            Spaces[goldIndex].Fortune = SpaceFortune.Gold;

            var trapIndex = _rnd.Next(0, this.Size - 1);
            while (trapIndex == goldIndex)
            {
                trapIndex = _rnd.Next(0, this.Size - 1);
            }
            Spaces[trapIndex].Fortune = SpaceFortune.Trap;

        }
    }
}