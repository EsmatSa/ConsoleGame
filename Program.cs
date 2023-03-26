using ConsoleGame;

// Load Dictionary of messages
Console.WriteLine("EN|FR");
var lng = Console.ReadLine();
if (lng != null)
{
    switch (lng.Substring(0, 2).ToUpper())
    {
        case "EN":
            {
                Text.LoadLanguage(new English());
                break;
            }
        case "FR":
            {
                Text.LoadLanguage(new French());
                break;
            }
        default:
            {
                Text.LoadLanguage(new English());
                break;
            }
    }
}
Console.WriteLine(Text.Language.Welcome);

var gameFlag = true;
while (gameFlag)
{
    var player = new Player();
    var board = new Board(player);

    int width = 0, height = 0;
    bool validSize = false;
    while (!validSize)
    {
        Console.WriteLine(Text.Language.EnterYourBoardSize);
        var boardSize = Console.ReadLine();
        validSize = board.TryParseBoardSize(boardSize, out width, out height);
    }

    board.CreateSpaces(width, height);
    board.SetSpaceFortunes();
    board.GoToStartingSpace();

    var moveFlag = true;
    Space lastSpace = null;
    while (moveFlag)
    {
        if (lastSpace != board.CurrentSpace) // for each movement, new Space is described in console , if no move then nothing described
        {
            Console.WriteLine(board.CurrentSpace.ToString());
            switch (board.CurrentSpace.Fortune)
            {
                case SpaceFortune.Gold:
                    {
                        Console.WriteLine(Text.Language.Win);
                        moveFlag = false;
                        break;
                    }
                case SpaceFortune.Trap:
                    {
                        Console.WriteLine(Text.Language.GameOver);
                        moveFlag = false;
                        break;
                    }
                default:
                    break;
            }

            lastSpace = board.CurrentSpace;
            board.Player.PlayerMoves++;

            if (board.Player.PlayerMoves == board.Size && moveFlag)
            {
                Console.WriteLine(Text.Language.ReachMaxMove);
                moveFlag = false;
                break;
            }
        }
        if (moveFlag)
        {
            Console.WriteLine(Text.Language.WhatToDo);
            var action = Console.ReadLine().ToLower();
            if (action == Text.Language.Quit)
                moveFlag = false;
            else
                
                board.Move(action.Split(' '));
        }
    }
    Console.WriteLine(Text.Language.GameContinue);
    string response = Console.ReadLine();

    if (response.ToLower() == "y")
        gameFlag = true;

    else if (response.ToLower() == "n")
    {
        gameFlag = false;
        Console.WriteLine(Text.Language.GameFinished);
    }
}
