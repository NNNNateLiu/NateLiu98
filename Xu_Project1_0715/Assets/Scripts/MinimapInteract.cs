using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapInteract : MonoBehaviour
{
    public void OnMouseEnter()
    {
        //Change the wheel colour when mouse enter
        UIController.instance.OnEnterMinimapPosition(gameObject);

    }
    public void OnMouseExit()
    {
        //Change the wheel colour when mouse enter
        UIController.instance.OnExitMinimapPosition(gameObject);
    }
}
