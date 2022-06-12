using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLTP : MonoBehaviour
{
    public bool isInLOS;
    public GameObject player;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, out hit) && hit.transform.tag == "Player")
        {
            isInLOS = true;
            Debug.DrawLine(this.transform.position, player.transform.position, Color.green);
        }
        else
        {
            isInLOS = false;
            Debug.DrawLine(this.transform.position, player.transform.position, Color.red);
        }
    }
}
