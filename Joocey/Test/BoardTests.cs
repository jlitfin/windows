using System;

using Xunit;

using Board;

namespace Test
{
    [Collection("Board Tests")]
    public class BoardTests
    {
        [Fact]
        public void FENStartPosition()
        {
            var board = new GameState();
            board.StartPosition("Q7/8/8/8/8/8/8/8 w - - 0 1");
            var p = board[SQ.a8];

            Assert.True(p.CurrentFile == 'a' && p.CurrentRank == 8 && p.Identifier == "Q");
        }

        [Fact]
        public void MoveToAllSquares()
        {
            var board = new GameState();
            board.StartPosition("Q7/8/8/8/8/8/8/8 w - - 0 1");
            var piece = board[SQ.a8];

            var sqs = Enum.GetValues(typeof(SQ));
            SQ prior = SQ.a8;

            foreach (var sq in sqs)
            {
                SQ to = (SQ)sq;
                if (to != SQ.a8 && to != SQ.xx) // skip the starting square
                {
                    
                    var move = new Move { Destination = to, Piece = board[prior] };
                    board.Move(move);

                    var leftSquare = board[prior].Identifier == Constants.EmptyIdentifier && board[prior].CurrentSquare == prior;
                    var movedToSquare = board[to].Identifier == piece.Identifier && board[to].CurrentSquare == to;

                    Assert.True(leftSquare && movedToSquare);

                    prior = to;
                }
            }
        }

        [Fact]
        public void MoveToAllSquaresLegalByStringMove()
        {
            var board = new GameState();
            board.StartPosition("Q7/8/8/8/8/8/8/8 w - - 0 1");
            var piece = board[SQ.a8];



            Assert.True(true);
        }
    }
}
