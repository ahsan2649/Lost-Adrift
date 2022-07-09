using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBackground : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 originalPos;
    CursorMode cursorMode = CursorMode.Auto;

    public Transform centerOfScreen;
    public Texture2D cursorTexture;
    public TextMeshProUGUI text;
    public string[] textToSay;
    public GameObject[] imagesToShow;
    public GameObject dialougeBox;
    int i;

    void Start()
    {
        originalPos = transform.position;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(cursorTexture, Vector2.zero,cursorMode);
        Cursor.visible = false;
        imagesToShow[0].SetActive(true);
        text.text = textToSay[0];
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector3 distanceFromCenter = mousePos - centerOfScreen.position;
        transform.position = (originalPos + (distanceFromCenter / 30));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            text.text = textToSay[i];

            if(i == 3)
            {
                imagesToShow[0].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[1].GetComponent<Animator>().SetTrigger("FadeIn");
            }
            if (i == 5)
            {
                imagesToShow[1].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[2].GetComponent<Animator>().SetTrigger("FadeIn");
            }
            if(i == 9)
            {
                imagesToShow[2].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[3].GetComponent<Animator>().SetTrigger("FadeIn");
            }
            if (i == 11)
            {
                imagesToShow[3].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[4].GetComponent<Animator>().SetTrigger("FadeIn");
                dialougeBox.SetActive(false);
            }
            if (i == 12)
            {
                imagesToShow[4].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[5].GetComponent<Animator>().SetTrigger("FadeIn");
            }
            if (i == 13)
            {
                imagesToShow[5].GetComponent<Animator>().SetTrigger("FadeOut");
                imagesToShow[0].GetComponent<Animator>().SetTrigger("FadeIn");
                dialougeBox.SetActive(true);
            }
            if(i == 18)
            {
                SceneManager.LoadScene("Cabin", LoadSceneMode.Single);
            }
        }
    }
}
