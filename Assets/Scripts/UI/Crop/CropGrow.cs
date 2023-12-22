using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CropGrow : MonoBehaviour
{
    public enum GrowStates { SEED, GROW, PLANT, READY, NULL }

    private bool hasPlantGrowing = false;

    private float cropGrowTime;
    private float cropGrowTimeState;
    private float cropGrowTimer;

    private GrowStates currentState;

    private GameObject currenPlantObject;
    private Plant currentPlant;

    private Image plantImage;
    private CropController crop_controller;

    private void Awake()
    {
        plantImage = GetComponent<Image>();
        crop_controller = GetComponentInParent<CropController>();

        currentState = GrowStates.NULL;

        cropGrowTimeState = 1f;
        cropGrowTimer = 0f;
    }

    private void Update()
    {
        if (hasPlantGrowing)
        {
            cropGrowTimer += Time.deltaTime;
        }

        if (cropGrowTimer >= cropGrowTimeState)
        {
            switch (currentState)
            {
                case GrowStates.SEED:
                    currentState = GrowStates.GROW;
                    cropGrowTimeState = cropGrowTimeState * 2;

                    crop_controller.SetCropState(currentState);
                    crop_controller.SetOutlineColor(new Color(0, 0, 1));
                    break;
                case GrowStates.GROW:
                    currentState = GrowStates.PLANT;
                    cropGrowTimeState = cropGrowTime;

                    crop_controller.SetCropState(currentState);
                    crop_controller.SetOutlineColor(new Color(0, 1, 0));
                    break;
                case GrowStates.PLANT:
                    currentState = GrowStates.READY;
                    hasPlantGrowing = false;

                    crop_controller.SetCropState(currentState);
                    crop_controller.SetIsPlantGrown(true);
                    crop_controller.SetOutlineColor(new Color(1, 1, 0));
                    break;
                default:
                    break;
            }
        }
    }

    public Plant GetPlant() => currentPlant;
    public float GetCropGrowTimer() => cropGrowTimer;

    public void Plant()
    {
        hasPlantGrowing = true;

        currenPlantObject = GameManager._GAMEMANAGER.GetPlantSelected();
        currentPlant = currenPlantObject.GetComponent<PlayerPlants>().GetPlantSelected();

        plantImage.enabled = true;
        plantImage.sprite = GameManager._GAMEMANAGER.GetPlantSprite();

        cropGrowTime = GameManager._GAMEMANAGER.GetPlantGrowTime();
        cropGrowTimeState = cropGrowTime / 3f;

        currentState = GrowStates.SEED;
        crop_controller.SetHasPlant(hasPlantGrowing);
        crop_controller.SetIsPlantGrown(false);
        crop_controller.SetCropState(currentState);
        crop_controller.SetOutlineColor(new Color(1, 0, 0));

        GameManager._GAMEMANAGER.SubstractPlantQuantity(currenPlantObject);
    }

    public void Collect()
    {
        cropGrowTimer = 0f;
        currentState = GrowStates.NULL;
        plantImage.enabled = false;

        crop_controller.SetCropState(currentState);
        crop_controller.SetHasPlant(false);
        crop_controller.SetIsPlantGrown(false);
        crop_controller.SetOutlineColor(new Color(0, 0, 0));

        GameManager._GAMEMANAGER.AddPlantQuantity(currenPlantObject);
        GameManager._GAMEMANAGER.AddCurrency(currentPlant.getSellPrice());
    }
}
