using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isActive;
    bool overlapping;
    public bool isInScene = true;

    public NormalDoor dooRef;
    public GameObject buttonPart;

    private void Update()
    {
        if (overlapping && Input.GetKeyDown(KeyCode.E))
        {
            isActive = !isActive;
            if (isActive)
            {
                buttonPart.transform.localPosition = new Vector3(0, 0, -0.065f);
                dooRef.CheckForNewState();
            }
            else
            {
                buttonPart.transform.localPosition = new Vector3(0, 0, -0.137f);
                dooRef.CheckForNewState();
            }
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
        }
    }

    public void BlinkIn()
    {
        isInScene = true;
        dooRef.CheckForNewState();
        overlapping = false;
    }
    public void BlinkOut()
    {
        isInScene = false;
        dooRef.CheckForNewState();
        overlapping = false;
    }
}
