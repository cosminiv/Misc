﻿using System;
using System.Diagnostics;
using System.Timers;

namespace Games.Tetris
{
    public class TetrisEngine
    {
        int _speed;

        public int Rows { get; }
        public int Cols { get; }
        public int Speed {
            get { return _speed; }
            private set { _speed = Math.Min(value, MaxSpeed); }
        }
        public int Score { get; private set; }

        TetrisPieceFactory PieceFactory;
        TetrisPiece CurrentPiece;
        TetrisFixedBricks FixedBricks;
        Timer Timer;
        readonly int MaxSpeed = 10;

        public TetrisEngine() {
            Rows = 20;
            Cols = 10;
            Speed = 1;
            Score = 0;
            PieceFactory = new TetrisPieceFactory();
            CurrentPiece = PieceFactory.MakePiece();
            Timer = MakeTimer();
            FixedBricks = new TetrisFixedBricks();
        }

        private Timer MakeTimer() {
            Timer timer = new Timer(ComputeTimerInterval(Speed));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            return timer;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Debug.WriteLine($"Timer elapsed; time = {DateTime.Now.Second}.{DateTime.Now.Millisecond}");

        }

        double ComputeTimerInterval(int speed) {
            return 1000 * (1 - (Speed - 1) * 0.1);
        }

        //Methods
        //    MoveLeft
        //    MoveRight
        //    MoveDown
        //    Rotate

        //Events
        //    PieceChange
        //    PieceAppear
        //    ScoreChange
        //    LinesCollapse
        //    GameEnd
    }
}