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

### What need to be done
 - ~~I need to prepare how to build the object of the game, which is basically in nutshell was only 3 things need to be absent. The players, their pieces, and the board itself~~
 - I need to think how the system score will be done, in order to decide who is the winner and the loser
 - I need to think how the game was moderate, so how the players take turn and how the system keep track their pieces and their 
 - For implementation of delegation, I need to think how I can implement information broadcasting for other class to use it

 As for the first thing needs to be done, I knew that we can achieve this using the Interface template and push them on the class of spesific class, which is the default is the Piece. But I'm in difficulities because I cannot decide if when recruitment process or upgrading process work, will I just change the type inside already available interface fields value or make new class with copy-paste the already information available from Piece Class to the new King Class  

 As for the second thing, I know that I can just make new class that will be assign to this task, where I think that this class will just be a method everytime the games loops around. But I'm in torn wether the player class will it really need their own data score or just store them in this class


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


Note:  
(-) itu private  
(+) itu public  

Oke jadinya hari ini perlu dibaikin dulu dan direvisi.

Harusnya logikanya ada ini


Ini buat event notifications handlernya  
1. Delegate PlayerMovement --> Trigger Method Check Pion Locations --> Check It is Upgraded --> If [Yes] Move Class Piece to Class King --> If [No] do nothing
2. Delegate PrePlayerMovement --> Trigger method to Check Pion Locations --> Check if There is can be piece Overtaken
3. 

Nah jadi menurutku perlu ada deleagates untuk  
1. Buat ganti method object yang ada di board bisa maju atau tidak
2. Buat kasih tau info event kalau player A dengan pieces yang dipilih itu udah pindah
3. Buat ngasih info kalo piecenya lagi/sedang di overtaken, jadi bisa diapus dari list Pieces dari masing-masing player yang terkait
4. Buat ngasih info kalo scorenya mambah, jadi bisa trigger event gameenya ini udah selesai atu belum


Berarti buat planning movementnya itu perlu ada sebuah method untuk mengecek dia bisa apa aja dari list movement yang dipunya sekarang. Apa bisa moveForward, apa bisa moveToOvertaken, atau bisa komninasi keduanya?


Extensiate
Instantiate

Nah iya berarti isi Player itu harusnya ini

```csharp
public class Player{
      string playerName;
      int scorePlayer;
      int playerType;
      List<Piece> Pieces = new List<Pieces>();
      // Start Constructor
      class Player(string playerName, int scorePlayer, int playerType, Piece piece){
         this.playerName = playerName;
         this.scorePlayer = scorePlayer;
         this.playerType = PlayerType.Piece;
         this.Pieces.add(pieces);
      }
}
```

Yes, harusya bikin eskplisit playerTurn itu diganti jadi playerAction. Tak lanjut nanti malam lagi buat recheck lagi. Keknya aku merasa masih ada yang kurang, cuma kurang paham apa yang kurang ini.

I have added delegates class to be associated with the main program, but I'm still confuse how I connect them event subscriber to the method for triggering those Delegates Action values, as I'm still confuse how to handle recuritment(Piece-->King) process should be work in the diagram

(18/05/2024 ; 14.14 p.m.)  
===========  THIRD REVISION ===========

Oke sekarang coba dijelaskan cara kerjanya secara alur bagaimana.
1.  Nah kan pertama coba diinisalisasikan dulu object-objectnya yaitu board, player, dan piecesnya.
2. Kita bisa mencapai itu dengan membuat interface untuk masing-masing object supaya lebih terikat dan teratur. Hal ini untuk membuat kode rapih dan terlihat lebih enak dilihat. Dimana membuat Interface IPiece, IPlayer, dan IBoard untuk masing-masing penurunan kelasnya yaitu Piece dan King untuk IPiece, Player untuk IPlayer, dan Board untuk IBoard.
3. Setelah itu, saat `initBoard()` berjalan pada `Main Program`, kita melakukan inisialisasi pada masing-masing object, yaitu disimpan dengan pemanggilan model terlebih dahulu.  
   Model() --> Initilaize Player(), Board()  
   Player --> Initialize List Pieces and Save it on List of Field
