using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCurrency : MonoBehaviour
{
    private TextMeshProUGUI textCurrency;


    private void Awake() => textCurrency = GetComponent<TextMeshProUGUI>();

    public void UpdateCurrencyText(float amount)
    {
        textCurrency.text = amount.ToString() + " $";
    }
}
