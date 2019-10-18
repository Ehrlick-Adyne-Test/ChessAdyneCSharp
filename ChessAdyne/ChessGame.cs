using System;

namespace ChessAdyne {
    class ChessGame {
        static void Main (string[] args) {
            printLegned ();

            Console.WriteLine ("-- Preparing Empty ChessBoard");

            Board board = new Board ();
            board.plot ();

            Position selectedPos;

            // board.selectPosition (5, 2).putPiece (new KnightPiece ());
            // board.selectPosition (7, 6).putPiece (new BishopPiece ());

            selectedPos = board.selectPosition (4, 3);
            selectedPos.putPiece (new KnightPiece ());
            board.plotOverLayPositions (board.nextPossiblePositions (selectedPos));

            selectedPos = board.selectPosition (4, 3);
            selectedPos.putPiece (new BishopPiece ());
            board.plotOverLayPositions (board.nextPossiblePositions (selectedPos));
        }

        static void printLegned () {
            Console.WriteLine ("---- Legends ----");
            Console.WriteLine ("[ ] : Black Empty Position");
            Console.WriteLine ("| | : White Empty Position");
            Console.WriteLine (" K  : Knight");
            Console.WriteLine (" B  : Bishop");
            Console.WriteLine (" O  : Next Possible Move");
            Console.WriteLine ("-----------------");
            Console.WriteLine ();
        }
    }
}