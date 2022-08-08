using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMangement : MonoBehaviour
{
    public void EndConversation()
    {
        PlayerInteract.instance.EndConversation();
    }
}
