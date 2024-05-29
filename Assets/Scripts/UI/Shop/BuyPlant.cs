using UnityEngine;

public class BuyPlant : MonoBehaviour
{
    private Plant currentPlant;

    private void Start()
    {
        currentPlant = GetComponentInParent<Plant_Controller>().GetPlant();
    }

    public void Buy()
    {
        float amount = GameManager._GAMEMANAGER.GetCurrency() - currentPlant.getBuyPrice();

        if (amount < 0)
        {
            Debug.Log("[!] Error: You need to get more money to buy this plant! - " + Mathf.Abs(amount) + "$");
            return;
        }

        GameManager._GAMEMANAGER.SubstractCurrency(currentPlant.getBuyPrice());
        Database._DATABASE.BuyPlant(currentPlant.getPlantId());
        GameManager._GAMEMANAGER.SaveGame();
    }
}
