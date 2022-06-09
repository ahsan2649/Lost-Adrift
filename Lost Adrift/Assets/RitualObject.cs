using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualObject : MonoBehaviour
{
    public bool isActivated;
    public RitualDoor doorRef;

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
