using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var rook = board.FindPiece(this);

            for (int col = 0; col < rook.Col; col++)
            {
                moves.Add(Square.At(rook.Row, col));
            }
            
            for (int col = rook.Col + 1; col < 8; col++)
            {
                moves.Add(Square.At(rook.Row, col));
            }
            
            for (int row = 0; row < rook.Row; row++)
            {
                moves.Add(Square.At(row, rook.Col));
            }
            
            for (int row = rook.Row + 1; row < 8; row++)
            {
                moves.Add(Square.At(row, rook.Col));
            }

            return moves;
        }
    }
}