namespace ChessAdyne {
    class PositionIsOnBoardValidator : AbstractPositionValidator {
        public PositionIsOnBoardValidator (Board board) : base (board) { }

        public override bool validate () {
            checkTargetPosition ();

            int targetPX = targetPosition.getX ();
            int targetPY = targetPosition.getY ();
            int boardDimention = board.getDimension ();
            if (targetPX < 0 || targetPX >= boardDimention || targetPY < 0 || targetPY >= boardDimention)
                return false;
            else return true;

        }
    }
}