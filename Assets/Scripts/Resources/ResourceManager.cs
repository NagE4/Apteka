using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int money = 0;
    public int food = 100;
    public int billsToPay = 50;

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
    }

    public bool PayBills()
    {
        if (money >= billsToPay)
        {
            money -= billsToPay;
            return true;
        }
        return false;
    }
}