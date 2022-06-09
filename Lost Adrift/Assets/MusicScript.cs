using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    float timer;
    public AudioClip[] tracks;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        int r = Random.Range(0, tracks.Length);
        source.PlayOneShot(tracks[r]);
        timer = tracks[r].length;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            source.Stop();
            int r = Random.Range(0, tracks.Length);
            source.PlayOneShot(tracks[r]);
            timer = tracks[r].length;
        }
    }
}
