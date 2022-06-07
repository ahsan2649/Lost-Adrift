using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NormalDoor : MonoBehaviour
{
    public Switch[] switches;

    public UnityEvent isOpen;
    public UnityEvent isClosed;

    bool isFrozen;

    void Start()
    {
        foreach(Switch script in switches)
        {
            script.dooRef = this;
        }
    }

    public void CheckForNewState()
    {
        if (!isFrozen)
        {
            bool allSwitchesActive = true;

            foreach (Switch script in switches)
            {
                if (script.isActive == false || script.isInScene == false)
                {
                    allSwitchesActive = false;
                }
            }

            if (allSwitchesActive)
            {
                isOpen.Invoke();
            }
            else
            {
                isClosed.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isFrozen && switches.Length == 0)
        {
            isOpen.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isFrozen && switches.Length == 0)
        {
            isClosed.Invoke();
        }
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    public void UnFreeze()
    {
        isFrozen = false;
        CheckForNewState();
    }
}
