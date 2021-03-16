// --------------------------------------------------------------------------------
// Created by Ulysses Carlos on 03/15/2021 at 10:53 PM
// 
// Player.cs
// --------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Player {
        public char player_character { get; set; } = '✠';

        // Each player has a set which determines whether the player has won the game or not.
        private SortedSet<int> tile_list;

        // Default Constructor
        public Player() { }

        public Player(char ch) {
            player_character = ch;
            this.tile_list = new SortedSet<int>();
        }

        public Player(char ch, SortedSet<int> tile_list) {
            player_character = ch;
            // Call its copy constructor I guess because C# doesn't 
            // have a copy assignment operator.
            this.tile_list = new SortedSet<int>(tile_list);
        }


        // Insert a tile index into the set
        public void push_back_index(int index) {
            tile_list.Add(index);
        }

        public bool check_winning_condition() {
            return check_vertical() || check_horizontal() || check_diagonal();
        }

        /// <summary>
        /// Check if the player has three tiles in a horizontal row.
        /// </summary>
        /// <returns>An boolean</returns>
        private bool check_horizontal() {
            int occurances = 1;
            int check = tile_list.ElementAt(0);
            for (int i = 1; i < tile_list.Count; i++) {
                int temp = tile_list.ElementAt(i);
                if (temp == (check + 1)) {
                    occurances++;
                    if (occurances == 3) return true;
                }
                else
                    occurances = 1;

                check = temp;
            }

            return false;
        }

        /// <summary>
        /// Check if the player has three tiles in a vertical row.
        /// </summary>
        /// <returns></returns>
        private bool check_vertical() {
            for (int i = 0; i < 3; i++) {
                var check = tile_list.Contains(i);
                if (!check) continue;

                // Now check if the tile list contains all other tiles in the same column.
                var check1 = tile_list.Contains(i + 3);
                var check2 = tile_list.Contains(i + 6);
                if (check1 && check2) return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the player has three tiles diagonally (whether left or right)
        /// </summary>
        /// <returns></returns>
        private bool check_diagonal() {
            // Check whether the middle index 5 exists in the set. if not, return false;
            bool check_middle = tile_list.Contains(5);
            if (!check_middle) return false;

            // Left Diagonal
            // Does 1, 5, and 9 exist in the set?
            bool check_left = tile_list.Contains(1) && tile_list.Contains(9);

            // Right Diagonal
            // Does 3, 5, 7 exist in the set?
            bool check_right = tile_list.Contains(3) && tile_list.Contains(7);

            return (check_left || check_right);
        }
    }
}