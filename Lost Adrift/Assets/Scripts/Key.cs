using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent getKey;
    public Animator iconAnim;
    ItemScript playerRef;
    public bool isKey = true;
    bool collected;
    bool overlapping;

    private void Update()
    {
        if(overlapping && Input.GetKeyDown(KeyCode.E) && collected == false)
        {
            collected = true;
            if (isKey)
            {
                iconAnim.SetTrigger("Get");
                playerRef.keys++;
            }
            else
            {
                playerRef.ritualObjects++;
                playerRef.updateRitualItems();
            }
            getKey.Invoke();
            dissapear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerRef = other.GetComponent<ItemScript>();
            overlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = false;
        }
        if (collected)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    void dissapear()
    {
        overlapping = false;
    }
}
