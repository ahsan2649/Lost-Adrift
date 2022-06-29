using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasText : MonoBehaviour
{
    public TextPopUp referfence;
    public string textToSay;
    bool overlapping;
    public Outline outline;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && overlapping)
        {
            referfence.FadeIn(textToSay);
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
            referfence.FadeOut();
            if (outline) outline.toggleOutline(false);

        }
    }
}
