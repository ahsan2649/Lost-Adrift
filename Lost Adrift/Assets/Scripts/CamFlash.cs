using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFlash : MonoBehaviour
{
    Light camFlash;
    AudioSource camSound;

    private void Start()
    {
        camFlash = GetComponent<Light>();
        camSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (camFlash.intensity > 0)
        {
            camFlash.intensity -= 150 * Time.deltaTime;
        }
    }

    public void Flash()
    {
        camFlash.intensity = 100;
        camSound.Play();
    }
    public void ResetFlash()
    {
        camFlash.intensity = 0;
    }
}
