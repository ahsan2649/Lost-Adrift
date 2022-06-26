using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    Transform startPos;
    public void ResetPos()
    {
        transform.position = startPos.position;
        transform.rotation = startPos.rotation;
    }
}
