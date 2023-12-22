using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratePlants : MonoBehaviour
{
    [SerializeField] private GameObject userPlantPrefab;

    private List<Plant> userPlants = new List<Plant>();
    private Sprite sprite;

    private void Start()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        userPlants = Database._DATABASE.GetUserPlants();

        for (int i = 0; i < userPlants.Count; i++)
        {
            GameObject temp = Instantiate(userPlantPrefab, transform);
            temp.transform.SetParent(transform, false);

            sprite = Resources.Load<Sprite>("Fruits/icons/32x32/" + userPlants[i].getPlantId().ToString());

            temp.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = userPlants[i].getPlantName();
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = userPlants[i].getStackQuantity().ToString();

            temp.transform.name = "Plant_" + userPlants[i].getPlantId().ToString("0000");
            temp.name = "Plant_" + userPlants[i].getPlantId().ToString("0000");

            PlayerPlants userPlantClickableScript = temp.GetComponent<PlayerPlants>();
            userPlantClickableScript.SetPlantSelected(new Plant(userPlants[i].getPlantId(), userPlants[i].getPlantName(), userPlants[i].getGrowTime(), userPlants[i].getStackQuantity(), userPlants[i].getSellPrice(), userPlants[i].getBuyPrice()));
        }
    }
}
