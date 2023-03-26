using ConsoleGame;

// Load Dictionary of messages
Console.WriteLine("EN|FR (select EN for English or FR for French, English is default language)");
var lng = Console.ReadLine();

switch (lng?.ToUpper())
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

    board.CreateCells(width, height);
    board.SetCellFortunes();
    board.GoToStartingCell();

    var moveFlag = true;
    Cell lastCell = null;
    while (moveFlag)
    {
        if (lastCell != board.CurrentCell) // for each movement, new Cell is described in console , if no move then nothing described
        {
            Console.WriteLine(board.CurrentCell.ToString());
            switch (board.CurrentCell.Fortune)
            {
                case CellFortune.Gold:
                    {
                        Console.WriteLine(Text.Language.Win);
                        moveFlag = false;
                        break;
                    }
                case CellFortune.Trap:
                    {
                        Console.WriteLine(Text.Language.GameOver);
                        moveFlag = false;
                        break;
                    }
                default:
                    break;
            }

            lastCell = board.CurrentCell;
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

                board.Move(action);
        }
    }
    Console.WriteLine(Text.Language.GameContinue);
    string response = Console.ReadLine();

    if (response.ToLower() == Text.Language.GameContinueYes)
        gameFlag = true;
    else
    {
        gameFlag = false;
        Console.WriteLine(Text.Language.GameFinished);
    }
}
