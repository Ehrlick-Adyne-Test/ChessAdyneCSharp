namespace ChessAdyne {
    interface PositionValidator {
        bool validate();
        void setCurrentPosition(Position _p);
        void setTargetPosition(Position _p);
    }
}