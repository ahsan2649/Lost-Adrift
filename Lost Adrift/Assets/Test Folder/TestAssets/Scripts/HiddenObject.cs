using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObject : MonoBehaviour
{
    public GameObject objectToHide;
    ItemScript scriptRef;
    public bool isSeen;

    private void Start()
    {
        scriptRef = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>();

    }

    private void Update()
    {
        if (isSeen && scriptRef.equippedItem == 3)
        {
            objectToHide.SetActive(true);
        }
        else
        {
            objectToHide.SetActive(false);
        }
    }

    private void OnBecameVisible()
    {
        isSeen = true;
    }

    private void OnBecameInvisible()
    {
        isSeen = false;
    }
}
