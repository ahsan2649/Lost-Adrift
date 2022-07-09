using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public TestPlayerMovement playerMovement;
    public ItemScript playerItems;

    public float mouseSense = 100;
    public GameObject pauseMenu;

    public Transform playerBody;
    MusicScript music;
    float xRot = 0;
    bool isPaused;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Savedata").GetComponent<SAVEDATASCRIPT>().localMouseScript = this;
        mouseSense = GameObject.FindGameObjectWithTag("Savedata").GetComponent<SAVEDATASCRIPT>().sensitivity;
        Cursor.lockState = CursorLockMode.Locked;
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);

            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                playerMovement.Pause();
                playerItems.Pause();
                music.PauseMusic();
                pauseMenu.SetActive(true);
                isPaused = true;
            }
        }
    }

    public void unPause()
    {
        playerItems.UnPause();
        playerMovement.UnPause();
        music.PlayMusic();
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
}
