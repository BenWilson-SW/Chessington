using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces;

public class PieceHelper
{
    public static IEnumerable<Square> GetAvailableLateralMoves(Player player, Board board, Square from)
    {
        var moves = new List<Square>();

        for (var col = from.Col - 1; col >= 0; col--)
        {
            var move = Square.At(from.Row, col);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }

                break;
            }
            
            moves.Add(move);
        }
            
        for (var col = from.Col + 1; col < 8; col++)
        {
            var move = Square.At(from.Row, col);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }
                
                break;
            }
            
            moves.Add(move);
        }
            
        for (var row = from.Row - 1; row >= 0; row--)
        {
            var move = Square.At(row, from.Col);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }
                
                break;
            }
            
            moves.Add(move);
        }
            
        for (var row = from.Row + 1; row < 8; row++)
        {
            var move = Square.At(row, from.Col);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }
                
                break;
            }
            
            moves.Add(move);
        }

        return moves;        
    }
    
    public static IEnumerable<Square> GetAvailableDiagonalMoves(Player player, Board board, Square from)
    {
        var moves = new List<Square>();
            
        for (int i = 1; i <= Math.Min(7 - from.Row, 7 - from.Col); i++)
        {
            var move = Square.At(from.Row + i, from.Col + i);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }
                
                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(7 - from.Row, from.Col); i++)
        {
            var move = Square.At(from.Row + i, from.Col - i);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }
                
                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(from.Row, from.Col); i++)
        {
            var move = Square.At(from.Row - i, from.Col - i);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }

                break;
            }
            
            moves.Add(move);
        }
            
        for (int i = 1; i <= Math.Min(from.Row, 7 - from.Col); i++)
        {
            var move = Square.At(from.Row - i, from.Col + i);
            var piece = board.GetPiece(move);
            if (piece != null)
            {
                if (piece.Player != player)
                {
                    moves.Add(move);                    
                }

                break;
            }
            
            moves.Add(move);
        }

        return moves;
    }
}