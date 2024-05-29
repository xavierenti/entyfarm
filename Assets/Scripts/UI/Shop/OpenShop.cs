using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    [Header("Shop Menu")]
    [SerializeField] private GameObject shopMenuObject;

    private Button shopButton;

    private void Awake()
    {
        shopButton = GetComponent<Button>();

        shopButton.onClick.AddListener(SpawnShopMenu);
    }

    private void SpawnShopMenu()
    {
        shopMenuObject.SetActive(true);
    }
}
