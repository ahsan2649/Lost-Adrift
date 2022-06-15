using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasText : MonoBehaviour
{
    public TextPopUp referfence;
    public string textToSay;
    bool overlapping;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = false;
            referfence.FadeOut();
        }
    }
}
