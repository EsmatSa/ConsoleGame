using ConsoleGame;

namespace ConsoleGame
{
    public partial class Board
    {
        public Space CurrentSpace { get; set; }
        public void GoToSpace(int index)
        {
            if (CurrentSpace != null)
                CurrentSpace.Visited = true;
            CurrentSpace = Spaces[index];
        }
        public void GoToStartingSpace()
        {
            GoToSpace(_rnd.Next(0, Spaces.Length));
        }
        public void Move(string[] args)
        {
            if (args.Length > 1 && args[0] == Text.Language.Go.ToLower() && args[1].Length > 1)
            {

                var dir = args[1].Substring(0, 1).ToUpper() + args[1].Substring(1).ToLower();
                Enum.TryParse(dir, out Directions newDirection);


                var nextSpaceIndex = CurrentSpace.Neighbors[newDirection];

                if (nextSpaceIndex == -1 || newDirection == Directions.None)
                    Console.WriteLine(Text.Language.GoError);

                else
                    GoToSpace(nextSpaceIndex);
            }
            else
                Console.WriteLine(Text.Language.ActionError);

        }
    }
}