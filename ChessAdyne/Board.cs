using System;
using System.Collections.Generic;

namespace ChessAdyne {
    class Board {
        private Position[, ] positions;
        private int dimension;

        public Board () : this (8) { }

        public Board (int d) {
            this.dimension = d;
            this.positions = new Position[this.dimension, this.dimension];
            for (int x = 0; x < this.dimension; x++) {
                for (int y = 0; y < this.dimension; y++) {
                    this.positions[x, y] = new Position (null, x, y);
                }
            }
        }

        public Board (Board board) : this (board.dimension) {
            for (int x = 0; x < this.dimension; x++) {
                for (int y = 0; y < this.dimension; y++) {
                    this.positions[x, y] = new Position (board.positions[x, y].getPiece (), x, y);
                }
            }
        }

        public void plot () {
            for (int x = this.dimension - 1; x >= 0; x--) {
                Console.Write (x + 1);
                for (int y = 0; y < this.dimension; y++) {
                    Console.Write ($" + {this.positions[x, y]}");
                }
                Console.WriteLine ("\n");
            }
            Console.Write (" ");
            for (int y = 0; y < this.dimension; y++) {
                Console.Write ($" +  {y + 1} ");
            }
            Console.WriteLine ("\n");
        }

        public void plotOverLayPositions (Position[] overlayPositions) {
            Board tmpBoard = new Board (this);
            foreach (Position p in overlayPositions) {
                tmpBoard.selectPosition (p.getDisplayX (), p.getDisplayY ()).putPiece (p.getPiece ());
            }
            tmpBoard.plot ();
        }

        public int getDimension () {
            return this.dimension;
        }

        public Position selectPosition (int displayX, int displayY) {
            int[] xy = translateXY (displayX, displayY);
            return positions[xy[0], xy[1]];
        }

        public Position[] nextPossiblePositions (Position p) {
            Console.WriteLine ($"-- Plot Possible Next Moves for {p.getPiece ().getPieceType ().ToString ()} ({p.getDisplayX ()} , {p.getDisplayY ()})");
            return validPositions (p);
        }

        private Position[] validPositions (Position currentPos) {
            Position[] ps = currentPos.nextPossiblePositions (this.dimension);

            PositionValidator[] validators = {
                new PositionIsOnBoardValidator (this),
                new PositionIsPiecesInBetweenValidator (this)
            };

            List<Position> validPs = new List<Position> ();
            for (int i = 0; i < ps.Length; i++) {
                Position targetPos = ps[i];

                Boolean validResult = true;
                foreach (PositionValidator validator in validators) {
                    validator.setCurrentPosition (currentPos);
                    validator.setTargetPosition (targetPos);
                    if (!validator.validate ()) {
                        validResult = false;
                        break;
                    }
                }

                if (validResult)
                    validPs.Add (targetPos);
            }

            return validPs.ToArray();
        }

        private int[] translateXY (int displayX, int displayY) {
            int x = displayX - 1;
            int y = displayY - 1;

            PositionValidator validator = new PositionIsOnBoardValidator (this);
            validator.setTargetPosition (new Position (null, x, y));

            if (!validator.validate ())
                throw new SystemException ($"Invalid X/Y: {displayX}/{displayY}");

            int[] r = { x, y };
            return r;
        }
    }
}