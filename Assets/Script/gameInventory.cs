using UnityEngine;

public class gameInventory : MonoBehaviour
{
    [SerializeField] private int gameCoin;
    void Update()
    {
        
    }

    public void InitializeCoin(int gameCoin)
    {
        gameCoin = 0;
    }

    public void addGameCoin(int addCoin, int gameCoin)
    {
        gameCoin += addCoin;
    }

    public void removeGameCoin(int removeCoin, int gameCoin)
    {
        gameCoin -= removeCoin;
    }
}
