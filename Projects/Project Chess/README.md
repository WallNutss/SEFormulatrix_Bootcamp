## Story/Background:
Chess is an old school game where you can enjoy it everywhere arouhnd the world! Chess is sign of our civilization espcesially the thirst of knowledge!. So, in order to become more advance than a monkey, I'll try to make this game, I shall become it's creator and worth to become the holder of the HIGH IQ! Cause you know, creator is best than the user! Anyway, the chess variant we will be making today is using your old <b>Western Chess</b>. The Chess will contain 1 Board with dimension of 8x8, 2 Players each other, and of course each player will have their own 16 pieces of toodlers. The pieces will have 7 Class, which is from the Highest Authority, Long Live The <s>Queen</s> Majesty King, Queen, Bishop, Knight, Rook, and our poor peasants, the Pawn.

### For the game feature
1. each player will take turn respectively(you guys can beat each other while playing thou, [Here](https://www.youtube.com/watch?v=7MBcs5Z4KC4))
2. The movement will varies to each pieces, but basically here some tier list of it Queen <-- Knight <-- Rook <-- Pawn <-- King. Yeah King is 'beban'
3. The is 3 special movement yeah is, which is Castling, Promotion, and En Passant.

### The condition of winning 
1. Checkmate, The King is in check, and there is no way to go.
2. Opponen player could resign

### The condition of draw
1. Fifty-move rule: If during the previous 50 moves no pawn has been moved and no capture has been made, either player can claim a draw.


## What they can do
- T

Lets call the terms Piece

### What need to be done
 - ~~I need to prepare how to build the object of the game, which is basically is class


## Breaking Apart
Interface
```
IPiece will be the baseprint of the Pieces
IPlayer will be the baseprint of the Player
```

Class Parent
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
   ─ ID(int) --> Field
   ─ rowCoord(int) --> Field
   ─ colCoord(int) --> Field
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
(15/05/2024 ; 15.31 p.m.)

============  FIRST REVISION ============

Harusnya kalo gitu bukan IPieces nggak sih? Tapi IPieceKing.
Karena buat apa naro di Interface semua, mending bikin base class Parent. Sama kek Player, buat apa naro?
Jadi harusnya kek gini
```
├── Interfaces (IKing)
├── Abstract Base Class (Pieces, Player)
├── Child Class (PlayerA, PlayerB)
├── Event Handler (Notification System)
├── Enums (Game Status)
```

Eh ini goblo harus apa wkakakaka. Jadi harusnya begini lagi rambahannya
Notification System
```
─ Player Movement
─ Game Status
─ Score Display
─ Piece Upgraded (King)
```

dimana Bisa lebih mempresentasikan lebih baik lagi untuk Game Status seperti ini
Game Status
```
─ Game Start
─ Game Running
─ First Player Win
─ Second Player win
─ Game Draw
`