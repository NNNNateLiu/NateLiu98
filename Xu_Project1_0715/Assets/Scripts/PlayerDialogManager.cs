using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogManager : MonoBehaviour
{
    public static PlayerDialogManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(transform.root.gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    
    public List<bool> isDialogTriggered;
    //0 - start
    //1 - withFatherFirst
    //2 - in LAB Node1 memory
    
}
