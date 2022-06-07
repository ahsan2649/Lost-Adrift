using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isActive;
    public bool isInScene = true;
    public bool isTimed;
    public float duration;
    float timer;
    bool overlapping;
    bool isFrozen;

    public NormalDoor dooRef;
    public GameObject buttonPart;

    private void Update()
    {
        if (!isFrozen)
        {
            if (overlapping && Input.GetKeyDown(KeyCode.E))
            {
                isActive = !isActive;
                if (isActive)
                {
                    buttonPart.transform.localPosition = new Vector3(0, 0, -0.065f);
                    dooRef.CheckForNewState();
                    timer = duration;
                }
                else
                {
                    buttonPart.transform.localPosition = new Vector3(0, 0, -0.137f);
                    timer = 0;
                    dooRef.CheckForNewState();
                }
            }
            if (isTimed && timer > 0 && isActive)
            {
                timer -= Time.deltaTime;
            }
            if (timer < 0)
            {
                buttonPart.transform.localPosition = new Vector3(0, 0, -0.137f);
                timer = 0;
                isActive = false;
                dooRef.CheckForNewState();
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

    public void BlinkIn()
    {
        isInScene = true;
        dooRef.CheckForNewState();
        overlapping = false;
    }
    public void BlinkOut()
    {
        isInScene = false;
        dooRef.CheckForNewState();
        overlapping = false;
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    public void UnFreeze()
    {
        isFrozen = false;
    }
}
