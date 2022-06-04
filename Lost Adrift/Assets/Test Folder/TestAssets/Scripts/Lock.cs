using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lock : MonoBehaviour
{
    public UnityEvent unlocked;
    bool isLocked = true;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.gameObject.GetComponent<ItemScript>().keys > 0 && isLocked)
        {
            other.gameObject.GetComponent<ItemScript>().keys -= 1;
            unlocked.Invoke();
            isLocked = false;
        }
    }

    public void TestEvent(string msg)
    {
        Debug.Log(msg);
    }
}
