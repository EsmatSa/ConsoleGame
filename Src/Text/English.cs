
namespace ConsoleGame;

public class English : Language
{
    public English()
    {
        Welcome = "Hi, Welcome to my console game.";
        EnterYourBoardSize = "Please enter the height and width of playing board: W,H ";
        BoardSizeError = "Your input is not in a correct format. ";
        DefaultCellName = "cell with index {0}({1},{2})";
        DefaultCellDescription = "You are in a {0} cell. ";
        AvailableCells = "Now your available cells are the {0}";
        ActionError = "You can't do that";
        Go = "Go";
        GoError = "You can't go that way";
        WhatToDo = "What do you want to do? (directions or quit)";
        Quit = "quit";
        CellNew = "You entered {0}.";
        CellOld = "You return {0}.";
        And = "and";
        Comma = ",";
        Space = " ";
        ReachMaxMove = "Game over! It was your last chance! You can't move any further! You've hit your limit! Better luck next time!";
        Win = "Congratulations! You have found the Gold!";
        GameOver = "Game over! You have fallen into a trap! Better luck next time!";
        GameContinue = "Do you want to start a new round?(y/n) ";
        GameContinueYes = "y";
        GameFinished = "Game finished, Thanks for playing, see you next time!";
    }
}
