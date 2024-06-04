using System;


class Program{
    static void Main(){
        IPlayer playerA = new Player("Gugu",1);
        ICard cardA = new Card("Solo",1);
        ICard cardB = new Card("Jogja",2);

        IPlayer playerB = new Player("Gaga",2);
        ICard cardC = new Card("Manchester",3);
        ICard cardD = new Card("United",4);

        GameController gc = new();
        gc.AddPlayerCardData(playerA, new List<ICard>{cardA,cardB});
        gc.AddPlayerCardData(playerB, new List<ICard>{cardC,cardD});

        List<ICard> cards = gc.GetPlayerPossibleCard(playerA);
        foreach(var card in cards){
            card.GetInfo();
        }

        foreach(var card in gc.GetPlayerPossibleCard(playerB)){
            card.GetInfo();
        }
        
    }
}