4. Dimana kita membuat lagi kelass folder baru lagi buat enumeration macam-macam, satu buat PlayerType, satu buat PieceClass, dan satu lagi buat GameStatus. Kurang lebih urutan folder ada dibawah
5. Setelah itu semua elemen penting telah diinisaialisasikan, kita bisa memulai gamenya, yaitu dengan trigger method `GameStart()`. Di method ini dimulai panggil `Model.Player(x).PlayerAction()` untuk mengechek suatu class `Player` puya method apa aja yang bisa dilakukan.
6. Setelah semua player melakukan turnnya, dilanjutkan method berikutnya yaitu `GameState()` untuk mengecek apakah game bisa diteruskan atau sudah didapatkan pemenangnya? Hal ini dengan cara memamnggil method lagi di GameState yaitu `Mod.GameCheckStatus()` 
7. Setelah melakukan pengkondisian dari beberapa kemungkinan, return GameStatus Check enumeration, kalo bener return kembali gameStatusnya
8. Ulangi lagi loopingnya
9. Disetiap main method yang ada pada main program, dijalankan juga masing-masing method yang ada pada Class Delegates sesuai dari fungsinya. Misal pada saat dijalankan method `Method.Player(x).PlayerAction` , dijalankan juga `eventHandler.PieceMovement()` habis itu yang bakal trigger apakah perlu subscribe atau tidak jika pengkondisian pada PieceMovement ini memenuhi atau tidak.
10. Harusnya kek gini aja sih



Note : 
- Ini bedanya buat GameStart sama TurnHandler apaan ya? Soalnya kemabiguitas `GameStart()` ini isinya nanti apa ya?
- Lanjut lagi besok


Loop Program buat presentasi cara kerjanya
```mermaid


```


===========  FOURTH REVISION ===========  
Class Piece bakal kuganti jadi soldier, jadi bisa bedain kenapa ada Piece sana Ipiece kako king ditaro juga disiut

Ok, so lets start in order again
- ~~The Game Consist of Pieces(Base Parent Class)~~, where I have already making this. For now the plan is that I have build a class soldier and king with the interface tempalte base to form those two classed. Where as for the player structure, I have prepared an Interface IPlayer contract to form the player class. For the board, while I don't think it's necessary to build the interface, I think it's a good practice to have one
- Each Player have 12 pieces(Field), So in my mind the plan on the `Program.cs`, I will initialize all the things of the game model should have, which is the board, the player, and their pieces. So the model will have the parameter of the player and their pieces where the player will have the ID, and etc and pieses will be assigned to them
   ```csharp
   GameInisialization()
   --> 
      // Fields initialization
      
      // Construtor
      GameInisialization(int numPlayer, Board){
         return Board
      }
      // All of this is on it's own method
      // Initiliaze the pieces first
      SetPieces(IPieces, PlayerType playerType){
         return <List> Pieces
      }

      // Assign them to the player
      SetPieces2Player(<List> Player, <List> Pieces){
         return <List> Player
      }

      // Assign them to the model
      SetGameModel(<List> Player, Board){
         return Model
      }
   ```

   So add another class of `GameStarter` consist of Assign Pieces, anyway it' done now
- The Game need to know the state of the Game, still running or no? (Game Status, Check Operation, Enums?), I have desribe this in spesific class of GameModeration for that, hope that corrects way of thinking
- Each Player have individual roles(Player Red or Player Black)(Derived Class), I have fix this into making it List of Player in case Checker evolved like chess can play into more than two players. [DONE]

- The Game need to know Pieces Move(Notification System), ini yang masih bingung korelasinya gimana
- Pieces can be upgraded(Method?) to King Pieces, inijuga bingung cara ceknya gimana ya
- Pieces can only move(Method) forward, ini bedua ada hubungannya sama cara updgrade ini, sebenarnya yang kubingungin itu taro mana tuh method buat updgradenya
- Pieces can overtake(Method) Opponent Pieces













