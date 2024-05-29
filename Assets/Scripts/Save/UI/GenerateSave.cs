using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateSave : MonoBehaviour
{
    [Header("Saves Prefab")]
    [SerializeField] private GameObject savePrefab;

    private List<Save> saves = new List<Save>();

    private void OnEnable()
    {
        CleanCurrentList();

        saves = Database._DATABASE.GetAllSaves();

        for (int i = 0; i < saves.Count; i++)
        {
            GameObject temp = Instantiate(savePrefab, transform);
            temp.transform.SetParent(transform, false);

            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = saves[i].GetUsername();
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Money: " + saves[i].GetMoney() + "$";
            temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Time: " + ((int)saves[i].GetGameTime() / 3600).ToString("00") + "h:" + ((int)saves[i].GetGameTime() / 60).ToString("00") + "m:" + (saves[i].GetGameTime() % 60).ToString("00") + "s";

            temp.transform.name = "Save_" + saves[i].GetSaveID().ToString("0000");
            temp.name = "Save_" + saves[i].GetSaveID().ToString("0000");

            temp.GetComponent<SaveClikable>().SetSave(saves[i]);
        }
    }

    private void CleanCurrentList()
    {
        if (transform.childCount == 0)
        {
            return;
        }

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
