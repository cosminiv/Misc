﻿using CosminIv.Games.Common;

namespace CosminIv.Games.Tetris
{
    public class TetrisPieceWithPosition
    {
        public TetrisPiece Piece { get; set; }
        public Coordinates Position { get; set; } = new Coordinates(0, 0);

        public void CopyFrom(TetrisPieceWithPosition other) {
            this.Piece.CopyFrom(other.Piece);
            this.Position.CopyFrom(other.Position);
        }
    }
}