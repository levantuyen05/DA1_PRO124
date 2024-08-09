using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Killed : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentKilled = 0;
    // Start is called before the first frame update
    private void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    public void UpdateKilled()
    {
        currentKilled++;
        text.text = currentKilled.ToString();
    }
}
