﻿using CosminIv.Games.Common;
using CosminIv.Games.Common.Color;
using CosminIv.Games.Tetris;
using CosminIv.Games.Tetris.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CosminIv.Games.UI.Console.Tetris
{
    internal class TetrisBoardRenderer
    {
        readonly int Rows;
        readonly int Columns;
        readonly int BorderWidth;
        readonly Coordinates BoardWindowOrigin;
        readonly TetrisPieceRenderer PieceRenderer;
        readonly TetrisStateDifferences StateDifferences;

        public TetrisBoardRenderer(TetrisEngine engine, Coordinates topLeft) {
            Rows = engine.Settings.Rows;
            Columns = engine.Settings.Columns;
            BoardWindowOrigin = topLeft;
            BorderWidth = 1;
            PieceRenderer = new TetrisPieceRenderer();
            StateDifferences = new TetrisStateDifferences(Rows, Columns);
        }

        public void DisplayPiece(TetrisPiece piece, Coordinates boardCoord) {
            Coordinates windowCoord = MakeWindowCoordinates(boardCoord);
            PieceRenderer.Display(piece, windowCoord);
        }

        public void DisplayBoard(TetrisState oldState, TetrisState newState) {
            List<TetrisBrickWithPosition> changedBricks = StateDifferences.ComputeDifferences(oldState, newState);
            DisplayDifferences(changedBricks);
        }

        private void DisplayDifferences(List<TetrisBrickWithPosition> diffList) {
            foreach (TetrisBrickWithPosition brickWithPos in diffList) {
                DisplayBrickCharacter(brickWithPos.Brick, brickWithPos.Position.Row, brickWithPos.Position.Column);
            }
        }

        private Coordinates MakeWindowCoordinates(Coordinates boardCoord) {
            int row = BoardWindowOrigin.Row + BorderWidth + boardCoord.Row;
            int column = BoardWindowOrigin.Column + BorderWidth + boardCoord.Column;
            return new Coordinates(row, column);
        }

        public void DisplayBoardBorder() {
            System.Console.ForegroundColor = ConsoleColor.White;
            
            DisplayBoardHorizontalBorder(BoardWindowOrigin.Row, TetrisConsoleConstants.BorderCornerUpLeft,
                TetrisConsoleConstants.BorderCornerUpRight);
            string blankRowText = new string(Enumerable.Range(1, Columns)
                .Select(i => TetrisConsoleConstants.Space[0]).ToArray());
            string borderRowText = TetrisConsoleConstants.VerticalBorder + blankRowText + TetrisConsoleConstants.VerticalBorder;

            for (int row = 0; row < Rows; row++) {
                int windowRow = BoardWindowOrigin.Row + BorderWidth + row;
                System.Console.SetCursorPosition(BoardWindowOrigin.Column, windowRow);
                System.Console.Write(borderRowText);
            }

            DisplayBoardHorizontalBorder(BoardWindowOrigin.Row + BorderWidth + Rows, TetrisConsoleConstants.BorderCornerDownLeft, TetrisConsoleConstants.BorderCornerDownRight);
        }

        private void DisplayBrickCharacter(TetrisBrick brick, int row, int column) {
            int windowColumn = column + BoardWindowOrigin.Column + BorderWidth;
            int windowRow = row + BoardWindowOrigin.Row + BorderWidth;
            System.Console.SetCursorPosition(left: windowColumn, top: windowRow);

            if (brick != null) {
                System.Console.ForegroundColor = (brick.Color as ConsoleColor2).Value;
                System.Console.Write(TetrisConsoleConstants.Brick);
            }
            else {
                System.Console.Write(TetrisConsoleConstants.Space);
            }
        }

        private void DisplayBoardHorizontalBorder(int windowRow, string leftCorner, string rightCorner) {
            System.Console.SetCursorPosition(left: BoardWindowOrigin.Column, top: windowRow);
            System.Console.Write(leftCorner);
            for (int i = 0; i < Columns; i++) 
                System.Console.Write(TetrisConsoleConstants.HorizontalBorder);
            System.Console.Write(rightCorner);
        }
    }
}
