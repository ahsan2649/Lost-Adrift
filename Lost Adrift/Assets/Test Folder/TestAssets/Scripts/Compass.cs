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
        }
        else
        {
            DifCharge.Invoke();
        }
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ItemScript>().addCompassToList(this);
    }
}
