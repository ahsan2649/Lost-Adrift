using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent getKey;
    public bool isKey = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isKey)
            {
                other.gameObject.GetComponent<ItemScript>().keys++;
            }
            else
            {
                other.gameObject.GetComponent<ItemScript>().ritualObjects++;
            }
            getKey.Invoke();
            Destroy(gameObject);
        }
    }
}
