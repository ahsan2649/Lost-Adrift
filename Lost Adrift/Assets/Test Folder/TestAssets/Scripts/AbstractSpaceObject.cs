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
        //Initialization of variable and changes the visibilty of the abstrat object to the state selected in the editor.
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


    private void OnBecameInvisible() //When the object leaves the camera's view, this function runs (built in Unity function)
    {
        if (scriptRef.equippedItem != 2 && canChange) //Checking if the player has the map out or if it has been flashed by the camera
        {
            isSeen = !isSeen; //Changes state of the object
            if (isSeen)
            {
                BecomeVisible(); //Makes the object visible
            }
            else
            {
                BecomeInvisible(); //Makes object ivisible
            }
        }
    }

    public void BecomeVisible() //Enables the object, runs event and sets the isSeen bool to true.
    {
        objectToHide.SetActive(true);
        isSeen = true;
        onAppear.Invoke();
    }

    public void BecomeInvisible() //Disables object, runs event and sets the isSeen bool to false
    {
        onDisappear.Invoke();
        isSeen = false;
        objectToHide.SetActive(false);
    }

    public void Freeze() // This function and UnFreeze function deal with the camera functionality. 
    {
        canChange = false;
    }

    public void UnFreeze()
    {
        canChange = true;
    }
}
