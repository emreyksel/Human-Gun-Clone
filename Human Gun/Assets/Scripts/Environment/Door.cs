using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI blueDoorText;
    public TextMeshProUGUI redDoorText;

    public int blueDoorValue;
    public int redDoorValue;

    private bool once = true;

    private void Start()
    {
        blueDoorText.text = "+"+ blueDoorValue.ToString();
        redDoorText.text = "-"+ redDoorValue.ToString();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (once)
        {
            once = false;

            if (other.transform.position.x < 0) //blue door
            {
                GunType.instance.HumanCounter(blueDoorValue);
            }
            else // red door
            {
                GunType.instance.HumanCounter(-redDoorValue);
            }
        }      
    }
}
