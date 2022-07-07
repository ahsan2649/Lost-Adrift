using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    SAVEDATASCRIPT saveData;
    Slider slider;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        saveData = GameObject.FindGameObjectWithTag("Savedata").GetComponent<SAVEDATASCRIPT>();
        slider = GetComponent<Slider>();
    }

    public void newSense()
    {
        saveData.newSensitivity(slider.value);
    }

    public void UpdateText()
    {
        text.text = "x " + slider.value / 250;

        if (slider.value == 0)
        {
            text.text = "Ryan's Sensitivity";
        }

        if(slider.value == 500)
        {
            text.text = "Quake Gamer";
        }
    }
}
