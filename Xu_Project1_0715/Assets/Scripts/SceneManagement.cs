using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public void EndConversation()
    {
        PlayerInteract.instance.EndConversation();
    }
}
