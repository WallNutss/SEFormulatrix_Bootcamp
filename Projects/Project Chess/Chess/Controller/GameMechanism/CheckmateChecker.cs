using System;
using Chess.Boards;
using Chess.GameControl;
using Chess.Pieces;
using Chess.Players;

namespace Chess.GameControl.GameMechanism;

public class CheckmateManager{
    public IEnumerable<Coordinate> UtilitiesKingCheckGeneralStatus(GameController control){
        foreach (var player in control.GetPlayersFromList()){
            foreach (var coordinate in control.UtilitiesKingCheckStatus(player)){
                yield return coordinate;
            }
        }
    }

    public IEnumerable<Coordinate> UtilitiesKingCheckStatus(IPlayer currentInCheck, GameController control){
        Piece currentInCheckKing = control.GetPieceData(currentInCheck, 4);
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();
        foreach(Piece piece in control.GetPlayerPieceCollection()[opponentPlayer]){
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            foreach(var mov in eachPieceCurrentPossibleMove){
                if(mov.ToPos.x == currentInCheckKing.pos.x && mov.ToPos.y == currentInCheckKing.pos.y){
                    Console.WriteLine($"{currentInCheck.name} King is in Check!");
                    yield return mov.ToPos;
                }
            }
        }
    }

    public List<Coordinate> UtilitiesKingPossibleCheckStatus(IPlayer currentInCheck, GameController control){
        Piece currentInCheckKing = control.GetPieceData(currentInCheck, 4);
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();
        IEnumerable<Move> kingPossibleMoves = currentInCheckKing.GetMoves(currentInCheckKing.pos, control);
        List<Coordinate> kingInDangerMoves = new List<Coordinate>();
        foreach(var kingmove in kingPossibleMoves){
            foreach(Piece piece in control.GetPlayerPieceCollection()[opponentPlayer]){
                IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
                foreach(var mov in eachPieceCurrentPossibleMove){
                    if(mov.ToPos.x == kingmove.ToPos.x && mov.ToPos.y == kingmove.ToPos.y){
                        // Console.WriteLine($"{currentInCheck.name} King if move to ({kingmove.ToPos.x},{kingmove.ToPos.y})possible move will result in Check!");
                        // yield return kingmove.ToPos;
                        kingInDangerMoves.Add(kingmove.ToPos);
                    }
                }
            }
        }
        return kingInDangerMoves;
    }


    public bool UtilitiesCheckCheckmateStatus(IEnumerable<Move> kingMoves, List<Coordinate> kingMoveCheck){
        List<Coordinate> kingMovesList =  new List<Coordinate>();
        foreach(var km in kingMoves){
            kingMovesList.Add(km.ToPos);
        }
        return kingMovesList.SequenceEqual(kingMoveCheck);
    }

}