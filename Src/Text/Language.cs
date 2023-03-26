namespace ConsoleGame
{
    public abstract partial class Language
    {
        public string Welcome { get; protected set; } = "";
        public string EnterYourBoardSize { get; protected set; } = "";
        public string BoardSizeError { get; protected set; } = "";
        public string DefaultCellName { get; protected set; } = "";
        public string DefaultCellDescription { get; protected set; } = "";
        public string AvailableCells { get; protected set; } = "";
        public string ActionError { get; protected set; } = "";
        public string Go { get; protected set; } = "";
        public string GoError { get; protected set; } = "";
        public string WhatToDo { get; protected set; } = "";
        public string Quit { get; protected set; } = "";

        public string CellNew { get; protected set; } = "";
        public string CellOld { get; protected set; } = "";
        public string And { get; protected set; } = "";
        public string Comma { get; protected set; } = "";
        public string Space { get; protected set; } = "";
        public string ReachMaxMove { get; protected set; } = "";
        public string Win { get; protected set; } = "";
        public string GameOver { get; protected set; } = "";
        public string GameContinue { get; protected set; } = "";
        public string GameContinueYes { get; protected set; } = "";
        public string GameFinished { get; protected set; } = "";




    }
}