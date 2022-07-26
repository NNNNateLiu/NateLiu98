using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject UI_Item1_KeyCard;
    public bool isHaveKeyCard;
    
    public static PlayerInteract instance;

    public PlayerController_test player;

    public GameObject ScreenFlash;

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
    
    private void OnTriggerStay2D(Collider2D other)
    {
        //玩家处于keycard的碰撞范围，同时按下了E，收集门卡
        if (other.tag == "KeyCard" && Input.GetKey(KeyCode.E))
        {
            //销毁地面上的KeyCard
            Destroy(other.gameObject);
            //激活UI中的KeyCard图标
            UI_Item1_KeyCard.SetActive(true);
            //玩家有了门卡
            isHaveKeyCard = true;
        }

        //玩家处于DoorSwitch的碰撞范围，且有门卡，同时按下了Q，开门
        if (other.tag == "DoorSwitch" && Input.GetKey(KeyCode.Q))
        {
            //当玩家站在开关范围内，且按下了F，执行开门判断逻辑Flowchart
            other.GetComponent<DoorSwitch>().doorSwitch_Flowchart.SetActive(true);
            //执行开门逻辑时，要让Flowchart中 isHaveKeyCard变量值与 脚本中isHaveKeyCard保持一致
            other.GetComponent<DoorSwitch>().doorSwitch_Flowchart.GetComponent<Flowchart>().SetBooleanVariable("isHaveKeyCard",isHaveKeyCard);
            //修改playerController中的IsInConversation为真，进入对话
            player.isInConversation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WallTransparent")
        {
            Debug.Log("enter transparent wall");
            //当玩家进入透明墙Trigger里的时候，播放ToTransparent动画
            other.transform.parent.GetComponent<Animator>().SetTrigger("ToTransparent");
        }

        if (other.tag == "SceneChangeTrigger")
        {
            //当玩家站在场景切换触发范围内，执行场景切换判断逻辑Flowchart
            other.GetComponent<SceneChangeTrigger>().SceneChangeTrigger_Flowchart.SetActive(true);
            //修改playerController中的IsInConversation为真，进入对话
            player.isInConversation = true;
        }

        if (other.tag == "KeyCard")
        {
            //当玩家靠近keycard范围中时，激活拾取提示UI
            other.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.tag == "DoorSwitch")
        {
            //当玩家靠近开关范围时，激活交互提示UI
            other.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.tag == "EnemyDetectCircle")
        {
            //当玩家进入敌人检测范围时，检测值detectValue开始增加
            other.GetComponent<EnemyDetectCircle>().isPlayerWithinRange = true;

            ScreenFlash.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "WallTransparent")
        {
            Debug.Log("exit transparent wall");
            other.transform.parent.GetComponent<Animator>().SetTrigger("ToSolid");
        }

        if (other.tag == "KeyCard")
        {
            //当玩家离开keycard范围中时，关闭拾取提示UI
            other.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (other.tag == "DoorSwitch")
        {
            //当玩家离开开关范围时，关闭交互提示UI
            other.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (other.tag == "EnemyDetectCircle")
        {
            //当玩家离开敌人检测范围时，检测值detectValue开始衰减
            other.GetComponent<EnemyDetectCircle>().isPlayerWithinRange = false;

            ScreenFlash.SetActive(false);
        }
    }

    public void EndConversation()
    {
        //修改playerController中的IsInConversation为真，离开对话
        player.isInConversation = false;
    }
}
