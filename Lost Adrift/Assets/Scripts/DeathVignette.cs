using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DeathVignette : MonoBehaviour
{
    public AudioSource source;
    public Volume volume;
    public Vignette vignette;
    public float maxTime;

    bool isTiming;
    public float timer;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
            vignette.intensity.value = ((timer / (maxTime * 1.3f)) / 1.5f) + 0.3f;
            source.volume = timer / maxTime;
        }
        if (timer > maxTime)
        {
            SceneManager.LoadScene("Cabin_3", LoadSceneMode.Single);
        }
    }

    public void startTime()
    {
        isTiming = true;
    }

    public void stopTime()
    {
        isTiming = false;
        timer = 0;
        source.volume = 0;
    }

}
