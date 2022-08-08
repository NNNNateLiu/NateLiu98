using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog_trigger : MonoBehaviour
{
    public GameObject NPCdialog_trigger_Flowchart;

    public string ChatName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NPCdialog_trigger_Flowchart.SetActive(true);
            GetComponent<PlayerController_test>().isInConversation= true;
        }
    }
    public void EndConversation()
    {
        //修改playerController中的IsInConversation为false，离开对话
        GetComponent<PlayerController_test>().isInConversation = false;
    }
}
