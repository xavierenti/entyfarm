using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateSave : MonoBehaviour
{
    [SerializeField] private TMP_InputField textComponent;

    public void CreateSaveButton()
    {
        if (textComponent.text != "")
        {
            GameManager._GAMEMANAGER.CreateSave(textComponent.text);
        }
    }
}
