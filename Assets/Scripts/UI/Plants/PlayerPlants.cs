using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerPlants : MonoBehaviour
{
    private List<Plant> userPlants = new List<Plant>();

    private Color baseColorText = new Color(0.5f, 0.5f, 0.5f);
    private Color hoverColorText = new Color(0f, 0f, 1f);
    private Color selectedColorText = new Color(1f, 1f, 1f);

    private Vector3 baseScale;
    private Vector3 upgradedScale;

    private Image imatchPlant;
    private TextMeshProUGUI PlantName;
    private TextMeshProUGUI PlantQuantity;

    private bool isSelected = false;
    private Plant plantSelected = null;

    // Start is called before the first frame update
    void Awake()
    {
        imatchPlant = this.transform.GetChild(0).GetComponent<Image>();
        PlantName = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        PlantQuantity = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        baseScale = imatchPlant.transform.localScale;
        upgradedScale = baseScale * 1.25f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            ResetPlantSelected();
            ResetPlant();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelected) return;

        imatchPlant.transform.localScale = upgradedScale;
        PlantName.color = hoverColorText;
        PlantQuantity.color = hoverColorText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected) return;

        ResetPlant();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager._GAMEMANAGER.SelectPlant(this.gameObject);

        PlantName.color = selectedColorText;
        PlantQuantity.color = selectedColorText;

        isSelected = true;
    }



    public Plant GetPlantSelected() => plantSelected;

    public void SetPlantSelected(Plant newPlant) => plantSelected = newPlant;

    public void ResetPlant()
    {
        imatchPlant.transform.localScale = baseScale;
        PlantName.color = baseColorText;
        PlantQuantity.color = baseColorText;

        isSelected = false;
    }

    private void ResetPlantSelected()
    {
        GameManager._GAMEMANAGER.ResetPlantSelected();
    }

}
