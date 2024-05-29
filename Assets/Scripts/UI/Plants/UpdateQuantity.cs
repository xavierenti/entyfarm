using TMPro;
using UnityEngine;

public class UpdateQuantity : MonoBehaviour
{
    private int actualQuantity;

    private TextMeshProUGUI textQuantityComponent;

    private void Awake()
    {
        textQuantityComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        actualQuantity = GetComponentInParent<UserPlantClickable>().GetPlantSelected().getStackQuantity();
        textQuantityComponent.text = actualQuantity.ToString();
    }

    public void RestartQuantity()
    {
        actualQuantity = GetComponentInParent<UserPlantClickable>().GetPlantSelected().getStackQuantity();
        textQuantityComponent.text = actualQuantity.ToString();
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
