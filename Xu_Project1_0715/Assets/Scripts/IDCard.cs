using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCard : MonoBehaviour
{
    private void Start()
    {
        if (PlayerInteract.instance.isHaveIDCard)
        {
            Destroy(gameObject);
        }
    }
}
