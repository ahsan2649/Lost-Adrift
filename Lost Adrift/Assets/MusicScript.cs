using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    float timer;
    bool paused;
    public AudioClip[] tracks;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        int r = Random.Range(0, 20);
        timer = r;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            source.Stop();
            int r = Random.Range(0, tracks.Length);
            source.clip = tracks[r];
            source.Play();
            timer = tracks[r].length;
            r = Random.Range(0, 15);
            timer += r;
        }
    }

    public void PauseMusic()
    {
        source.Pause();
        paused = true;
    }

    public void PlayMusic()
    {
        source.UnPause();
        paused = false;
    }
}
