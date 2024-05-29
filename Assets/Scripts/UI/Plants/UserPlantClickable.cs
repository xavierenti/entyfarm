using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserPlantClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // BACKGROUND COLORS
    private Color baseColorBackground = new Color(96f / 255f, 77f / 255f, 59f / 255f);
    private Color hoverColorBackground = new Color(154f / 255f, 133f / 255f, 112f / 255f);
    private Color selectedColorBackground = new Color(58f / 255f, 54f / 255f, 49f / 255f);

    // TEXT COLORS
    private Color baseColorText = new Color(207f / 255f, 207f / 255f, 207f / 255f);
    private Color hoverColorText = new Color(94f / 255f, 94f / 255f, 94f / 255f);
    private Color selectedColorText = new Color(1f, 1f, 1f);

    // PLANT IMAGE SCALES
    private Vector3 baseScale;
    private Vector3 upgradedScale;

    // COMPONENTS REFERENCES
    private Image imageBackground;
    private Image imagePlant;
    private TextMeshProUGUI textPlantName;
    private TextMeshProUGUI textPlantQuantity;

    private bool isSelected = false;
    private Plant plantSelected = null;

    private void Awake()
    {
        imageBackground = this.transform.GetChild(0).GetComponent<Image>();
        imagePlant = this.transform.GetChild(1).GetComponent<Image>();
        textPlantName = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        textPlantQuantity = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        baseScale = imagePlant.transform.localScale;
        upgradedScale = baseScale * 1.25f;
    }

    private void Update()
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

        imageBackground.color = hoverColorBackground;
        imagePlant.transform.localScale = upgradedScale;
        textPlantName.color = hoverColorText;
        textPlantQuantity.color = hoverColorText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected) return;

        ResetPlant();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager._GAMEMANAGER.SelectPlant(this.gameObject);

        imageBackground.color = selectedColorBackground;
        textPlantName.color = selectedColorText;
        textPlantQuantity.color = selectedColorText;

        isSelected = true;
    }

    public Plant GetPlantSelected() => plantSelected;

    public void SetPlantSelected(Plant newPlant) => plantSelected = newPlant; 

    public void ResetPlant()
    {        
        imageBackground.color = baseColorBackground;
        imagePlant.transform.localScale = baseScale;
        textPlantName.color = baseColorText;
        textPlantQuantity.color = baseColorText;

        isSelected = false;
    }

    private void ResetPlantSelected()
    {
        GameManager._GAMEMANAGER.ResetPlantSelected();
    }
}
