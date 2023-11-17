using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const int START_NUMBERS_NAME = 6;

    private Image img;
    private GenerateCrops generateCropsScript;

    private void Awake()
    {
        img = gameObject.GetComponent<Image>();
        generateCropsScript = GetComponentInParent<GenerateCrops>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.color = Color.red;

        int id = int.Parse(transform.name.Substring(START_NUMBERS_NAME));
        int cropsRows = generateCropsScript.GetCropsRows();
        int row = (int)id / cropsRows;
        int col = id % cropsRows;

        Debug.Log("Clicked on position: X-> " +  row + ", Y-> " + col);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.color = Color.white;
    }
}
