using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public TextMeshProUGUI valueText;

    public void UpdateHealth( int currentValue, int maxValue)
    {
        fillbar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }

    public void UpdateBar(int value, int maxValue, string text)
    {
        valueText.text = text;
        fillbar.fillAmount = (float)value / (float)maxValue;

    }
}
