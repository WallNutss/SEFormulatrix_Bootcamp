```mermaid
classDiagram
    %% OOP Structure
    Pieces <|-- IKing
    Player <|-- Pieces
    Pieces : -object pieces



    %% MAIN PROGRAM/GAME CONTROLLER
    class Program{

    }

    %% Defining Abstract Class Template
    class Pieces{
      <<Abstract>>
      - int ID
      - int rowCoord
      - int colCoord
      - int playerType : PlayerType
      + MoveForward()
      + OverTake()
    }
    class Player{
      <<Abstract>>
      - string namePlayer
      - object pieces
      - int scorePlayer
    }

    %% Defining Interface
    class IKing{
      <<Interfaces>>
      + MoveBackward()
    }

    %% Defining Event Handler
    class EventSystemHandler{
      <<Service>>
      + PlayerMovement()
      + PieceOvertaken()
      + GameStatus()
      + ScoreDisplay()
    }

    %% Defining Enums//Game Status
    class GameStatus{
      <<Enumeration>>
      GAME_START
      GAME_RUNNING
      GAME_FINISHED
      GAME_DRAW
    }
    class PlayerType{
      <<Enumeration>>
      PlayerA
      PlayerB
    }
```