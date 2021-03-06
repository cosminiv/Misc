﻿using ConsoleApp1.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppliedAlgorithms.PathFinding
{
    class GeometricPathAStar
    {
        static string TerrainStr =
@"
.................■.................■................................■............................■.................■................................■...........
.................■.................■................................■............................■..................................................■...........
......■.........■■........■.......■■.........■...........■.........■■........■........■.........■■........■.......■■.........■...........■.........■■........■..
.■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■...■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■..
.■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■....■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■...
..■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■......■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■....
..■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.......■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.....
.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■
...■■■..■■...■....■■........■■......■■....■■■..■■...■.■■■..■■...■....■■........■...■■■..■■...■....■■........■■......■■....■■■..■■...■.■■■..■■...■....■■........■
...■..............■.................■.....■...........■..............■.............■................................■.....■...........■..............■..........
...■.■■..........■■................■■.....■.■■........■.■■..........■■.............■.■■..........■■................■■.....■.■■........■.■■..........■■..........
......■..........■.................■.........■...........■..........■.................■..........■.................■.........■...........■..........■...........
......■.........■■........■.......■■.........■...........■.........■■........■........■.........■■........■.......■■.........■...........■.........■■........■..
.■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■...■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■..
.■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■....■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■...
..■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■......■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■....
..■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.......■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.....
.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■
........■■...■....■■........■■......■■.........■■...■......■■...■....■■........■........■■...■....■■........■■......■■.........■■...■......■■...■....■■........■
.................■■................■■...............................■■...........................■■................■■................................■..........
.................■..................................................■............................■.................■................................■...........
.................■.................■................................■............................■.................■................................■...........
......■.........■■........■.......■■.........■...........■.........■■........■........■.........■■........■.......■■.........■...........■.........■■........■..
.■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■...■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■..
.■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■....■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■...
..■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■......■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■....
..■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.......■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.....
.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■
...■■■..■■...■....■■........■■......■■....■■■..■■...■.■■■..■■...■....■■........■...■■■..■■...■....■■........■■......■■....■■■..■■...■.■■■..■■...■....■■........■
...■..............■.................■.....■...........■..............■.............■..............■.................■.....■...........■..............■..........
...■.■■..........■■................■■.....■.■■........■.■■.........■■■.............■.■■.........■■■................■■.....■.■■........■.■■..........■■..........
......■..........■..........................■...........■..........■.................■..........■.................■.........■...........■..........■............
......■.........■■........■.......■■.........■...........■.........■■........■........■.........■■........■.......■■.........■...........■.........■■........■..
.■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■...■...■■....■...■■....■...■■....■.■■....■....■■....■.....■■....■...■■....■...■■..
.■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■....■■.■■.....■■.■■.....■■.■■.....■■■.....■■..■■.....■■.■.■■.....■■.■■.....■■.■■...
..■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■......■■■.......■■■.■■■...■■■.......■.■■■...■■■■.......■■■■■.......■■■.■■■...■■■....
..■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.......■■........■■....■...■■........■...■...■■■........■■.■........■■....■...■■.....
.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■.......■■....■...■■........■■......■■.........■■....■.....■■....■...■■........■■
........■■...■....■■........■■......■■.........■■...■......■■...■....■■........■........■■...■....■■........■■......■■.........■■...■......■■...■....■■........■
..................■.................■................................■............................■.................■................................■..........
";

        public static void Solve() {
            int cols = 160;
            int rows = 40;

            GeometricPathTestCase tc = new GeometricPathTestCase(TerrainStr, new Coords(0, 0), new Coords(rows-1, cols-1));
            List<GeometricPathAStarNode> path = new AStar().FindShortestPath(new GeometricPathAStarNode(tc))
                .Select(n => n as GeometricPathAStarNode).ToList();

            string result = DrawPathOnTerrain(TerrainStr, path, cols, rows);
            Console.WriteLine(result);
            File.WriteAllText(@"C:\Temp\Maze.txt", result);
        }

        private static string DrawPathOnTerrain(string terrain, List<GeometricPathAStarNode> path, int cols, int rows) {
            StringBuilder sb = new StringBuilder(terrain.Replace(" ", "").Replace(Environment.NewLine, ""));

            foreach (GeometricPathAStarNode node in path) {
                sb[node.Coords.Row * cols + node.Coords.Column] = 'o';
            }

            for (int i = rows - 1; i > 0 ; i--) {
                sb.Insert(i * cols, Environment.NewLine);
            }

            sb.Replace(".", " ");
            //sb.Replace(".", ". ").Replace("■", "■ ").Replace("o", "o ").Replace(".", " ");
            return sb.ToString();
        }

    }
}
