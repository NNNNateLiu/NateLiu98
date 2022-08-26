using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapInteract : MonoBehaviour
{
    public Image uiImage;
    public GameObject explainText;
    public GameObject locationText;

    public void OnMouseEnter()
    {
        //Change the wheel colour when mouse enter
        uiImage.color = new Color(0.56f, 0.9f, 1, 1);
        explainText.SetActive(true);
        locationText.SetActive(false);

    }
    public void OnMouseExit()
    {
        //Change the wheel colour when mouse enter
        uiImage.color = new Color(1, 1, 1, 1);
        explainText.SetActive(false);
        locationText.SetActive(true);
    }
}
