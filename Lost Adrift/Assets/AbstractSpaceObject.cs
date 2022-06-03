using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSpaceObject : MonoBehaviour
{
    public GameObject objectToHide;
    ItemScript scriptRef;
    public bool isSeen;

    private void Start()
    {
        scriptRef = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>();

        if (isSeen)
        {
            BecomeVisible();
        }
        else
        {
            BecomeInvisible();
        }
    }

    private void OnBecameInvisible()
    {
        if (scriptRef.equippedItem != 2)
        {
            isSeen = !isSeen;
            if (isSeen)
            {
                BecomeVisible();
            }
            else
            {
                BecomeInvisible();
            }
        }
    }

    public void BecomeVisible()
    {
        objectToHide.SetActive(true);
    }

    public void BecomeInvisible()
    {
        objectToHide.SetActive(false);
    }
}
