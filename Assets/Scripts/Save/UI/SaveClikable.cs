using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveClikable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Color baseColorBackground = new Color(64f / 255f, 206f / 255f, 245f / 255f);
    private Color hoverColorBackground = new Color(142f / 255f, 220f / 255f, 241f / 255f);
    private Color selectedColorBackground = new Color(52f / 255f, 104f / 255f, 118f / 255f);

    // COMPONENTS REFERENCES
    private Image imageBackground;


    private Save saveSelected = null;

    private void Awake()
    {
        imageBackground = this.transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageBackground.color = hoverColorBackground;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageBackground.color = baseColorBackground;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        imageBackground.color = selectedColorBackground;

        GameManager._GAMEMANAGER.SetSaveID(saveSelected.GetSaveID());
        GameManager._GAMEMANAGER.SetUserID(saveSelected.GetUserID());
        GameManager._GAMEMANAGER.SetGameTime(saveSelected.GetGameTime());
        GameManager._GAMEMANAGER.SetCurrency(saveSelected.GetMoney());

        GameManager._GAMEMANAGER.LoadSave();
    }

    public void SetSave(Save newSave) => saveSelected = newSave;
}
