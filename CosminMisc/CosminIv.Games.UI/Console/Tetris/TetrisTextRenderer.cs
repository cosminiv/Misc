﻿using System;
using System.Collections.Generic;
using System.Text;
using CosminIv.Games.Common;
using CosminIv.Games.Tetris.DTO;

namespace CosminIv.Games.UI.Console.Tetris
{
    class TetrisTextRenderer
    {
        readonly int ScoreLine = 1;
        readonly int LineCountLine = 2;
        readonly int SpeedLine = 3;
        readonly int NextPieceLine = 5;
        readonly string NextPieceText = $"{TetrisMessage.Next}: ";

        readonly TetrisPieceRenderer PieceRender = new TetrisPieceRenderer();

        internal void DisplayInitial(int speed) {
            DisplayScore(0);
            DisplayLineCount(0);
            DisplaySpeed(speed);
            DisplayNextPieceText();
        }

        internal void DisplayMessage(string message) {
            DisplayMessage(message, 0);
        }

        internal void DisplayScore(int score) {
            DisplayMessage($"{TetrisMessage.Score}: {score}   ", ScoreLine);
        }

        internal void DisplayLineCount(int lineCount) {
            DisplayMessage($"{TetrisMessage.Lines}: {lineCount}    ", LineCountLine);
        }

        internal void DisplaySpeed(int speed) {
            DisplayMessage($"{TetrisMessage.Speed}: {speed}", SpeedLine);
        }

        internal void DisplayNextPieceText() {
            DisplayMessage(NextPieceText, NextPieceLine);
        }

        internal void DisplayNextPiece(TetrisPiece piece) {
            Coordinates coord = new Coordinates(NextPieceLine, NextPieceText.Length);
            PieceRender.Display(piece, coord);
        }

        internal void DeleteNextPiece(TetrisPiece piece) {
            Coordinates coord = new Coordinates(NextPieceLine, NextPieceText.Length);
            PieceRender.Delete(piece, coord);
        }

        private void DisplayMessage(string message, int line) {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.SetCursorPosition(left: 0, top: line);
            System.Console.Write(message);
        }
    }
}
