using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateShopPlants : MonoBehaviour
{
    [Header("Shop Plant Prefab")]
    [SerializeField] private GameObject shopPlantPrefab;

    private List<Plant> allPlants = new List<Plant>();
    private Sprite sprite;

    private void OnEnable()
    {
        GetAllGamePlants();
    }

    private void GetAllGamePlants()
    {
        allPlants = Database._DATABASE.GetPlants();

        for (int i = 0; i < allPlants.Count; i++)
        {
            GameObject temp = Instantiate(shopPlantPrefab, transform);
            temp.transform.SetParent(transform, false);

            sprite = Resources.Load<Sprite>("Fruits/icons/32x32/" + allPlants[i].getPlantId().ToString());

            temp.transform.GetComponent<Plant_Controller>().SetPlant(allPlants[i]);
  

            temp.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = allPlants[i].getPlantId().ToString();
            temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = allPlants[i].getBuyPrice().ToString() + " $";
            temp.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "x" + allPlants[i].getStackQuantity().ToString();

            temp.transform.name = "ShopPlant_" + allPlants[i].getPlantId().ToString("0000");
            temp.name = "ShopPlant_" + allPlants[i].getPlantId().ToString("0000");
        }
    }

    private void OnDisable()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
