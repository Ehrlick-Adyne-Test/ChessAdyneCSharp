namespace ChessAdyne {
    abstract class AbstractPositionValidator : PositionValidator {
        protected Board board;
        protected Position currentPosition;
        protected Position targetPosition;

        public AbstractPositionValidator (Board _board) {
            this.board = _board;
        }

        public void setCurrentPosition (Position _p) {
            this.currentPosition = _p;
        }

        public void setTargetPosition (Position _p) {
            this.targetPosition = _p;
        }

        protected void checkCurrentPosition() {
            if(this.currentPosition == null) {
                throw new System.Exception("CurrentPosition cannot be null!");
            }
        }

        protected void checkTargetPosition() {
            if(this.targetPosition == null) {
                throw new System.Exception("TargetPosition cannot be null!");
            }
        }

        abstract public bool validate();
    }
}