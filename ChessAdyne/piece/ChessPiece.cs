namespace ChessAdyne {
    interface ChessPiece {
        PieceType getPieceType();
        MoveRule[] rulesOfNextMove(int boundary);
        bool allowSkip();
        string getSymbol();
    }
}