using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropController : MonoBehaviour
{
    private CropGrow.GrowStates cropState;
    private bool hasPlant;
    private bool isPlantGrown;
    private Color outlineColor;

    private CropClickable cropClickableScript;
    private CropGrow cropGrowScript;
    private PlantImageGrow plantImageGrownScript;

    private void Awake()
    {
        cropClickableScript = GetComponent<CropClickable>();
        cropGrowScript = GetComponentInChildren<CropGrow>();
        plantImageGrownScript = GetComponentInChildren<PlantImageGrow>();
    }

    public CropGrow.GrowStates GetCropState() => cropState;
    public void SetCropState(CropGrow.GrowStates state) => cropState = state;
    public bool GetHasPlant() => hasPlant;
    public void SetHasPlant(bool planted) => hasPlant = planted;
    public bool GetIsPlantGrown() => isPlantGrown;
    public void SetIsPlantGrown(bool grown)
    {
        isPlantGrown = grown;
        plantImageGrownScript.SetIsAnimated(isPlantGrown);
    }
    public Color GetOutlineColor() => outlineColor;
    public void SetOutlineColor(Color newColor)
    {
        outlineColor = newColor;
        cropClickableScript.SetColorTargetOutline(outlineColor);
    }

    public void Plant()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        cropGrowScript.Plant();
    }

    public void Collect()
    {
        cropGrowScript.Collect();
    }
}
