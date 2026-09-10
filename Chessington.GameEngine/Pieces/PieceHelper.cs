using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces;

public class PieceHelper
{
    public static IEnumerable<Square> GetAvailableLateralMoves(Board board, Square from)
    {
        var moves = new List<Square>();

        for (int col = 0; col < from.Col; col++)
        {
            var move = Square.At(from.Row, col);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int col = from.Col + 1; col < 8; col++)
        {
            var move = Square.At(from.Row, col);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int row = 0; row < from.Row; row++)
        {
            var move = Square.At(row, from.Col);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int row = from.Row + 1; row < 8; row++)
        {
            var move = Square.At(row, from.Col);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }

        return moves;        
    }
    
    public static IEnumerable<Square> GetAvailableDiagonalMoves(Board board, Square from)
    {
        var moves = new List<Square>();
            
        for (int i = 1; i <= Math.Min(7 - from.Row, 7 - from.Col); i++)
        {
            var move = Square.At(from.Row + i, from.Col + i);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(7 - from.Row, from.Col); i++)
        {
            var move = Square.At(from.Row + i, from.Col - i);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(from.Row, from.Col); i++)
        {
            var move = Square.At(from.Row - i, from.Col - i);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(from.Row, 7 - from.Col); i++)
        {
            var move = Square.At(from.Row - i, from.Col + i);
            if (board.GetPiece(move) != null)
            {
                break;
            }
            
            moves.Add(move);
        }

        return moves;
    }
}