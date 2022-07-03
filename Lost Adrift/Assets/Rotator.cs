using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float minRotate;
    public float maxRotate;
    float f;

    void Start()
    {
        f = Random.Range(minRotate, maxRotate);
    }


    void Update()
    {
        transform.Rotate(f * Time.deltaTime, f * Time.deltaTime, f * Time.deltaTime);
    }
}
