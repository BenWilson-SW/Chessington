using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            IEnumerable<Square> moves = new List<Square>();
            var queen = board.FindPiece(this);
            
            moves = moves.Concat(PieceHelper.GetAvailableLateralMoves(board, queen));
            moves = moves.Concat(PieceHelper.GetAvailableDiagonalMoves(queen));
            
            return moves;
        }
    }
}