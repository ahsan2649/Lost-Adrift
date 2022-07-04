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
    ItemScript reference;

    private void Start()
    {
        reference = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && overlapping)
        {
            Debug.Log(reference.ritualObjects);
            if (!isActivated && reference.ritualObjects > 0)
            {
                reference.ritualObjects--;
                reference.updateRitualItems();
                isActivated = true;
                onActivate.Invoke();
                ritualOn();
            }
            else if(!isActivated && reference.ritualObjects == 0)
            {
                onDeactivate.Invoke();
                ritualOff();
            }
            else if(isActivated)
            {
                reference.ritualObjects++;
                reference.updateRitualItems();
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
        onActivate.Invoke();
    }

    public void ritualOff()
    {
        isActivated = false;
        doorRef.CheckForNewState();
        onDeactivate.Invoke();
    }

}
