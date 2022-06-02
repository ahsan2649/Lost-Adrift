using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    int equippedItem;
    public GameObject[] items;

    public GameObject[] compassDirection;

    Compass[] chargedObjects;

    public bool isNorth;

    void Start()
    {
        items[0].SetActive(true);

        chargedObjects = FindObjectsOfType<Compass>();

        foreach (Compass script in chargedObjects)
        {
            script.ChargeUpdated(isNorth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            items[equippedItem].SetActive(false);
            equippedItem++;
            if (equippedItem == items.Length)
            {
                equippedItem = 0;
            }
            items[equippedItem].SetActive(true);
            Debug.Log(equippedItem);
        }

        //CompassCode
        if (Input.GetKeyDown(KeyCode.Mouse1) && equippedItem == 0)
        {
            isNorth = !isNorth;
            if (isNorth)
            {
                compassDirection[0].SetActive(true);
                compassDirection[1].SetActive(false);
            }
            else if (!isNorth)
            {
                compassDirection[1].SetActive(true);
                compassDirection[0].SetActive(false);
            }
            foreach (Compass script in chargedObjects)
            {
                script.ChargeUpdated(isNorth);
            }
        }
    }
}
