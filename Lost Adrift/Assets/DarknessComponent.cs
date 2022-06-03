using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessComponent : MonoBehaviour
{
    Collider col;

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
}
