// --------------------------------------------------------------------------------
// Created by Ulysses Carlos on 03/15/2021 at 10:37 PM
// 
// Tile.cs
// --------------------------------------------------------------------------------

namespace TicTacToe {
    public class Tile {
        // Defining default values
        public bool marked {get; set;} = false;
        public char character {get; set;} = '☻';

        public bool is_empty() { return marked == false;}
        public bool is_full() { return marked == true; }
        public bool is_character(char ch) { return character == ch; }

        public Tile() {
            marked = false;
            character = '☻';
        }

        public Tile(char ch) {
            marked = false;
            character = ch;
        }

        public Tile(char ch, bool mark_status) {
            marked = mark_status;
            character = ch;
        }

    }
}