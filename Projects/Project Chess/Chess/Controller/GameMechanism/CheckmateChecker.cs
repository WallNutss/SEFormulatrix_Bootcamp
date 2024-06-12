using System;
using Chess.Boards;
using Chess.GameControl;
using Chess.Pieces;
using Chess.Players;

namespace Chess.GameControl.GameMechanism;

public class CheckmateManager{

    // After current player taking action, does the opponent player king is in check
    public bool UtilitiesIsItCheck(GameController control){
        // Getting the players
        IPlayer currentPlayer = control.GetCurrentPlayer();
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        // Because now it's currentplayer Turn, I'm checking the consequence of the current player
        // action to the opoonent player pieces
        Piece OpponentKingPiece = control.GetPieceData(opponentPlayer, 4);

        foreach(Piece piece in control.GetPlayerPieceCollection()[currentPlayer]){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var mov in eachPieceCurrentPossibleMove){
                if(mov.ToPos.x == OpponentKingPiece.pos.x && mov.ToPos.y == OpponentKingPiece.pos.y){
                    return true;
                }
            }
        }
        return false;
    }

    public Coordinate? UtilitiesGetCheckCausingMoves(GameController control){
        // Getting the players
        IPlayer currentPlayer = control.GetCurrentPlayer();
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        // Because now it's currentplayer Turn, I'm checking the consequence of the current player
        // action to the opoonent player pieces
        Piece OpponentKingPiece = control.GetPieceData(opponentPlayer, 4);

        foreach(Piece piece in control.GetPlayerPieceCollection()[currentPlayer]){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var move in eachPieceCurrentPossibleMove){
                if(move.ToPos.x == OpponentKingPiece.pos.x && move.ToPos.y == OpponentKingPiece.pos.y){
                    // Returning the original position of the piece that cause king in check
                    return move.FromPos;
                }
            }
        }
        // Return null if no move causes a check
        return null;
    }




    public bool UtilitiesDoesKingHavePossibleMove(GameController control){
        
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        // Getting the move coordinate of the king possible move that if the King moves to that square, it would be captured in the next move.
        List<Coordinate> kingDangerSquares = UtilitiesGetKingDangerSquares(opponentPlayer, control).Distinct().ToList();

        // Getting the king opponent player possible move wether it will make it check or not
        Piece opponentKing = control.GetPieceData(opponentPlayer,4);
        IEnumerable<Move> opponentKingPossibleMoves = opponentKing.GetMoves(opponentKing.pos, control);
        bool isEqual = UtilitiesDoesIEnumerableMoveEqualsToCoordinate(opponentKingPossibleMoves, kingDangerSquares);
        return isEqual ? false : true;
    }


    public IEnumerable<Coordinate> UtilitiesKingCheckGeneralStatus(GameController control){
        foreach (var player in control.GetPlayersFromList()){
            foreach (var coordinate in UtilitiesKingCheckStatus(player, control)){
                yield return coordinate;
            }
        }
    }

    public IEnumerable<Coordinate> UtilitiesKingCheckStatus(IPlayer currentPlayer, GameController control){
        Piece currentInCheckKing = control.GetPieceData(currentPlayer, 4);
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();
        foreach(Piece piece in control.GetPlayerPieceCollection()[opponentPlayer]){
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            foreach(var mov in eachPieceCurrentPossibleMove){
                if(mov.ToPos.x == currentInCheckKing.pos.x && mov.ToPos.y == currentInCheckKing.pos.y){
                    // Console.WriteLine($"{currentPlayer.name} King is in Check!");
                    yield return mov.ToPos;
                }
            }
        }
    }
    

    public bool UtilitiesCanOpponentPlayerPieceRemoveThePieceResponsible(GameController control, Piece pieceThatResponsible){
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        List<Piece> allOpponentPiecesWithoutKing = control.GetPlayerPieceCollection()[opponentPlayer].Where(p => p.pieceID != 4).ToList();
        foreach(Piece piece in allOpponentPiecesWithoutKing){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var move in eachPieceCurrentPossibleMove){
                if(move.ToPos.x == pieceThatResponsible.pos.x && move.ToPos.y == pieceThatResponsible.pos.y){
                    return true;
                }
            }
        }
        return false;
    }

    public List<Piece> UtilitiesGetOpponentPlayerPiecesToRemoveThePieceResponsible(GameController control, Piece pieceThatResponsible){
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        List<Piece> allOpponentPiecesWithoutKing = control.GetPlayerPieceCollection()[opponentPlayer].Where(p => p.pieceID != 4).ToList();
        List<Piece> agentPieces = new List<Piece>();
        foreach(Piece piece in allOpponentPiecesWithoutKing){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var move in eachPieceCurrentPossibleMove){
                if(move.ToPos.x == pieceThatResponsible.pos.x && move.ToPos.y == pieceThatResponsible.pos.y){
                    agentPieces.Add(piece);
                }
            }
        }
        return agentPieces;
    }













    public bool UtilitiesCanOpponentPlayerPiecesMoveToKingDangerSquares(GameController control, Piece pieceThatResponsible){
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        IEnumerable<Move> pieceThatResponsiblePossibleMoves = pieceThatResponsible.GetMoves(pieceThatResponsible.pos, control);
        List<Piece> allOpponentPiecesWithoutKing = control.GetPlayerPieceCollection()[opponentPlayer].Where(p => p.pieceID != 4).ToList();

        foreach(Piece piece in allOpponentPiecesWithoutKing){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var move in eachPieceCurrentPossibleMove){
                foreach(var responsibleMove in pieceThatResponsiblePossibleMoves){
                    if(move.ToPos.x == responsibleMove.ToPos.x && move.ToPos.y == responsibleMove.ToPos.y){
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public List<Piece> UtilitiesGetOwnPiecesToBlockCheck(GameController control, Piece pieceThatResponsible){
        IPlayer opponentPlayer = control.GetCurrentOpponentPlayer();

        IEnumerable<Move> pieceThatResponsiblePossibleMoves = pieceThatResponsible.GetMoves(pieceThatResponsible.pos, control);
        List<Piece> allOpponentPiecesWithoutKing = control.GetPlayerPieceCollection()[opponentPlayer].Where(p => p.pieceID != 4).ToList();

        List<Piece> blockPieces = new List<Piece>();
        foreach(Piece piece in allOpponentPiecesWithoutKing){
            // Getting every pieces of the current player have
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
            // Iterate every move that a piece of current player
            foreach(var move in eachPieceCurrentPossibleMove){
                foreach(var responsibleMove in pieceThatResponsiblePossibleMoves){
                    if(move.ToPos.x == responsibleMove.ToPos.x && move.ToPos.y == responsibleMove.ToPos.y){
                        blockPieces.Add(piece);
                    }
                }
            }
        }
        return blockPieces;
    }


    public List<Coordinate> UtilitiesGetKingDangerSquares(IPlayer player, GameController control){
        IPlayer oppositePlayer = control.SwapPlayer(player);
        Piece playerKingPiece = control.GetPieceData(player,4);

        IEnumerable<Move> playerKingPossibleMoves = playerKingPiece.GetMoves(playerKingPiece.pos, control);
        List<Coordinate> kingDangerSquares = new List<Coordinate>();
        foreach(var kingMove in playerKingPossibleMoves){
            foreach(Piece piece in control.GetPlayerPieceCollection()[oppositePlayer]){
                IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, control);
                foreach(var mov in eachPieceCurrentPossibleMove){
                    if(mov.ToPos.x == kingMove.ToPos.x && mov.ToPos.y == kingMove.ToPos.y){
                        kingDangerSquares.Add(kingMove.ToPos);
                    }
                }
            }
        }
        return kingDangerSquares;
    }

    public bool UtilitiesDoesIEnumerableMoveEqualsToCoordinate(IEnumerable<Move> kingMoves, List<Coordinate> kingMoveCheck){
        List<Coordinate> kingMovesList =  new List<Coordinate>();
        foreach(var km in kingMoves){
            kingMovesList.Add(km.ToPos);
        }
        return kingMovesList.SequenceEqual(kingMoveCheck);
    }

}