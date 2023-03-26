
namespace ConsoleGame;

public class French : Language
{
    public French()
    {
        Welcome = "Bonjour, Bienvenue dans mon jeu console.";
        EnterYourBoardSize = "Veuillez entrer la hauteur et la largeur du plateau de jeu : L,H ";
        BoardSizeError = "Votre entrée n'est pas dans un format correct.";
        DefaultSpaceName = "Espace {0} ({1},{2})";
        DefaultSpaceDescription = " Vous êtes dans un espace {0}. ";
        AvailableSpaces = "Maintenant vos espaces disponibles sont le {0}.";
        ActionError = "Vous ne pouvez pas faire ça";
        Go = "Aller";
        GoError = "Vous ne pouvez pas passer par là";
        WhatToDo = "Que voulez-vous faire ? (Aller ou quitter)";
        Quit = "quitter";
        SpaceNew = "Vous avez entré {0}.";
        SpaceOld = "Vous retournez {0}.";
        And = "et";
        Comma = ",";
        Space = " ";
        ReachMaxMove = "Game over ! C'était votre dernière chance ! Vous ne pouvez plus vous déplacer ! Vous avez atteint votre limite ! Meilleure chance la prochaine fois !";
        Win = "Félicitations ! Vous avez trouvé l'or !";
        GameOver = "Game over ! Vous êtes tombé dans un piège ! Meilleure chance la prochaine fois !";
        GameContinue = "Voulez-vous commencer une nouvelle manche ?(o/n)";
        GameFinished = "Jeu terminé, merci d'avoir joué, à la prochaine fois !";
    }
    
}
