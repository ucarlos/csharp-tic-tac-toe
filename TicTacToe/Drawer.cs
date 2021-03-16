// --------------------------------------------------------------------------------
// Created by Ulysses Carlos on 03/15/2021 at 10:53 PM
// 
// Drawer.cs
// --------------------------------------------------------------------------------

using System;

namespace TicTacToe {
    public class Drawer {
        public static void draw_map(ref Tile[] tile_map) {
            for (int i = 0; i < tile_map.Length; i++) {
                Console.Write($"{tile_map[i].character} | ");
                if ((i + 1) % 3 == 0) {
                    //Console.WriteLine($"\n----------");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}