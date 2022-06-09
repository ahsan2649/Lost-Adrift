using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RitualDoor : MonoBehaviour
{
    public RitualObject[] ritualThings;
    public UnityEvent openDoor;
    public UnityEvent closeDoor;
    public UnityEvent locked;

    bool isOpen;
    bool overlapping;

    // Start is called before the first frame update
    void Start()
    {
        foreach(RitualObject script in ritualThings)
        {
            script.doorRef = this;
        }
    }

    private void Update()
    {
        if(overlapping && Input.GetKeyDown(KeyCode.E) && isOpen == false)
        {
            locked.Invoke();
        }
    }

    public void CheckForNewState()
    {
        bool lastValue = isOpen;
        isOpen = true;

        foreach(RitualObject script in ritualThings)
        {
            if (script.isActivated == false)
            {
                isOpen = false;
            }
        }

        if (isOpen)
        {
            openDoor.Invoke();
        }
        else if(lastValue != isOpen)
        {
            closeDoor.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            overlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            overlapping = false;
        }
    }
}
