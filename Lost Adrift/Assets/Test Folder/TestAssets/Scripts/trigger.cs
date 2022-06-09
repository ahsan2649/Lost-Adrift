using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trigger : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            onExit.Invoke();
        }
    }
}
