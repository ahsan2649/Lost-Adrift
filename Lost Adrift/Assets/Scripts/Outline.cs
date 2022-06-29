using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public bool outlined;
    public GameObject outlineObject;

    private void Start()
    {
        outlineObject.SetActive(false);
    }

    public void toggleOutline(bool outline)
    {
        outlined = outline;
        outlineObject.SetActive(outline);
    }
}
