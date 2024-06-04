## Story/Background:
Chess is an old school game where you can enjoy it everywhere around the world! Chess is sign of our civilization espcesially the thirst of knowledge!. So, in order to become more advance than a monkey, I'll try to make this game,and I shall become it's creator and worth to become the holder of the HIGH IQ! Cause that you already know, creator is alwyays the best than the user! Anyway, the chess variant I will be making today is using your old <b>Western Chess</b> variant. The Chess will fixed contain 1 Board with dimension of 8x8, 2 Players each other, and of course each player will have their own 16 pieces of toodlers. The pieces will have 6 Class, which is from the Highest Authority, Long Live The <s>Queen</s> Majesty King, Queen, Bishop, Knight, Rook, and our poor peasants, the Pawn.

### For the game feature
This game will be comeout as a console type game program. So, maybe some of the feature that we may seen at real life will be weird in this program. So anyways here some of the feature I want to implement
1. As long the condition of winning not met, each player will take turn respectively.
2. Each player will have 16 pieces, where the movement will varies to each pieces, as it said in the rules of the Chess.
3. Eaach pieces can take another player piece
4. There is 3 special movement yeah is, which is Castling, Promotion, and En Passant.
5. The Game Controller will control the flow of the program, while Program.cs will just call the Game Controller to make it tidy
6. All data will be placed on the PlayerData.cs, including the List of Player and the Dictionary of List of Player <--> List of Pieces
7. Loop will consist of this pseudocode  
    * Start Program 
    * Initialize the Player, Board, Pieces
    * Set GameStatus = Start
    * While GameStatus.Start do loops #1
    * <b>Loop #1</b> this.currentPlayer Start Action
    * <b>Loop #1</b> this.currentPlayer Choose the pieces
    * <b>Loop #1</b> this.currentPlayer choose the move he can get from the pieces
    * <b>Loop #2</b> isThisValidMove ? Continue : Return step before
    * <b>Loop #2</b> IsThisOccupiedByOpponent ? Take do Remove Opponent Piece and move to Prison : Update Position
    * <b>Loop #1</b> Update Position of Piece in Board
    * <b>Loop #1</b> Check Opponent King IsInCheck? Give Warning : Continue
    * <b>Loop #1</b> Check Win Condition ? Print Player : Continue 
    * <b>Loop #1</b> Print the new position in the Board
    * <b>Loop #1</b> Switch Turn Another Player
    * End of Loop #1 Return again


### The condition of winning 
1. Checkmate, The King is in check, and there is no way to go.
2. Opponent player could resign
3. The condition for draw is using Fifty-move rule: If during the previous 50 moves no pawn has been moved and no capture has been made, either player can claim a draw.

### My vision about the structure of this program
```
├── Program.cs
├── GameController.cs
├── Game System
|   ├── Game Mechanism/Helper <-- All statics
|   ├── Game Logics ? Do I really need this?
|   ├── Orientation/Direction
├── Model
|   ├── Piece
|   ├── Player
|   ├── Board
|   ├── Prison
├── PlayerData
├── ConsoleRendererUI <-- View
|   ├── BoardRenderer
|   ├── MenuRenderer
|   ├── Input Renderer
└── Enums
```
So, I wanna divide between the BackEnd(FLMX Logic in this case is the GameController) and the UI(My ConsoleRenderer). The BackEnd will responsible for the running the program and UI will responsible for the pretty looks.

Program will responsible from combining those two.

While Model will provide the model of the program, such as their properties, what they can do (method). Such as Pieces will have their own properties, and I'm trying to implement the `Person-to-World` view algorithm, which is basically I gave the pieces the world, and their ownself responsible knowing how can they move in that world. While I still aren't sure what Board do because I'm not really using them (I Linked the data into the Dictionary, where the Pieces already store their own information, so yeah idk bbout this board model). And Prison is basically the class model that hold the List of Pieces there also.

Enums just being enums, thanks bud.
