using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandleTransition : MonoBehaviour
{
    bool overlapping;
    float timer;
    public bool inOtherworld;
    MusicScript musicRef;

    public GameObject normalWorld;
    public GameObject otherWorld;
    public GameObject candleHead;

    public UnityEvent onActive; 
    public UnityEvent goToOtherWorld;
    public CandleTransition[] CandleReferences;

    void Start()
    {
        musicRef = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>();

        GameObject[] candleRefs = GameObject.FindGameObjectsWithTag("Candle");
        CandleReferences = new CandleTransition[candleRefs.Length];
        int i = 0;
        foreach(GameObject gObject in candleRefs)
        {
            CandleReferences[i] = gObject.GetComponent<CandleTransition>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (overlapping && Input.GetKeyDown(KeyCode.E) && timer <= 0)
        {
            timer = 2;
            onActive.Invoke();
            if (!inOtherworld)
            {
                goToOtherWorld.Invoke();
            }
            if (inOtherworld)
            {
                foreach (CandleTransition script in CandleReferences)
                {
                    if (script != this)
                    {
                        script.HideOtherWorld();
                    }
                }
                musicRef.PlayMusic();
                normalWorld.SetActive(true);
                otherWorld.SetActive(false);
                candleHead.SetActive(true);
            }
            else
            {
                musicRef.PauseMusic();
                normalWorld.SetActive(false);
                otherWorld.SetActive(true);
                candleHead.SetActive(false);
                foreach (CandleTransition script in CandleReferences)
                {
                    if (script != this)
                    {
                        script.inOtherworld = true;
                    }
                }
            }

            inOtherworld = !inOtherworld;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = false;
        }
    }

    public void HideOtherWorld()
    {
        otherWorld.SetActive(false);
        inOtherworld = false;
    }
}
