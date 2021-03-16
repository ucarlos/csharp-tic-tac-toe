/*
 * -----------------------------------------------------------------------------
 * Created by Ulysses Carlos on 03/15/2021 at 10:15 PM
 * 
 * Main.cs
 * Tic-Tac-Toe. Create a Tic-Tac-Toe game that meets the requirements listed
 * in this section. You should spend a minimum of 20 minutes on this problem
 * (no matter how stuck you get). This is a much bigger problem than any other
 * Try It Out! so far, so plan on it taking more time. If you find yourself
 * stuck beyond recovery, read ahead and see if part or all of my solution
 * can help you get unstuck enough to continue on.
 * -----------------------------------------------------------------------------
 */

using System;


namespace TicTacToe {
    public class Program {
        
        /// <summary>
        /// Handle a player's turn.
        /// </summary>
        /// <param name="tile_map">A array of Tiles</param>
        /// <param name="player">An object of type Player that represents a single player.</param>
        public static void player_turn(ref Tile[] tile_map, ref Player player) {
            Drawer.draw_map(ref tile_map);
            Console.WriteLine($"It is Player {player.player_character}'s turn.");
            Console.WriteLine("Please choose an index between 1 to 9.");
            
        Start:   
            
            int index = Convert.ToInt32(Console.ReadLine());
            
            while (!(1 <= index && index <= 9)) {
                Console.WriteLine("Invalid Input. Please input a value between 1 and 9.");
                index = Convert.ToInt32(Console.ReadLine());
            }
            
            // Now check if the index is empty or not.
            bool check_index = tile_map[index - 1].is_empty();
            if (!check_index) {
                Console.WriteLine($"The tile at index {index} has already been marked. Please choose another tile.");
                goto Start;
            }
            
            // If everything went well, now mark the tile and check the winning conditions.
            tile_map[index - 1].marked = true;
            tile_map[index - 1].character = player.player_character;
            player.push_back_index(index);
            
            bool check_win = player.check_winning_condition();
            if (check_win) {
                Drawer.draw_map(ref tile_map);
                Console.WriteLine($"Player {player.player_character} has WON!");
                Environment.Exit(0);
            }
            
            // Now check if the game ended in a draw:
            bool check_draw = map_is_full(ref tile_map);
            if (!check_draw) return;
            Drawer.draw_map(ref tile_map);
            Console.WriteLine("This game has ended in a draw.");
            Environment.Exit(0);
            
        }

        public static bool map_is_full(ref Tile[] Tile_Map) {
            int count = 0;
            foreach (var i in Tile_Map) {
                if (i.marked) count++;
            }
            return (count == Tile_Map.Length);
        }
        
        public static void Main(string[] args) {
            Player player1 = new Player('@');
            Player player2 = new Player('$');
            Drawer drawer = new Drawer();
            
            Tile[] Tile_Map = new Tile[9];
            // Now call the constructor for each index:
            for (int i = 0; i < Tile_Map.Length; i++)
                Tile_Map[i] = new Tile();
            
            //Console.WriteLine("Drawing Map:");
            while (true) {
                player_turn(ref Tile_Map, ref player1);
                player_turn(ref Tile_Map, ref player2);
            }
        }
    }
}