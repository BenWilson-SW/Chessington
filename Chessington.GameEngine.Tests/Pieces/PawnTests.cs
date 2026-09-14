using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class PawnTests
    {
        [Test]
        public void WhitePawns_CanMoveOneSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 0));
        }

        [Test]
        public void BlackPawns_CanMoveOneSquareDown()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(1, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 0));
        }

        [Test]
        public void WhitePawns_WhichHaveNeverMoved_CanMoveTwoSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 5), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 5));
        }

        [Test]
        public void BlackPawns_WhichHaveNeverMoved_CanMoveTwoSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(1, 3), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
        }

        [Test]
        public void WhitePawns_WhichHaveAlreadyMoved_CanOnlyMoveOneSquare()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 2), pawn);

            pawn.MoveTo(board, Square.At(5, 2));
            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(1);
            moves.Should().Contain(square => square.Equals(Square.At(4, 2)));
        }

        [Test]
        public void BlackPawns_WhichHaveAlreadyMoved_CanOnlyMoveOneSquare()
        {
            var board = new Board(Player.Black);
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(5, 2), pawn);

            pawn.MoveTo(board, Square.At(6, 2));
            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(1);
            moves.Should().Contain(square => square.Equals(Square.At(7, 2)));
        }

        [Test]
        public void Pawns_CannotMove_IfThereIsAPieceInFront()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            var blockingPiece = new Rook(Player.White);
            board.AddPiece(Square.At(1, 3), pawn);
            board.AddPiece(Square.At(2, 3), blockingPiece);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().BeEmpty();
        }

        [Test]
        public void Pawns_CannotMoveTwoSquares_IfThereIsAPieceTwoSquaresInFront()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            var blockingPiece = new Rook(Player.White);
            board.AddPiece(Square.At(1, 3), pawn);
            board.AddPiece(Square.At(3, 3), blockingPiece);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(3, 3));
        }

        [Test]
        public void WhitePawns_CannotMove_AtTheTopOfTheBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(0, 3), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().BeEmpty();
        }

        [Test]
        public void BlackPawns_CannotMove_AtTheBottomOfTheBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(7, 3), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().BeEmpty();
        }

        [Test]
        public void BlackPawns_CanMoveDiagonally_IfThereIsAPieceToTake()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            var firstTarget = new Pawn(Player.White);
            var secondTarget = new Pawn(Player.White);
            board.AddPiece(Square.At(5, 3), pawn);
            board.AddPiece(Square.At(6, 4), firstTarget);
            board.AddPiece(Square.At(6, 2), secondTarget);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(6, 4));
        }

        [Test]
        public void WhitePawns_CanMoveDiagonally_IfThereIsAPieceToTake()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            var firstTarget = new Pawn(Player.Black);
            var secondTarget = new Pawn(Player.Black);
            board.AddPiece(Square.At(7, 3), pawn);
            board.AddPiece(Square.At(6, 4), firstTarget);
            board.AddPiece(Square.At(6, 2), secondTarget);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(6, 4));
        }

        [Test]
        public void BlackPawns_CannotMoveDiagonally_IfThereIsNoPieceToTake()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(5, 3), pawn);

            var friendlyPiece = new Pawn(Player.Black);
            board.AddPiece(Square.At(6, 2), friendlyPiece);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(6, 2));
            moves.Should().NotContain(Square.At(6, 4));
        }

        [Test]
        public void WhitePawns_CannotMoveDiagonally_IfThereIsNoPieceToTake()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(7, 3), pawn);

            var friendlyPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 2), friendlyPiece);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(6, 2));
            moves.Should().NotContain(Square.At(6, 4));
        }

        [Test]
        public void WhitePawns_CanMoveDiagonally_ViaEnPassant()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 3), whitePawn);
            board.AddPiece(Square.At(1, 4), blackPawn);

            blackPawn.MoveTo(board, Square.At(3, 4));
            var moves = whitePawn.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(2, 4));
        }

        [Test]
        public void BlackPawns_CanMoveDiagonally_ViaEnPassant()
        {
            var board = new Board(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var whitePawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 3), blackPawn);
            board.AddPiece(Square.At(6, 4), whitePawn);

            whitePawn.MoveTo(board, Square.At(4, 4));
            var moves = blackPawn.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(5, 4));
        }

        [Test]
        public void WhitePawns_CannotMoveDiagonally_ViaEnPassant_IfNoAdjacentPawn()
        {
            var board = new Board();
            var whitePawn = new Pawn(Player.White);
            board.AddPiece(Square.At(3, 3), whitePawn);

            var moves = whitePawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(2, 2));
            moves.Should().NotContain(Square.At(2, 4));
        }

        [Test]
        public void BlackPawns_CannotMoveDiagonally_ViaEnPassant_IfNoAdjacentPawn()
        {
            var board = new Board();
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 3), blackPawn);

            var moves = blackPawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(5, 2));
            moves.Should().NotContain(Square.At(5, 4));
        }

        [Test]
        public void WhitePawns_CannotMoveDiagonally_ViaEnPassant_IfAdjacentPawnDidNotMove()
        {
            var board = new Board();
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 3), whitePawn);
            board.AddPiece(Square.At(3, 4), blackPawn);

            var moves = whitePawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(2, 4));
        }

        [Test]
        public void BlackPawns_CannotMoveDiagonally_ViaEnPassant_IfAdjacentPawnDidNotMove()
        {
            var board = new Board();
            var blackPawn = new Pawn(Player.Black);
            var whitePawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 3), blackPawn);
            board.AddPiece(Square.At(4, 4), whitePawn);

            var moves = blackPawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(5, 4));
        }

        [Test]
        public void WhitePawns_CannotMoveDiagonally_ViaEnPassant_IfAdjacentPawnOnlyMovedOneSquare()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 3), whitePawn);
            board.AddPiece(Square.At(2, 4), blackPawn);

            blackPawn.MoveTo(board, Square.At(3, 4));
            var moves = whitePawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(2, 4));
        }

        [Test]
        public void BlackPawns_CannotMoveDiagonally_ViaEnPassant_IfAdjacentPawnOnlyMovedOneSquare()
        {
            var board = new Board(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var whitePawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 3), blackPawn);
            board.AddPiece(Square.At(5, 4), whitePawn);

            whitePawn.MoveTo(board, Square.At(4, 4));
            var moves = blackPawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(5, 4));
        }

        [Test]
        public void WhitePawns_CannotMoveDiagonally_ViaEnPassant_IfOpportunityNotTakenImmediately()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var whiteRook = new Rook(Player.White);
            var blackRook = new Rook(Player.Black);
            board.AddPiece(Square.At(3, 3), whitePawn);
            board.AddPiece(Square.At(1, 4), blackPawn);
            board.AddPiece(Square.At(7, 0), whiteRook);
            board.AddPiece(Square.At(0, 0), blackRook);

            blackPawn.MoveTo(board, Square.At(3, 4));
            whiteRook.MoveTo(board, Square.At(6, 0));
            blackRook.MoveTo(board, Square.At(1, 0));

            var moves = whitePawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(2, 4));
        }

        [Test]
        public void BlackPawns_CannotMoveDiagonally_ViaEnPassant_IfOpportunityNotTakenImmediately()
        {
            var board = new Board(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackRook = new Rook(Player.Black);
            var whiteRook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 3), blackPawn);
            board.AddPiece(Square.At(6, 4), whitePawn);
            board.AddPiece(Square.At(0, 0), blackRook);
            board.AddPiece(Square.At(7, 0), whiteRook);

            whitePawn.MoveTo(board, Square.At(4, 4));
            blackRook.MoveTo(board, Square.At(1, 0));
            whiteRook.MoveTo(board, Square.At(6, 0));

            var moves = blackPawn.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(5, 4));
        }
    }
}