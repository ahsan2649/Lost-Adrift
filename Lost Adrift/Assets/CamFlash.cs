using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFlash : MonoBehaviour
{
    Light camFlash;

    private void Start()
    {
        camFlash = GetComponent<Light>();
    }

    void Update()
    {
        if (camFlash.intensity > 0)
        {
            camFlash.intensity -= 200 * Time.deltaTime;
        }
    }

    public void Flash()
    {
        camFlash.intensity = 100;
    }
}
