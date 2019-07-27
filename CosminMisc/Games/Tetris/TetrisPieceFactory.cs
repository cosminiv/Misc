﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CosminIv.Games.Tetris
{
    public class TetrisPieceFactory
    {
        static TetrisPiece[] _prototypePieces = MakePrototypePieces();
        static Random _random = new Random();

        public TetrisPiece MakePiece() {
            int prototypePieceIndex = _random.Next(_prototypePieces.Length);
            TetrisPiece prototypePiece = _prototypePieces[prototypePieceIndex];
            TetrisPiece piece = new TetrisPiece(prototypePiece.MaxSize);
            piece.CopyFrom(prototypePiece);
            return piece;
        }

        private static TetrisPiece[] MakePrototypePieces() {
            TetrisPiece[] result = new[] {
                MakePrototypePiece1(),
                MakePrototypePiece2(),
                MakePrototypePiece3(),
                MakePrototypePiece4(),
                MakePrototypePiece5(),
                MakePrototypePiece6(),
                MakePrototypePiece7(),

                MakePrototypePiece8(),
                MakePrototypePiece9(),
                MakePrototypePiece10(),
                MakePrototypePiece11(),
                MakePrototypePiece12(),
                MakePrototypePiece13(),
            };
            return result;
        }

        private static TetrisPiece MakePieceFromBrickCoordinates(int size, (int, int)[] brickCoords) {
            TetrisPiece result = new TetrisPiece(size);
            foreach ((int, int) position in brickCoords) {
                result[position.Item1, position.Item2] = new TetrisBrick();
            }
            return result;
        }

        private static TetrisPiece MakePrototypePiece1() {
            // ****
            (int, int)[] brickCoords = (new[] { (1, 0), (1, 1), (1, 2), (1, 3) });
            return MakePieceFromBrickCoordinates(4, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece2() {
            // ***
            // *
            (int, int)[] brickCoords = (new[] { (1, 0), (1, 1), (1, 2), (2, 0) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece3() {
            // ***
            //   *
            (int, int)[] brickCoords = (new[] { (1, 0), (1, 1), (1, 2), (2, 2) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece4() {
            // ***
            //  *
            (int, int)[] brickCoords = (new[] { (1, 0), (1, 1), (1, 2), (2, 1) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece5() {
            // **
            //  **
            (int, int)[] brickCoords = (new[] { (1, 0), (1, 1), (2, 1), (2, 2) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece6() {
            //  **
            // **
            (int, int)[] brickCoords = (new[] { (1, 1), (1, 2), (2, 0), (2, 1) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece7() {
            // **
            // **
            (int, int)[] brickCoords = (new[] { (0, 0), (0, 1), (1, 0), (1, 1) });
            return MakePieceFromBrickCoordinates(2, brickCoords);
        }



        private static TetrisPiece MakePrototypePiece8() {
            //  *
            // ***
            (int, int)[] brickCoords = (new[] { (0, 1), (1, 0), (1, 1), (1, 2) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece9() {
            // *
            // ***
            (int, int)[] brickCoords = (new[] { (0, 0), (1, 0), (1, 1), (1, 2) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece10() {
            //   *
            // ***
            (int, int)[] brickCoords = (new[] { (0, 2), (1, 0), (1, 1), (1, 2) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece11() {
            //  *
            // **
            // *
            (int, int)[] brickCoords = (new[] { (0, 1), (1, 0), (1, 1), (2, 0) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece12() {
            // *
            // **
            //  *  
            (int, int)[] brickCoords = (new[] { (0, 0), (1, 0), (1, 1), (2, 1) });
            return MakePieceFromBrickCoordinates(3, brickCoords);
        }

        private static TetrisPiece MakePrototypePiece13() {
            // *
            // *
            // *
            // *
            (int, int)[] brickCoords = (new[] { (0, 0), (1, 0), (2, 0), (3, 0) });
            return MakePieceFromBrickCoordinates(4, brickCoords);
        }
    }
}
