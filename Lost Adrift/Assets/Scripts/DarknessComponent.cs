using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarknessComponent : MonoBehaviour
{
    Collider col;
    MusicScript music;

    public UnityEvent enterZone;
    public UnityEvent exitZone;

    void Start()
    {
        col = GetComponent<Collider>();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>();
    }


    public void ChangeState(bool canBePassed)
    {
        if (canBePassed)
        {
            col.isTrigger = true;
        }
        else
        {
            col.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            music.ChangeVolume(0.1f);
            enterZone.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            music.ChangeVolume(0.25f);
            exitZone.Invoke();
        }
    }
}
