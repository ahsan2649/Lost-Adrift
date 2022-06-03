using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int equippedItem;
    public GameObject[] items;

    public GameObject[] compassDirection;

    public List<Compass> chargedObjects;
    public List<DarknessComponent> darkAreas;

    public bool isNorth;
    bool canSwitch = true;

    void Start()
    {
        items[0].SetActive(true);

        Compass[] i = FindObjectsOfType<Compass>();

        foreach(Compass script in i)
        {
            chargedObjects.Add(script);
        }

        DarknessComponent[] d = FindObjectsOfType<DarknessComponent>();

        foreach(DarknessComponent script in d)
        {
            darkAreas.Add(script);
        }

        foreach (Compass script in chargedObjects)
        {
            script.ChargeUpdated(isNorth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canSwitch)
        {
            items[equippedItem].SetActive(false);
            equippedItem++;
            if (equippedItem == items.Length)
            {
                equippedItem = 0;
            }
            items[equippedItem].SetActive(true);

            if(equippedItem == 1)
            {
                LampStatus(true);
            }
            else
            {
                LampStatus(false);
            }
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

    public void addCompassToList(Compass refToAdd)
    {
        chargedObjects.Add(refToAdd);
        refToAdd.ChargeUpdated(isNorth);
    }

    public void LampStatus(bool isEquipped)
    {
        foreach(DarknessComponent script in darkAreas)
        {
            script.ChangeState(isEquipped);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Darkness")
        {
            canSwitch = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Darkness")
        {
            canSwitch = true;
        }
    }
}
