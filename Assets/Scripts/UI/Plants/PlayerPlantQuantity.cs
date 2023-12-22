using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPlantQuantity : MonoBehaviour
{
    private int actualQuantity;

    private TextMeshProUGUI textQuantityComponent;

    private void Awake()
    {
        textQuantityComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        actualQuantity = this.GetComponentInParent<PlayerPlants>().GetPlantSelected().getStackQuantity();
    }

    public int GetActualQuantity() => actualQuantity;

    public void SubstractQuantity()
    {
        actualQuantity--;
        textQuantityComponent.text = actualQuantity.ToString();
    }

    public void AddQuantity()
    {
        actualQuantity++;
        textQuantityComponent.text = actualQuantity.ToString();
    }
}
