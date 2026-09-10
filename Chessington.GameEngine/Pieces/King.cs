using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        private readonly (int, int)[] kingMoveOffsets =
        [
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
            (1, 1),
            (-1, -1),
            (1, -1),
            (-1, 1)
        ];
        
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var king = board.FindPiece(this);

            foreach (var (row, col) in kingMoveOffsets)
            {
                moves.Add(Square.At(king.Row + row, king.Col + col));
            }
            
            return moves;
        }
    }
}