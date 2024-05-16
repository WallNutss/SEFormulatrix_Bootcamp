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
```

Ok lanjut lagi, nah kan jadinya ada beberapa problem nih, mending kulist  
1. Permasalahan inherit King Class saat Pieces Upgrade (Ini Konseptualnya dan relasinya gimana ya)
2. Apa biar enak, dipisah aja buat modelnya sapa, buat jalanin programnya sapa? Soalnya untuk sekarang itu semuanya kutaro didalam Main Program [APPROVE] --> Program mainly untuk jalanin, model game buat Construction dari awal model. Jadi tinggal panggil gini
   ```csharp
   class Program{
      GameSystem Game = new();
      GameModel Model = new();
      initBoard(Model.Board, Model. Player);

      While(Game.GameStatus == GAME_RUNNING){
         // Start game simulation here
         Game.GameRunning();
      }
   }

   // Where GameRunning Contain
   static void GameRunning(){
      Game.TurnHandler(); // Start Turn Action
      Game.globalScore = Game.UpdateScore(); // Update Score
      Game.GameState(); // Update Game Status Enumeration, Check winnable condition here
   }

   static void TurnHandler(){
      Model.PlayerA.PlayerTurn();
      Model.PlayerB.PlayerTurn();
   }

   static int UpdateScore(){}
      int [][] resultScore = Game.scoreSystem.GetPlayerScore();
      return resultScore;
   ```
3. <b>Abstract</b> class punya `Pieces` sama `Player` harusnya udah benar, yang masih ambigu itu punyanya `EventHandler` sama `Program`
4. Ini terus, board kan perlu tau juga lokasi tiap pieces dimana nggak sih, kalo ini apa perlu disimpan ya informasi ini?
5. Keknya untuk sistem scoring bisa dipisah deh, jadi dari player sendiri bisa ada method buat tau scorenya sendiri, tapi buat updatenya bisa dari Class Score Jadi ambil data dari masing-masing player, terus update global score ke Game? [APPROVED]
6. Pecah lagi Check Winnable Condition 

Jadi harusnya kek gini
```
├── Interfaces (IKing)
├── Abstract Base Class (Pieces, Player)
├── Child Class (PlayerA, PlayerB, Piece)
├── Score?
├── Event Handler (Notification System)
├── Enums (Game Status)
```
Nah harusnya sih udah, sekarang tinggal pikirin relasi diantara mereka semua.  
Jadi harusnya Kan sudah tadi Pieces itu.

Pertanyaan baru:  
Q : Gimana cara player tau score dianya sendiri? Apa dari notification system handlernya? Ini gimana ya?

Karena GameSystem gunain Fungsi ScoreSystem sama EventHandler buat ngurusin scoring sama publish informasi. Jadi harusnya relasi mereka ini association kan?

Dan karena didalam class model itu isinya adalah inisialisasi dari seluruh class parent Piece, Board, dan Player, jadi harusnya relasi mereka itu semua composition(probably? idk man I'm dumb)

(16/05/2024 ; 08.29 a.m.)  
===========  SECOND REVISION ===========

Nah jadi ternyata kurang benar terkait penjelasan Interfaceku. Ini gimana ya?

// Object  
Piece  
King Piece  
Board

// Services  
Event System Handler  
Score System Handler  

// List Data  
Game Status  
Type Player  
Piece Type  


(16/05/2024 ; 15.09 a.m.)  
===========  SECOND REVISION ===========










