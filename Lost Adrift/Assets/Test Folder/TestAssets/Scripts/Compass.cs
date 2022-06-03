using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Compass : MonoBehaviour
{
    bool isFrozen;
    public bool isNorth;
    bool storedCharge;

    public UnityEvent SameCharge;
    public UnityEvent DifCharge;


    public void ChargeUpdated(bool newCharge)
    {
        if (!isFrozen)
        {
            if (newCharge == isNorth)
            {
                SameCharge.Invoke();
            }
            else
            {
                DifCharge.Invoke();
            }
        }
        else
        {
            storedCharge = newCharge;
        }
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>().addCompassToList(this);
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    public void UnFreeze()
    {
        if (storedCharge == isNorth)
        {
            SameCharge.Invoke();
        }
        else
        {
            DifCharge.Invoke();
        }
        isFrozen = false;
    }
}
