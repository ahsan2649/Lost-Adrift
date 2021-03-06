using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    bool paused;
    CharacterController controller;
    public AudioClip[] StepSounds;
    AudioSource Source;

    float timer;
    public int speed;
    public int walkSpeed;
    int currentSpeed;
    bool inDarkness;

    public Animator lanternBob;
    bool isPlaying;

    public GameObject GoPro;
    float stableCam;
    public float bobAmount;
    public float bobFreq;
    float timePassed;


    void Start()
    {
        stableCam = GoPro ? GoPro.transform.position.y : 0;
        timePassed = 0;

        controller = GetComponent<CharacterController>();
        Source = GetComponent<AudioSource>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (paused == false)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (move != new Vector3(0, move.y, 0) && isPlaying == false)
            {
                lanternBob.StopPlayback();
                isPlaying = true;
            }
            else if (move == new Vector3(0, move.y, 0))
            {
                GoPro.transform.position = Vector3.Lerp(GoPro.transform.position, new Vector3(
                    GoPro.transform.position.x,
                    GoPro.transform.position.y,
                    GoPro.transform.position.z
                    ), 2f * Time.deltaTime);

                lanternBob.StartPlayback();
                isPlaying = false;
            }

            if (move != new Vector3(0, move.y, 0))
            {
                GoPro.transform.position = Vector3.Lerp(GoPro.transform.position, new Vector3(
                    GoPro.transform.position.x,
                    stableCam + Mathf.Sin(Time.realtimeSinceStartup * bobFreq) * bobAmount,
                    GoPro.transform.position.z
                    ), 2f * Time.deltaTime);

                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    Step();
                }
            }
            controller.Move(move * currentSpeed * Time.deltaTime);
        }
    }

    void Step()
    {
        int r = Random.Range(0, StepSounds.Length);
        timer = StepSounds[r].length;
        if (inDarkness)
        {
            timer = StepSounds[r].length * 1.5f;
        }
        Source.PlayOneShot(StepSounds[r]); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Darkness")
        {
            inDarkness = true;
            currentSpeed = walkSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Darkness")
        {
            inDarkness = false;
            currentSpeed = speed;
        }
    }

    public void leftDarkness() //Called when darkness is disabled rather than left organically
    {
        inDarkness = false;
        currentSpeed = speed;
    }

    public void Pause()
    {
        lanternBob.StartPlayback();
        isPlaying = false;
        paused = true;
    }

    public void UnPause()
    {
        paused = false;
    }
}
