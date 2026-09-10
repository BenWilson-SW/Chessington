using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var bishop = board.FindPiece(this);
            
            for (int i = 1; i <= Math.Min(7 - bishop.Row, 7 - bishop.Col); i++)
            {
                moves.Add(Square.At(bishop.Row + i, bishop.Col + i));
            }
            
            for (int i = 1; i <= Math.Min(7 - bishop.Row, bishop.Col); i++)
            {
                moves.Add(Square.At(bishop.Row + i, bishop.Col - i));
            }
            
            for (int i = 1; i <= Math.Min(bishop.Row, bishop.Col); i++)
            {
                moves.Add(Square.At(bishop.Row - i, bishop.Col - i));
            }
            
            for (int i = 1; i <= Math.Min(bishop.Row, 7 - bishop.Col); i++)
            {
                moves.Add(Square.At(bishop.Row - i, bishop.Col + i));
            }

            return moves;
        }
    }
}