using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject DialogTrigger_Flowchart;
    //0
    public int oneTimeDialogIndex;
    
    private void Start()
    {
        if (PlayerDialogManager.instance.isDialogTriggered[oneTimeDialogIndex])
        {
            //如果，该对话对应的bool为真，则意味着此对话曾被激活过，则SetActive = false
            gameObject.SetActive(false);
        }
    }
}
