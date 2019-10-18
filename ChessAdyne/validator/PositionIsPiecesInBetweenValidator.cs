using System.Collections.Generic;

namespace ChessAdyne {
    class PositionIsPiecesInBetweenValidator : AbstractPositionValidator {
        public PositionIsPiecesInBetweenValidator (Board board) : base (board) { }

        public override bool validate () {
            checkTargetPosition ();
            checkCurrentPosition ();

            if (currentPosition.getPiece ().allowSkip ())
                return true;
            else
                return !isPieceInBetween ();
        }

        private bool isPieceInBetween () {
            int cX = currentPosition.getX () + 1;
            int cY = currentPosition.getY () + 1;
            int tX = targetPosition.getX () + 1;
            int tY = targetPosition.getY () + 1;

            int iX = tX - cX;
            int iY = tY - cY;

            int increX = 0;
            int increY = 0;
            List<Position> ps = new List<Position> ();
            if (System.Math.Abs (iX) == System.Math.Abs (iY)) {
                // diagnostic
                for (int i = 1; i < System.Math.Abs (iX); i++) {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    if (iY > 0) increY = i;
                    else increY = -i;
                    ps.Add (board.selectPosition (cX + increX, cY + increY));
                }
            } else if (iX == 0) {
                // vertical
                for (int i = 1; i < System.Math.Abs (iY); i++) {
                    if (iY > 0) increY = i;
                    else increY = -i;
                    ps.Add (board.selectPosition (cX + increX, cY + increY));
                }
            } else if (iY == 0) {
                // horizontal
                for (int i = 1; i < System.Math.Abs (iX); i++) {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    ps.Add (board.selectPosition (cX + increX, cY + increY));
                }
            } else {
                return false;
            }

            foreach (Position p in ps) {
                if (!p.isEmpty ()) {
                    switch (p.getPiece ().getPieceType ()) {
                        case PieceType.NextMove:
                            continue;
                        default:
                            return true;
                    }
                }

            }

            return false;
        }
    }
}