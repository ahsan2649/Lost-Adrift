using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void thingy(string thingToSay)
    {
        Debug.Log(thingToSay);
    }
}
