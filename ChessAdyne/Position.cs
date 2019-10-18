using System;

namespace ChessAdyne {
    class Position {
        private int x;
        private int y;
        private PositionColor color;
        private ChessPiece piece;

        public Position (ChessPiece _piece, int _x, int _y) {
            this.piece = _piece;
            this.x = _x;
            this.y = _y;
            this.color = currentPositionColor (_x, _y);
        }

        public int getX () {
            return this.x;
        }

        public int getY () {
            return this.y;
        }

        public int getDisplayX () {
            return this.x + 1;
        }

        public int getDisplayY () {
            return this.y + 1;
        }

        public ChessPiece getPiece () {
            return this.piece;
        }

        private PositionColor currentPositionColor (int x_, int y_) {
            if (((x_ + 1) + (y_ + 1)) % 2 == 0) return PositionColor.Black;
            else return PositionColor.White;
        }

        public bool isEmpty () {
            if (piece == null) return true;
            else return false;
        }

        public void putPiece (ChessPiece piece) {
            Console.WriteLine ($"-- Put a {piece.getPieceType().ToString()} at ({x} , {y})");
            this.piece = piece;
        }

        public override String ToString () {
            if (isEmpty ()) {
                switch (color) {
                    case PositionColor.White:
                        return "| |";
                    case PositionColor.Black:
                        return "[ ]";
                    default:
                        throw new SystemException ($"Unexpected PositionColor: {color}");
                }
            } else {
                return this.getPiece().getSymbol ();
            }
        }

        public Position[] nextPossiblePositions (int boundary) {
            MoveRule[] rules = piece.rulesOfNextMove (boundary);

            // Generate possible Positions
            Position[] pps = new Position[rules.Length];
            for (int i = 0; i < rules.Length; i++) {
                MoveRule rule = rules[i];
                int newX = this.x + rule.getXStep ();
                int newY = this.y + rule.getYStep ();
                pps[i] = new Position (new NextMovePiece(), newX, newY);
            }

            return pps;
        }

    }
}