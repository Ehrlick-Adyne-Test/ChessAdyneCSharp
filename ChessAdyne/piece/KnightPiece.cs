namespace ChessAdyne {
    class KnightPiece: AbstractChessPiece {
        public KnightPiece() : base(PieceType.Knight) {}
        public override MoveRule[] rulesOfNextMove(int boundary) {
            MoveRule[] rules = {
                new MoveRule(1, 2),
                new MoveRule(1, -2),
                new MoveRule(2, 1),
                new MoveRule(2, -1),
                new MoveRule(-1, 2),
                new MoveRule(-1, -2),
                new MoveRule(-2, 1),
                new MoveRule(-2, -1)
            };
            
            return rules;
        }

        public override bool allowSkip() {
            return true;
        }

        public override string getSymbol() {
            return " K ";
        }

    }
}