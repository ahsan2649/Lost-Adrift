using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasText : MonoBehaviour
{
    public TextPopUp referfence;
    public string textToSay;
    bool overlapping;
    bool textShown;
    public Outline outline;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && overlapping && textShown == false)
        {
            referfence.FadeIn(textToSay);
            textShown = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = true;
            if (outline) outline.toggleOutline(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = false;
            if(textShown) referfence.FadeOut();
            textShown = false;
            if (outline) outline.toggleOutline(false);
        }
    }

    public void HideText()
    {
        if (textShown) referfence.FadeOut();
        textShown = false;
    }
}
