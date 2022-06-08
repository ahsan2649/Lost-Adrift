using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarknessComponent : MonoBehaviour
{
    Collider col;

    public UnityEvent enterZone;
    public UnityEvent exitZone;

    void Start()
    {
        col = GetComponent<Collider>();
    }


    public void ChangeState(bool canBePassed)
    {
        if (canBePassed)
        {
            col.isTrigger = true;
        }
        else
        {
            col.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterZone.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            exitZone.Invoke();
        }
    }
}
