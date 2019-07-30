﻿using CosminIv.Games.Common;
using CosminIv.Games.Tetris.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CosminIv.Games.Tetris
{
    class TetrisFixedBricksLogic
    {
        TetrisBrick[][] Bricks;
        TetrisFullRowsDeleter FullRowsDeleter;
        ConsoleColorFactory ColorFactory = new ConsoleColorFactory();
        Random Random = new Random();

        public TetrisFixedBricksLogic(int rows, int columns, int populatedRows) {
            InitalizeBrickMatrix(rows, columns);
            PopulateRows(populatedRows);
            FullRowsDeleter = new TetrisFullRowsDeleter(Bricks);
        }

        public bool IsBrick(int row, int column) {
            int columnCount = 0;
            if (Bricks.Length > 0)
                columnCount = Bricks[0].Length;

            bool areIndexesOutOfBounds = row < 0 || row >= Bricks.Length || column < 0 || column >= columnCount;
            if (areIndexesOutOfBounds)
                return false;

            bool result = Bricks[row][column] != null;

            return result;
        }

        public void AddPiece(TetrisPieceWithPosition pieceWithPos) {
            TetrisPiece piece = pieceWithPos.Piece;

            for (int row = 0; row < piece.MaxSize; row++) {
                for (int column = 0; column < piece.MaxSize; column++) {
                    TetrisBrick brick = piece[row, column];

                    if (brick != null) {
                        int rowRelativeToBoard = row + pieceWithPos.Position.Row;
                        int columnRelativeToBoard = column + pieceWithPos.Position.Column;
                        Bricks[rowRelativeToBoard][columnRelativeToBoard] = brick;
                    }
                }
            }
        }

        public TetrisFixedBricksState GetState() {
            TetrisFixedBricksState result = new TetrisFixedBricksState();
            result.RowsStartIndex = GetIndexOfTopMostNonEmptyRow();
            result.Rows = Bricks.Where(row => !IsEmptyRow(row)).ToList();
            return result;
        }

        private int GetIndexOfTopMostNonEmptyRow() {
            for (int i = 0; i < Bricks.Length; i++) {
                if (!IsEmptyRow(Bricks[i]))
                    return i;
            }
            return -1;
        }

        public TetrisFixedBricksState DeleteFullRows() {
            TetrisFixedBricksState result = FullRowsDeleter.DeleteFullRows();
            return result;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder(500);

            sb.Append('-', Bricks[0].Length + 2);
            sb.AppendLine();

            for (int row = 0; row < Bricks.Length; row++) {
                sb.Append("|");
                for (int column = 0; column < Bricks[row].Length; column++) {
                    TetrisBrick brick = Bricks[row][column];
                    sb.Append(brick != null ? brick.ToString() : " ");
                }
                sb.Append("|");
                sb.AppendLine();
            }

            sb.Append('-', Bricks[0].Length + 2);
            sb.AppendLine();

            return sb.ToString();
        }

        private bool IsEmptyRow(TetrisBrick[] row) {
            return row.All(brick => brick == null);
        }

        private void InitalizeBrickMatrix(int rows, int columns) {
            Bricks = new TetrisBrick[rows][];
            for (int i = 0; i < rows; i++) {
                Bricks[i] = new TetrisBrick[columns];
            }
        }

        private void PopulateRows(int rowCount) {
            for (int rowIndex = Bricks.Length - 1; rowIndex >= 0 && rowCount > 0; rowIndex--) {
                for (int columnIndex = 0; columnIndex < Bricks[rowIndex].Length; columnIndex++) {
                    Bricks[rowIndex][columnIndex] = MakeRandomBrickOrSpace();
                }
                rowCount--;
            }
        }

        private TetrisBrick MakeRandomBrickOrSpace() {
            // 50% chance to make a brick
            if (Random.Next(2) == 1)
                return MakeRandomBrick();
            else
                return null;
        }

        private TetrisBrick MakeRandomBrick() {
            TetrisBrick brick = new TetrisBrick { Color = ColorFactory.MakeRandomColor() };
            return brick;
        }
    }
}