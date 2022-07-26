using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    
    public Transform waypointTopLeft;
    public Transform waypointTopRight;
    public Transform waypointBottomLeft;
    public Transform waypointBottomRight;

    private bool isVerticalMoving;
    
    //array test
    public int age;
    public int[] ages = new int[6];
    public float[] weights = new float[6];
    public GameObject[] wayPoints;
    
    

    private void Start()
    {
        gameObject.transform.position = waypointTopLeft.position;
        age = 1;
        ages[0] = 0;
    }

    private void FixedUpdate()
    {
        Vector3 temp = gameObject.transform.position;

        //NPC先从左上角出发，向左下角走
        if (gameObject.transform.position.x <= waypointTopLeft.position.x && gameObject.transform.position.y > waypointBottomLeft.position.y)
        {
            temp.y -= speed;
            animator.SetBool("isWalking", true);
            Debug.Log("walking down");
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if (gameObject.transform.position.y <= waypointBottomLeft.position.y && gameObject.transform.position.x < waypointBottomRight.position.x)
        {
            temp.x += speed;
            animator.SetBool("isWalingRight", true);
            Debug.Log("walking right");
        }
        else
        {
            animator.SetBool("isWalingRight", false);
        }
        
        if (gameObject.transform.position.y < waypointTopRight.position.y && gameObject.transform.position.x >= waypointBottomRight.position.x)
        {
            temp.y += speed;
            animator.SetBool("isWalkingBack", true);
            Debug.Log("walking back");
        }
        else
        {
            animator.SetBool("isWalkingBack", false);
        }
        
        if (gameObject.transform.position.y >= waypointTopRight.position.y && gameObject.transform.position.x > waypointTopLeft.position.x)
        {
            temp.x -= speed;
            animator.SetBool("isWalkingLeft", true);
            Debug.Log("walking Left");
        }
        else
        {
            animator.SetBool("isWalkingLeft", false);
        }
        
        gameObject.transform.position = temp;
    }

    public void MoveToNextWaypoint(GameObject nextWaypoint)
    {
        
    }
}
