using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFlashComponent : MonoBehaviour
{
    public UnityEvent Freeze;
    public UnityEvent unFreeze;

    float time;
    bool canBeFrozen = true;

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            unFreeze.Invoke();
            time = 0;
        }
    }

    private void OnBecameVisible()
    {
        canBeFrozen = true;
    }

    private void OnBecameInvisible()
    {
        canBeFrozen = false;
    }

    public void TestIfFlashed()
    {
        if (canBeFrozen)
        {
            time = 5;
            Freeze.Invoke();
            Debug.Log("sdsdsd");
        }
    }
}
