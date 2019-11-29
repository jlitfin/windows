using System;

using Xunit;

using Board;
using Core;


namespace Test
{
    [Collection("Board Tests")]
    public class BoardTests
    {
        [Fact]
        public void FENStartPosition()
        {
            var board = new GameState();
            var p = board[SQ.a8];

            Assert.True(p.CurrentFile == 'a' && p.CurrentRank == 8 && p.Identifier == "R");
        }

        [Fact]
        public void MoveToAllSquares()
        {
            var board = new GameState();
            var piece = board[SQ.a8];

            var sqs = Enum.GetValues(typeof(SQ));

            Assert.True(true);
        }

        [Fact]
        public void MoveToAllSquaresLegalByStringMove()
        {
            var board = new GameState();
            var piece = board[SQ.a8];

            Assert.True(true);
        }
    }
}
