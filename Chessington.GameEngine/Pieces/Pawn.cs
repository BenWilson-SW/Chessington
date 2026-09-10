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

            var direction = Player == Player.White ? -1 : 1;
            var startRow = Player == Player.White ? 6 : 1;

            var move = Square.At(pawn.Row + direction, pawn.Col);
            
            if (!board.InBounds(move) || board.GetPiece(move) != null)
            {
                return moves;
            }
            
            moves.Add(move);

            if (pawn.Row != startRow)
            {
                return moves;
            }
            
            move = Square.At(pawn.Row + 2 * direction, pawn.Col);
            
            if (!board.InBounds(move) || board.GetPiece(move) != null)
            {
                return moves;
            }
            
            moves.Add(move);
            return moves;
        }
    }
}