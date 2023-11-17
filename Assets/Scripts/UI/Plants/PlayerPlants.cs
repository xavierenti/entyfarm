using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlants : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPlantsPrefab;

    private List<Plant> userPlants = new List<Plant>();

    // Start is called before the first frame update
    void Start()
    {
        userPlants = Database._DATABASE.GetUserPlants();

        for(int i = 0; i < userPlants.Count; i++)
        {
            GameObject temp = Instantiate(PlayerPlantsPrefab, transform);
            temp.transform.SetParent(transform, false);

            temp.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = userPlants[i].getPlantName();
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = userPlants[i].getStackQuantity().ToString();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
