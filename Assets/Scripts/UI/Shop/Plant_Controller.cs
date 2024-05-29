using UnityEngine;

public class Plant_Controller : MonoBehaviour
{
    private Plant currentPlant;

    public Plant GetPlant() => currentPlant;
    public void SetPlant(Plant newPlant) => currentPlant = newPlant;
}
