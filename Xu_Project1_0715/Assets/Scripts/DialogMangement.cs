using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMangement : MonoBehaviour
{
    public void EndConversation()
    {
        PlayerInteract.instance.EndConversation();
        Debug.Log("jia");
    }

    public void StartMeetMemberTimer()
    {
        PlayerController_test.instance.isMeetMemberTimerStart = true;
    }

    public void StopMeetMemberTimer()
    {
        PlayerController_test.instance.isMeetMemberTimerStart = false;
    }
}
