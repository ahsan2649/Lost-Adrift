using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbstractSpaceObject : MonoBehaviour
{
    public UnityEvent onAppear;
    public UnityEvent onDisappear;

    public GameObject objectToHide;
    ItemScript scriptRef;
    public bool isSeen;
    bool canChange = true;

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
        if (scriptRef.equippedItem != 2 && canChange)
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
        onAppear.Invoke();
    }

    public void BecomeInvisible()
    {
        onDisappear.Invoke();
        objectToHide.SetActive(false);
    }

    public void Freeze()
    {
        canChange = false;
    }

    public void UnFreeze()
    {
        canChange = true;
    }
}
