using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public int speed;
    public int walkSpeed;
    int currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Darkness")
        {
            currentSpeed = walkSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Darkness")
        {
            currentSpeed = speed;
        }
    }
}
