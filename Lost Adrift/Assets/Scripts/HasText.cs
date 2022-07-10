using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasText : MonoBehaviour
{
    [Header("Click 'Reference' and fill it in, there should only be 1 option.")]
    public TextPopUp referfence;
    public string textToSay;
    bool overlapping;
    bool textShown;
    public Outline outline;
    AudioSource aSS; //Audio source speaker, geez grow up >:(

    private void Start()
    {
        aSS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && overlapping && textShown == false)
        {
            referfence.FadeIn(textToSay);
            if (outline) outline.toggleOutline(false);
            textShown = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = true;
            if (outline) outline.toggleOutline(true); aSS.pitch = 1; aSS.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = false;
            if(textShown) referfence.FadeOut();
            textShown = false;
            if (outline) outline.toggleOutline(false); aSS.pitch = 0.5f; aSS.Play(); 
        }
    }

    public void HideText()
    {
        if (textShown) referfence.FadeOut();
        textShown = false;
    }
}
