using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public GameObject NPCdialog_Flowchart;

    //����Ի�
    public string ChatName;
    public bool canChat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canChat = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canChat = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Say();
        }
    }

    void Say()
    {
        if (canChat)
        {
            NPCdialog_Flowchart.SetActive(true);
            PlayerController_test.instance.isInConversation = true;
        }
    }
}
