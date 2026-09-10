using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces;

public class PieceHelper
{
    public static IEnumerable<Square> GetAvailableLateralMoves(Square from)
    {
        var moves = new List<Square>();

        for (int col = 0; col < from.Col; col++)
        {
            moves.Add(Square.At(from.Row, col));
        }
            
        for (int col = from.Col + 1; col < 8; col++)
        {
            moves.Add(Square.At(from.Row, col));
        }
            
        for (int row = 0; row < from.Row; row++)
        {
            moves.Add(Square.At(row, from.Col));
        }
            
        for (int row = from.Row + 1; row < 8; row++)
        {
            moves.Add(Square.At(row, from.Col));
        }

        return moves;        
    }
    
    public static IEnumerable<Square> GetAvailableDiagonalMoves(Square from)
    {
        var moves = new List<Square>();
            
        for (int i = 1; i <= Math.Min(7 - from.Row, 7 - from.Col); i++)
        {
            moves.Add(Square.At(from.Row + i, from.Col + i));
        }
            
        for (int i = 1; i <= Math.Min(7 - from.Row, from.Col); i++)
        {
            moves.Add(Square.At(from.Row + i, from.Col - i));
        }
            
        for (int i = 1; i <= Math.Min(from.Row, from.Col); i++)
        {
            moves.Add(Square.At(from.Row - i, from.Col - i));
        }
            
        for (int i = 1; i <= Math.Min(from.Row, 7 - from.Col); i++)
        {
            moves.Add(Square.At(from.Row - i, from.Col + i));
        }

        return moves;
    }
}