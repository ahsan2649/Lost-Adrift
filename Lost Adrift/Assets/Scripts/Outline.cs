using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public bool outlined;
    public GameObject outlineObject;

    public void toggleOutline(bool outline)
    {
        outlined = outline;
        outlineObject.SetActive(outline);
    }
}
