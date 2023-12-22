using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    [SerializeField] private GeneratePlants generateUserPlantsScript;
    [SerializeField] private GameObject cropsObject;
    [SerializeField] private GameObject saveMenuObject;

    private GameObject plantSelected;
    private Sprite plantSprite;
    private float plantGrowTime;

    private float currency;

    private GameObject plant;

    private PlayerPlants PlayerPlants;
    private UpdateCurrency updateCurrencyScript;

    private float gameTime = 0f;
    private int userID = 1;
    private int saveID = 1;
    private Dictionary<int, int> plantsDictionary;
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

            plantsDictionary = new Dictionary<int, int>();
            FillToNullPlantDictionary();


            currency = 0f;
        }
    }
    private void Start()
    {
        updateCurrencyScript = GameObject.Find("CurrencyText").GetComponent<UpdateCurrency>();
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    public int GetUsderID() => userID;
    public void SetUserID(int newUserID) => userID = newUserID;
    public int GetSaveID() => saveID;
    public void SetSaveID(int newSaveID) => saveID = newSaveID;

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

    public void UpdateUserPlantsList()
    {
        generateUserPlantsScript.UpdateList();
    }

    private void FillToNullPlantDictionary()
    {
        List<Plant> plants = Database._DATABASE.GetPlants();

        for (int i = 0; i < plants.Count; i++)
        {
            plantsDictionary[plants[i].getPlantId()] = 0;
        }
    }

    public void OpenSaveSelector() => saveMenuObject.SetActive(true);
    public void CloseSaveSelector() => saveMenuObject.SetActive(false);

    public void AddPlantInDictionary(int currentPlant) => plantsDictionary[currentPlant]++;
    public void SubstractPlantInDictionary(int currentPlant) => plantsDictionary[currentPlant]++;
    public int GetPlantInDictionary(int currentPlant) => plantsDictionary[currentPlant];

    public void SaveGame()
    {
        Database._DATABASE.SaveGame(gameTime, currency, cropsObject);
    }

    public void LoadSave()
    {

    }
}
