using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAVEDATASCRIPT : MonoBehaviour
{
    public float sensitivity = 250;
    public MouseLook localMouseScript;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void newSensitivity(float newSense)
    {
        sensitivity = newSense;
        sensitivity = Mathf.Clamp(sensitivity, 1, 500);
        localMouseScript.mouseSense = sensitivity;
    }
}
