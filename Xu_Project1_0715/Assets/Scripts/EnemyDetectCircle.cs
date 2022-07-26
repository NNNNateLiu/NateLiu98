using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectCircle : MonoBehaviour
{
    //0.01 - 1
    public float detectValue;
    public Vector3 detectCircleScale;
    public GameObject detectCircle;
    public Material detectCircleMaterial;
    public Color circleColor;
    private Vector3 circleColorDebug;

    public float detectValueIncreaseSpeed;
    public float detectValueDecreaseSpeed;
    public bool isPlayerWithinRange;

    private void Start()
    {
        detectCircleScale = detectCircle.transform.localScale;
        circleColor = detectCircleMaterial.color;
    }

    private void Update()
    {
        //detectCircleColorChange();
        detectValueChanging();
        SetDetectCircleScaleByDetectValue();
        
        //detectCircleMaterial.color = Color.Lerp(Color.white, Color.red, detectValue);
    }

    public void SetDetectCircleScaleByDetectValue()
    {
        detectCircleScale = Vector3.one * detectValue;
        detectCircle.transform.localScale = detectCircleScale;
    }

    public void detectValueChanging()
    {
        if (isPlayerWithinRange)
        {
            detectValue += detectValueIncreaseSpeed;
        }
        else
        {
            detectValue -= detectValueDecreaseSpeed;
        }
        
        if (detectValue >= 1)
        {
            detectValue = 1;
        }

        if (detectValue <= 0.01f)
        {
            detectValue = 0.01f;
        }
    }

    public void detectCircleColorChange()
    {
        circleColor = new Color(255, 255 - (detectValue * 255), 255 - (detectValue * 255));
        circleColorDebug = new Vector3(255, 255 - (detectValue * 255), 255 - (detectValue * 255));
        detectCircleMaterial.color = circleColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //当玩家进入敌人检测范围时，开启Target Aim square
            other.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.tag == "Enemy")
        {
            //当玩家进入敌人检测范围时，出现感叹号
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //当玩家离开敌人检测范围时，关闭Target Aim square
            other.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (other.tag == "Enemy")
        {
            //当玩家离开敌人检测范围时，感叹号消失
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
