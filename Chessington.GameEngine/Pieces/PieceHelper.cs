using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class PieceHelper
{
    private static IEnumerable<Square> ValidSlidingMoves(Player player, Board board, IEnumerable<Square> allMoves)
    {
        foreach (var move in allMoves)
        {
            var piece = board.GetPiece(move);

            if (piece == null)
            {
                yield return move;
            }
            else
            {
                if (piece.Player != player)
                {
                    yield return move;
                }
                
                yield break;
            }
        }
    }
    
    public static IEnumerable<Square> GetAvailableLateralMoves(Player player, Board board, Square from)
    {
        var moves = new List<Square>();

        moves.AddRange(ValidSlidingMoves(
                player, board,
                Enumerable.Range(0, from.Col)
                    .Reverse()
                    .Select(col => Square.At(from.Row, col))
            ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(from.Col + 1, 7 - from.Col)
                .Select(col => Square.At(from.Row, col))
        ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(0, from.Row)
                .Reverse()
                .Select(row => Square.At(row, from.Col))
        ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(from.Row + 1, 7 - from.Row)
                .Select(row => Square.At(row, from.Col))
        ));

        return moves;        
    }
    
    public static IEnumerable<Square> GetAvailableDiagonalMoves(Player player, Board board, Square from)
    {
        var moves = new List<Square>();
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(1, Math.Min(7 - from.Row, 7 - from.Col))
                .Select(i => Square.At(from.Row + i, from.Col + i))
        ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(1, Math.Min(7 - from.Row, from.Col))
                .Select(i => Square.At(from.Row + i, from.Col - i))
        ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(1, Math.Min(from.Row, from.Col))
                .Select(i => Square.At(from.Row - i, from.Col - i))
        ));
        
        moves.AddRange(ValidSlidingMoves(
            player, board,
            Enumerable.Range(1, Math.Min(from.Row, 7 - from.Col))
                .Select(i => Square.At(from.Row - i, from.Col + i))
        ));

        return moves;
    }
}