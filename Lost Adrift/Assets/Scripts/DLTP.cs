using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLTP : MonoBehaviour
{
    public bool isInLOS;
    GameObject player;
    public RaycastHit hit;
    public AbstractSpaceObject abstractObject;

    private void Start()
    {
        abstractObject = GetComponent<AbstractSpaceObject>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, out hit, Mathf.Infinity, 7) && hit.transform.tag == "Player")
        {
            isInLOS = true;
            abstractObject.inSight();
            Debug.DrawLine(this.transform.position, player.transform.position, Color.green);
        }
        else
        {
            if (isInLOS)
            {
                abstractObject.outOfSight();
            }
            isInLOS = false;
            Debug.DrawLine(this.transform.position, player.transform.position, Color.red);
        }
    }


}
