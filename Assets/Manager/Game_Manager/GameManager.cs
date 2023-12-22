using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    private GameObject plantSelected;
    private Sprite plantSprite;
    private float plantGrowTime;

    private float currency;

    private GameObject plant;

    private PlayerPlants PlayerPlants;
    private UpdateCurrency updateCurrencyScript;

    private void Awake()
    {
        if (_GAMEMANAGER != null && _GAMEMANAGER != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _GAMEMANAGER = this;

            plantSelected = null;
            plantSprite = null;
            plantGrowTime = -1f;
            PlayerPlants = null;

            currency = 0f;
        }
    }
    private void Start()
    {
        updateCurrencyScript = GameObject.Find("CurrencyText").GetComponent<UpdateCurrency>();
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    public GameObject GetPlantSelected() => plantSelected;
    public Sprite GetPlantSprite() => plantSprite;
    public float GetPlantGrowTime() => plantGrowTime;

    public float GetCurrency() => currency;
    public void AddCurrency(float amount)
    {
        currency += amount;
        updateCurrencyScript.UpdateCurrencyText(currency);
    }
    public void SubstractCurrency(float amount)
    {
        currency -= amount;
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    public void SubstractPlantQuantity(GameObject plant)
    {
        PlayerPlantQuantity updateQuantityScript = plant.transform.GetChild(3).GetComponent<PlayerPlantQuantity>();
        updateQuantityScript.SubstractQuantity();
    }
    public void AddPlantQuantity(GameObject plant)
    {
        PlayerPlantQuantity updateQuantityScript = plant.transform.GetChild(3).GetComponent<PlayerPlantQuantity>();
        updateQuantityScript.AddQuantity();
    }

    public void SelectPlant(GameObject plant)
    {
        if (plantSelected != null)
        {
            PlayerPlants = plantSelected.GetComponent<PlayerPlants>();
            PlayerPlants.ResetPlant();
            ResetPlantSelected();
        }

        plantSelected = plant;
        plantGrowTime = plant.GetComponent<PlayerPlants>().GetPlantSelected().getGrowTime();
        plantSprite = plantSelected.transform.GetChild(1).GetComponent<Image>().sprite;
        Texture2D cursorTexture = plantSprite.texture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetPlantSelected()
    {
        plantSelected = null;
        plantSprite = null;
        plantGrowTime = -1f;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
