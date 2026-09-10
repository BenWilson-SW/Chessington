using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        private readonly (int, int)[] knightMoveOffsets =
        [
            (1, 2),
            (2, 1),
            (-1, 2),
            (-2, 1),
            (1, -2),
            (2, -1),
            (-1, -2),
            (-2, -1)
        ];
        
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var knight = board.FindPiece(this);
            
            foreach (var (rows, cols) in knightMoveOffsets)
            {
                var move = Square.At(knight.Row + rows, knight.Col + cols);

                if (!board.InBounds(move))
                {
                    continue;
                }

                var piece = board.GetPiece(move);

                if (piece != null && piece.Player == Player)
                {
                    continue;
                }
                
                moves.Add(move);
            }
            
            return moves;
        }
    }
}