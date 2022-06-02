using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Compass : MonoBehaviour
{
    public bool isNorth;

    public UnityEvent SameCharge;
    public UnityEvent DifCharge;


    public void ChargeUpdated(bool newCharge)
    {
        if (newCharge == isNorth)
        {
            SameCharge.Invoke();
            Debug.Log("SameCharge");
        }
        else
        {
            DifCharge.Invoke();
        }
    }
}
