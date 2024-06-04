using System;


class GameController{
    private Dictionary<IPlayer,List<ICard>> _playerCardData;
    public GameController(){
        _playerCardData = new Dictionary<IPlayer, List<ICard>>();
    }

    // Read-Write for Dictionary
    public void AddPlayerCardData(IPlayer player, List<ICard> data){
        _playerCardData.Add(player, data);
    }
    public Dictionary<IPlayer,List<ICard>> GetPlayerCardData(){
        return _playerCardData;
    }
    public List<ICard> GetPlayerPossibleCard(IPlayer player){
        return GetPlayerCardData()[player].ToList();
    }

}