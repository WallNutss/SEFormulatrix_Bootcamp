## Story/Background:
Checker is a board strategy game played by two players where there is 12 pieces each side(Player Red, and Player Black) totalling 24 pieces on the board game involving moving forward and capturing enemy's pieces by jumping over it diagonally. Pieces can be upgraded to King Subject if Pieces reach at the end of the opponent side. Different with ordinary pieces, King can move backward, where ordinary one only can move forward.

The condition of winning 
1. If a player has lost all his pieces he loses.
2. If a player can't move at all, all his pieces are blocked, he loses.
3. The exact same board state has come up three times without any men captured in between. The game ends in a draw. This is to avoid situation with two pieces left just moving around never being able to capture each other.
4. ~~There have been 100 moves (50 for each player) with no piece captured. The game ends in a draw.

## What they can do
- The Game Consist of Pieces(Base Parent Class)
- The Game need to know Pieces Move(Notification System)
- The Game need to know the state of the Game, still running or no? (Game Status, Check Operation, Enums?)
- Each Player have 12 pieces(Field)
- Each Player have individual roles(Player Red or Player Black)(Derived Class)
- Pieces can be upgraded(Method?) to King Pieces
- Pieces can only move(Method) forward
- Pieces can overtake(Method) Opponent Pieces

That should be it, so lets break apart field and method in the game. For simplicity in my small brain, I'm gonna call field is the thing something consist, class of the object run on the game, and method is that something that class can do.

Lets call the terms Pieces to 'Susanto'

## Breaking Apart
Interface
```
IPiece will be the baseprint of the Pieces
IPlayer will be the baseprint of the Player
```

Class
```
    ├─ Pieces(Model) <-- IPieces
        ├── King(Model)        
    ├─ Player(Model) <-- IPlayer
        ├── Player Red
        ├── Player Black
```

Component Class
```
├─ Pieces
   ─ rowCoord(int) --> Field
   ─ colCoord(int) --> Field
   ─ ID(int) --> Field
   ─ Owner --> Player.Type 
   ─ MoveForward()
   ─ OverTake()

├── King
   ─ ID(int) --> Field
   ─ rowCoord(int) --> Field
   ─ colCoord(int) --> Field
   ─ Owner --> Player.Type 
   ─ MoveForward()
   ─ MoveBackWard()
   ─ OverTake()

├── Player
   ─ Name
   ─ Pieces (Class)
   ─ ScorePlayer (int) --> Field
```

Method
```
─ MoveForward() // Move 1 Tiles Forward Diagonally
─ MoveBackWard() // Move 1 Tiles Backward Diagonally
─ OverTake() // Move Two Tiles if Condition Approved
```

Game Status
```
─ Game Start
─ Game Running
─ Game Finished (WIN/LOSE)
─ Game Draw
```

Notification System
```
─ Player Movement
─ Game Status
─ Score Display
```

So the Folder should be Like this
```
├── Interfaces (IPieces, IPlayer)
├── Base Class (Pieces)
├── Child Class (PlayerA, PlayerB)
├── Components (King Method)
├── Event Handler (Notification System)
├── Enums (Game Status)
```

So the code should look like this
```csharp
Interface 

```


