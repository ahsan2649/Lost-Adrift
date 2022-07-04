using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ItemScript : MonoBehaviour
{
    public int equippedItem;
    public GameObject[] items;

    public GameObject[] compassDirection;

    public List<Compass> chargedObjects;
    public List<DarknessComponent> darkAreas;
    public List<CameraFlashComponent> flashableObjects;

    public bool isNorth;
    bool canSwitch = true;
    public UnityEvent camFlash;
    public int keys;
    public int ritualObjects;
    float timer;

    public TextMeshProUGUI ritualNum;
    public Animator candleIcon;

    void Start()
    {
        items[0].SetActive(true);

        Compass[] i = FindObjectsOfType<Compass>();

        foreach(Compass script in i)
        {
            chargedObjects.Add(script);
        }

        foreach (Compass script in chargedObjects)
        {
            script.ChargeUpdated(isNorth);
        }


        DarknessComponent[] d = FindObjectsOfType<DarknessComponent>();

        foreach(DarknessComponent script in d)
        {
            darkAreas.Add(script);
        }


        CameraFlashComponent[] c = FindObjectsOfType<CameraFlashComponent>();

        foreach(CameraFlashComponent script in c)
        {
            flashableObjects.Add(script);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && canSwitch)
        {
            items[equippedItem].SetActive(false);
            equippedItem++;
            if (equippedItem == items.Length)
            {
                equippedItem = 0;
            }
            items[equippedItem].SetActive(true);

            if(items[equippedItem].name == "Lamp")
            {
                LampStatus(true);
            }
            else
            {
                LampStatus(false);
            }
        }

        //CompassCode
        if (Input.GetKeyDown(KeyCode.Mouse1) && items[equippedItem].name == "Compass")
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

        //CameraCode
        if(Input.GetKeyDown(KeyCode.Mouse1) && items[equippedItem].name == "Camera" && timer < 0)
        {
            timer = 5;
            camFlash.Invoke();
            foreach(CameraFlashComponent script in flashableObjects)
            {
                script.TestIfFlashed();
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

    public void leftDarkness() //Called when darkness is disabled rather than left organically
    {
        canSwitch = true;
    }

    public void updateRitualItems()
    {
        ritualNum.text = ritualObjects + "";
        if (candleIcon.GetCurrentAnimatorStateInfo(0).IsName("CandleIconGet"))
        {
            candleIcon.Play("CandleIconIdle");
            candleIcon.SetTrigger("Get");
        }
        else
        {
            candleIcon.SetTrigger("Get");
        }
    }
}
