using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public ResetPosition resetRef;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kill")
        {
            resetRef.ResetPos();
        }
    }
}
