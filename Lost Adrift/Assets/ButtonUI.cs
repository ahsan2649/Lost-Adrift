using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ButtonUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public UnityEvent showControls;
    public UnityEvent unPause;

    public void onHover()
    {
        text.color = Color.white;
    }

    public void endHover()
    {
        text.color = Color.black;
    }

    public void UNPause()
    {
        unPause.Invoke();
    }

    public void SHOWControls()
    {
        showControls.Invoke();
    }
}
