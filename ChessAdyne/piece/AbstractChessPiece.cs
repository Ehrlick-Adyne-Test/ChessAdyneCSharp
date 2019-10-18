namespace ChessAdyne {
    abstract class AbstractChessPiece : ChessPiece {
        private PieceType type;

        public AbstractChessPiece(PieceType _type) {
            this.type = _type;
        }        

        public PieceType getPieceType() {
            return this.type;
        }

        public virtual bool allowSkip() {
            return false;
        }

        public virtual MoveRule[] rulesOfNextMove(int boundary) {
            return new MoveRule[0];
        }

        abstract public string getSymbol();
    }
}