using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    Animator anim;
    public TextMeshProUGUI text;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn(string newText)
    {
        text.text = newText;
        anim.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}
