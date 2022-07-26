using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject ControllingDoor;
    public GameObject doorSwitch_Flowchart;

    public void OpenControllingDoor()
    {
        ControllingDoor.GetComponent<Animator>().SetTrigger("isOpen");
    }
}
