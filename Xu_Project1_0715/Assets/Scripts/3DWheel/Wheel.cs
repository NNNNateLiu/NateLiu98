using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public GameObject theWheel;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SetWheelStatues(false);
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            SetWheelStatues(true);
        }
    }

    public void SetWheelStatues(bool isWheelOpen)
    {
        if (isWheelOpen)
        {
            theWheel.SetActive(false);
        }
        else
        {
            theWheel.SetActive(true);
        }
    }
}
