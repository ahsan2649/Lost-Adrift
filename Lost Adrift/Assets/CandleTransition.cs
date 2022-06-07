using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandleTransition : MonoBehaviour
{
    bool overlapping;
    bool inOtherworld;

    public GameObject normalWorld;
    public GameObject otherWorld;
    public GameObject candleHead;

    public UnityEvent onActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (overlapping && Input.GetKeyDown(KeyCode.E))
        {
            onActive.Invoke();
            if (inOtherworld)
            {
                normalWorld.SetActive(true);
                otherWorld.SetActive(false);
                candleHead.SetActive(true);
            }
            else
            {
                normalWorld.SetActive(false);
                otherWorld.SetActive(true);
                candleHead.SetActive(false);
            }

            inOtherworld = !inOtherworld;

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
}
