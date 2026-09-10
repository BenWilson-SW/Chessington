using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var pawn = board.FindPiece(this);

            switch (Player)
            {
                case Player.White:
                    moves.Add(Square.At(pawn.Row - 1, pawn.Col));
                    break;
                case Player.Black:
                    moves.Add(Square.At(pawn.Row + 1, pawn.Col));
                    break;
            }
            
            switch (Player)
            {
                case Player.White:
                    if (pawn.Row == 7)
                        moves.Add(Square.At(pawn.Row - 2, pawn.Col));
                    break;
                case Player.Black:
                    if (pawn.Row == 1)
                        moves.Add(Square.At(pawn.Row + 2, pawn.Col));
                    break;
            }

            return moves;
        }
    }
}