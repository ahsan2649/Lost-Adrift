using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Source = GetComponent<AudioSource>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move != new Vector3(0, move.y, 0) && isPlaying == false)
        {
            lanternBob.StopPlayback();
            isPlaying = true;
        }
        else if(move == new Vector3(0, move.y, 0))
        {
            lanternBob.StartPlayback();
            isPlaying = false;
        }

        if (move != new Vector3(0, move.y, 0))
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                Step();
            }
        }

        controller.Move(move * currentSpeed * Time.deltaTime);
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
}
