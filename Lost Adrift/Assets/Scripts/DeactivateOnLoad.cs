using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnLoad : MonoBehaviour
{
    float buffer = 0.1f;

    private void Update()
    {
        buffer -= Time.deltaTime;

        if(buffer <= 0)
        {
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
