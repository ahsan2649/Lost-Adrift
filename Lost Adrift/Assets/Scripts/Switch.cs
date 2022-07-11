using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public bool isInSequence;
    bool localSequenceCheck;
    AudioSource aSS;
    public bool isActive;
    public bool isInScene = true;
    public bool isTimed;
    public float duration;
    public float timer;
    bool overlapping;
    bool isFrozen;

    public NormalDoor dooRef;

    public UnityEvent onActivate;
    public UnityEvent onDeActivate;

    private void Start()
    {
        aSS = GetComponent<AudioSource>();
        localSequenceCheck = isInSequence;
    }

    private void Update()
    {
        if (!isFrozen)
        {
            if (overlapping && Input.GetKeyDown(KeyCode.E))
            {
                isActive = !isActive;
                aSS.Play();
                if (isActive)
                {
                    dooRef.CheckForNewState();
                    timer = duration;
                    onActivate.Invoke();
                }
                else
                {
                    timer = 0;
                    dooRef.CheckForNewState();
                    onDeActivate.Invoke();
                }
            }
            if (isTimed && timer > 0 && isActive)
            {
                timer -= Time.deltaTime;
            }
            if (timer < 0)
            {
                timer = 0;
                isActive = false;
                onDeActivate.Invoke();
                dooRef.CheckForNewState();
                dooRef.SequenceBroken();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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

    public void SequenceFollowed()
    {
        localSequenceCheck = false;
    }

    public void SequenceBroken()
    {
        localSequenceCheck = isInSequence;
        onDeActivate.Invoke();
    }

    public void Deactivate()
    {
        if (localSequenceCheck)
        {
            onDeActivate.Invoke();
            isActive = false;
            timer = 0;
            dooRef.CheckForNewState();
        }
    }
}
