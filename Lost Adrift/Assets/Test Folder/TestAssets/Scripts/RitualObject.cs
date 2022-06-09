using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RitualObject : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    public bool isActivated;
    bool overlapping;
    public RitualDoor doorRef;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && overlapping)
        {
            isActivated = !isActivated;

            if (isActivated)
            {
                onActivate.Invoke();
                ritualOn();
            }
            else
            {
                onDeactivate.Invoke();
                ritualOff();
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

    public void ritualOn()
    {
        isActivated = true;
        doorRef.CheckForNewState();
    }

    public void ritualOff()
    {
        isActivated = false;
        doorRef.CheckForNewState();
    }

}
