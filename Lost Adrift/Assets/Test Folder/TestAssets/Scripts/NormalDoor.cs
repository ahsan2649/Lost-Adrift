using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NormalDoor : MonoBehaviour
{
    public bool needsKey;
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

        if (needsKey)
        {
            locked = true;
        }

        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && overLapping && switches.Length == 0)
        {
            if (locked == false && !isOpened)
            {
                isOpen.Invoke();
                isOpened = true;
            }

            if (locked && playerRef.keys > 0)
            {
                playerRef.keys--;
                locked = false;
                isUnLocked.Invoke();
            }

            if(locked && playerRef.keys == 0)
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
        if (other.tag == "Player" && !isFrozen && switches.Length == 0)
        {
            overLapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isFrozen && switches.Length == 0)
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
        CheckForNewState();
    }
}
