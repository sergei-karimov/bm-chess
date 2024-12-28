using System.Diagnostics;

namespace Chess {
    public static class Piece {
        public const int None = 0;
        public const int King = 1;
        public const int Pawn = 2;
        public const int Knight = 3;
        public const int Bishop = 4;
        public const int Rook = 5;
        public const int Queen = 6;
        
        public const int White = 8;
        public const int Black = 16;
        
        private const int TypeMask = 0b00111;
        private const int BlackMask = 0b10000;
        private const int WhiteMask = 0b01000;
        private const int ColourMask = WhiteMask | BlackMask;

        public static int getType(int piece) {
            return piece & TypeMask;
        }

        public static int getColor(int piece) {
            return piece & ColourMask;
        }
    }
}