using UnityEngine;

public class permanentInventory : MonoBehaviour
{
    [SerializeField] private int permanentCoin;
    void Update()
    {
        
    }

    public void InitializeCoin(int permanentCoin)
    {
        permanentCoin = 0;
    }

    public void addPermanentCoin(int addCoin, int permanentCoin)
    {
        permanentCoin += addCoin;
    }

    public void removePermanentCoin(int removeCoin, int permanentCoin)
    {
        permanentCoin -= removeCoin;
    }
}
