using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NormalDoor : MonoBehaviour
{
    public int keysNeeded;
    public Switch[] switches;
    ItemScript playerRef;

    public UnityEvent isOpen;
    public UnityEvent isLocked;
    public UnityEvent isUnLocked;
    public UnityEvent isClosed;

    bool isFrozen;
    bool isOpened;
    public bool overLapping;
    public bool locked;

    void Start()
    {
        foreach(Switch script in switches)
        {
            script.dooRef = this;
        }

        if (keysNeeded > 0)
        {
            locked = true;
        }

        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && overLapping)
        {
            if (locked == false && !isOpened && switches.Length == 0)
            {
                isOpen.Invoke();
                isOpened = true;
            }

            if (locked && playerRef.keys >= keysNeeded && switches.Length == 0)
            {
                locked = false;
                isUnLocked.Invoke();
            }

            if(locked && playerRef.keys < keysNeeded && switches.Length == 0)
            {
                isLocked.Invoke();
            }
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
                isOpened = true;
            }
            else
            {
                isClosed.Invoke();
                isOpened = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && switches.Length == 0)
        {
            overLapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && switches.Length == 0)
        {
            overLapping = false;
            if (isOpened)
            {
                isOpened = false;
                isClosed.Invoke();
            }
        }
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    public void UnFreeze()
    {
        isFrozen = false;
        if(switches.Length > 0)
        {
            CheckForNewState();
        }
    }
}
