using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler
{

    [SerializeField, Range(0, 0.75f)] private float trasitionColorSpeed;

    private Outline outlineComponent;
    private Color currentOutlineColor;
    private Color targetOutlineColor;

    //private GenerateCrops generateCropsScript;
    private CropController crop_controller;

    private void Awake()
    {
        outlineComponent = GetComponent<Outline>();
        //generateCropsScript = GetComponentInParent<GenerateCrops>();
        crop_controller = GetComponent<CropController>();

        currentOutlineColor = outlineComponent.effectColor;
        targetOutlineColor = currentOutlineColor;
    }

    private void Update()
    {
        ChangeColorOutline();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

        if (GameManager._GAMEMANAGER.GetPlantSprite() != null)
        {
            bool canPlant = GameManager._GAMEMANAGER.GetPlantSelected().GetComponent<PlayerPlants>().transform.GetChild(3).GetComponent<PlayerPlantQuantity>().GetActualQuantity() > 0;

            if (!crop_controller.GetHasPlant() && canPlant)
            {
                outlineComponent.enabled = true;
                crop_controller.Plant();
            }
        }
        else
        {
            if (crop_controller.GetIsPlantGrown())
            {
                outlineComponent.enabled = false;
                crop_controller.Collect();
            }
        }
        /*
        img.color = Color.red;

        int id = int.Parse(transform.name.Substring(START_NUMBERS_NAME));
        int cropsRows = generateCropsScript.GetCropsRows();
        int row = (int)id / cropsRows;
        int col = id % cropsRows;

        Debug.Log("Clicked on position: X-> " +  row + ", Y-> " + col);
        */
    }
    public void SetColorTargetOutline(Color newColor) => targetOutlineColor = newColor;

    public void RemoveCropOutline()
    {
        outlineComponent.enabled = false;
    }

    private void ChangeColorOutline()
    {
        outlineComponent.effectColor = Color.Lerp(currentOutlineColor, targetOutlineColor, trasitionColorSpeed * Time.deltaTime);
        currentOutlineColor = outlineComponent.effectColor;
    }

}
