namespace ChessAdyne {
    class NextMovePiece: AbstractChessPiece {
        public NextMovePiece() : base(PieceType.NextMove) {}

        public override string getSymbol() {
            return " O ";
        }
    }
}