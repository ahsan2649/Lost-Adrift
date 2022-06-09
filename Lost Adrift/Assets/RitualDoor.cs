using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RitualDoor : MonoBehaviour
{
    public RitualObject[] ritualThings;
    public UnityEvent openDoor;
    public UnityEvent closeDoor;

    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        foreach(RitualObject script in ritualThings)
        {
            script.doorRef = this;
        }
    }



    public void CheckForNewState()
    {
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
        else
        {
            closeDoor.Invoke();
        }
    }
}
