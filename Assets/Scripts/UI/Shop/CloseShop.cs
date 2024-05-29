using UnityEngine;
using UnityEngine.UI;

public class CloseShop : MonoBehaviour
{
    [Header("Shop Menu")]
    [SerializeField] private GameObject shopMenuObject;

    private Button shopButton;

    private void Awake()
    {
        shopButton = GetComponent<Button>();

        shopButton.onClick.AddListener(HideShopMenu);
    }

    private void HideShopMenu()
    {
        GameManager._GAMEMANAGER.UpdateUserPlantsList();
        shopMenuObject.SetActive(false);
    }
}
